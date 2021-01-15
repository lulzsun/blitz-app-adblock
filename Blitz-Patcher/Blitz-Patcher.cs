using asardotnet;
using Blitz_Patcher.Properties;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Blitz_Patcher
{
    public partial class Blitz_Patcher : Form
    {
        public Blitz_Patcher()
        {
            InitializeComponent();
        }

        private readonly IniFile _config = new IniFile("settings.ini");
        private static string AppPath => $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Programs\\Blitz\\resources";

        private void Blitz_Patcher_Load(object sender, EventArgs e)
        {
            FiltersSettingsTP.Enabled = false; // Not finished yet
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            VersionLB.Text = Application.ProductVersion;
            //Just check if the first setting is in the ini file
            if (!_config.KeyExists("Blitz-No-Update"))
            {
                //Create Entries
                _config.Write("Blitz-No-Update", "false");
                _config.Write("Blitz-Auto-Guest", "false");
                _config.Write("EasyList", "true");
                _config.Write("EasyPrivacy", "true");
                _config.Write("UBlockAds", "true");
                _config.Write("UBlockPrivacy", "true");
                _config.Write("PeterLowe", "true");
            }

            BlitzNoUpdateCB.Checked = _config.Read("Blitz-No-Update").ToLower().Contains("true");
            BlitzAutoGuestCB.Checked = _config.Read("Blitz-Auto-Guest").ToLower().Contains("true");
            EasyListCB.Checked = _config.Read("EasyList").ToLower().Contains("true");
            EasyPrivacyCB.Checked = _config.Read("EasyPrivacy").ToLower().Contains("true");
            UBlockAdsCB.Checked = _config.Read("UBlockAds").ToLower().Contains("true");
            UBlockPrivacyCB.Checked = _config.Read("UBlockPrivacy").ToLower().Contains("true");
            PeterLoweCB.Checked = _config.Read("PeterLowe").ToLower().Contains("true");
        }

        public string BoolToString(bool b)
        {
            return b ? "true" : "false";
        }

        private void SaveSettingsBTN_Click(object sender, EventArgs e)
        {
            _config.DeleteSection("Blitz-Patcher");

            _config.Write("Blitz-No-Update", BoolToString(BlitzNoUpdateCB.Checked));
            _config.Write("Blitz-Auto-Guest", BoolToString(BlitzAutoGuestCB.Checked));
            _config.Write("EasyList", BoolToString(EasyListCB.Checked));
            _config.Write("EasyPrivacy", BoolToString(EasyPrivacyCB.Checked));
            _config.Write("UBlockAds", BoolToString(UBlockAdsCB.Checked));
            _config.Write("UBlockPrivacy", BoolToString(UBlockPrivacyCB.Checked));
            _config.Write("PeterLowe", BoolToString(PeterLoweCB.Checked));
        }

        private void PatchBTN_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{AppPath}\\app.asar"))
            {
                try
                {
                    IO.CopyFolder($"{AppPath}\\app.asar.unpacked\\", $"{AppPath}\\app\\");
                    var asar = new AsarArchive($"{AppPath}\\app.asar");
                    var extractor = new AsarExtractor();
                    extractor.ExtractAll(asar, $"{AppPath}\\app\\", true);
                }
                catch (IOException)
                {
                    MessageBox.Show("There seems to be a problem!");
                    return;
                }

                if (EasyListCB.Checked)
                    new WebClient().DownloadFile("https://easylist.to/easylist/easylist.txt", $"{AppPath}\\app\\src\\easylist.txt");
                if (EasyPrivacyCB.Checked)
                    new WebClient().DownloadFile("https://easylist.to/easylist/easyprivacy.txt", $"{AppPath}\\app\\src\\easyprivacy.txt");
                if (UBlockAdsCB.Checked)
                    new WebClient().DownloadFile("https://raw.githubusercontent.com/uBlockOrigin/uAssets/master/filters/filters.txt", $"{AppPath}\\app\\src\\ublock-ads.txt");
                if (UBlockPrivacyCB.Checked)
                    new WebClient().DownloadFile("https://raw.githubusercontent.com/uBlockOrigin/uAssets/master/filters/privacy.txt", $"{AppPath}\\app\\src\\ublock-privacy.txt");
                if (PeterLoweCB.Checked)
                    new WebClient().DownloadFile("https://pgl.yoyo.org/adservers/serverlist.php?hostformat=adblock&showintro=1&mimetype=plaintext", $"{AppPath}\\app\\src\\peter-lowe-list.txt");

                var fileToPatch = $"{AppPath}\\app\\src\\createWindow.js";
                //create a backup file
                File.Copy(fileToPatch, fileToPatch+".bak");

                // copy adblocker lib to src
                File.WriteAllBytes($"{AppPath}\\app\\src\\adblocker.umd.min.js", Encoding.UTF8.GetBytes(Resources.adblocker_umd_min));

                // start writing our payload to createWindow.js
                IO.ModifyFileAtLine("session: true,", fileToPatch, 106);

                IO.ModifyFileAtLine(JS.FilterEngine, fileToPatch, 119);

                // optional features
                if (BlitzNoUpdateCB.Checked)
                    IO.ModifyFileAtLine("if (false) {", $"{AppPath}\\app\\src\\index.js", 267);
                if (BlitzAutoGuestCB.Checked)
                    IO.ModifyFileAtLine(JS.AutoGuest, $"{AppPath}\\app\\src\\preload.js", 18);

                MessageBox.Show("Patch Completed");
            }
            else
            {
                MessageBox.Show("app.asar not found!");
            }
        }

        private void UnpatchButton_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{AppPath}\\app\\src\\createWindow.js.bak"))
            {
                File.Delete($"{AppPath}\\app\\src\\createWindow.js");
                File.Move($"{AppPath}\\app\\src\\createWindow.js.bak", $"{AppPath}\\app\\src\\createWindow.js");
                MessageBox.Show("Blitz.GG Restored");
            }
            else
                MessageBox.Show("Did not find backup file,please reinstall blitz.gg");
        }
    }
}