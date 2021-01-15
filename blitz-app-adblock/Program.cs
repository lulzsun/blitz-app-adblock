using System;
using System.IO;
using System.Net;
using System.Text;
using asardotnet;
using blitz_app_adblock.Properties;

namespace blitz_app_adblock {
    class Program {
        private static string AppPath => $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Programs\\Blitz\\resources";
        static void Main(string[] args) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var noupdate = false;
            var autoguest = false;

            foreach (var arg in args)
            {
                switch (arg.ToLower())
                {
                    case "-noupdate":
                        Console.WriteLine("Disabling Blitz auto update...");
                        noupdate = true;
                        break;
                    case "-autoguest":
                        Console.WriteLine("Enabling auto sign in as guest...");
                        autoguest = true;
                        break;
                }
            }

            if (File.Exists($"{AppPath}\\app.asar")) {
                Console.WriteLine("app.asar found!");

                try {
                    Console.WriteLine("Extracting...");
                    IO.CopyFolder($"{AppPath}\\app.asar.unpacked\\", $"{AppPath}\\app\\");
                    var asar = new AsarArchive($"{AppPath}\\app.asar");
                    var extractor = new AsarExtractor();
                    extractor.ExtractAll(asar, $"{AppPath}\\app\\", true);
                } catch (IOException) {
                    Console.WriteLine("Error extracting files! Make sure Blitz app is closed before trying again.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Downloading ad & tracking filters...");
                new WebClient().DownloadFile("https://easylist.to/easylist/easylist.txt", $"{AppPath}\\app\\src\\easylist.txt");
                new WebClient().DownloadFile("https://easylist.to/easylist/easyprivacy.txt", $"{AppPath}\\app\\src\\easyprivacy.txt");
                new WebClient().DownloadFile("https://raw.githubusercontent.com/uBlockOrigin/uAssets/master/filters/filters.txt", $"{AppPath}\\app\\src\\ublock-ads.txt");
                new WebClient().DownloadFile("https://raw.githubusercontent.com/uBlockOrigin/uAssets/master/filters/privacy.txt", $"{AppPath}\\app\\src\\ublock-privacy.txt");
                new WebClient().DownloadFile("https://pgl.yoyo.org/adservers/serverlist.php?hostformat=adblock&showintro=1&mimetype=plaintext", $"{AppPath}\\app\\src\\peter-lowe-list.txt");

                Console.WriteLine("Patching...");
                var fileToPatch = $"{AppPath}\\app\\src\\createWindow.js";

                // copy adblocker lib to src
                File.WriteAllBytes($"{AppPath}\\app\\src\\adblocker.umd.min.js", Encoding.UTF8.GetBytes(Resources.adblocker_umd_min));

                // start writing our payload to createWindow.js
                IO.ModifyFileAtLine("session: true,", fileToPatch, 106);

                IO.ModifyFileAtLine(JS.FilterEngine, fileToPatch, 119);

                // optional features
                if (noupdate)
                    IO.ModifyFileAtLine("if (false) {", $"{AppPath}\\app\\src\\index.js", 267);
                if (autoguest)
                    IO.ModifyFileAtLine(JS.AutoGuest, $"{AppPath}\\app\\src\\preload.js", 18);

                Console.WriteLine("\r\n Patching complete! GLHF :)");
            } else {
                Console.WriteLine("app.asar not found!");
            }
            Console.ReadKey();
        }

    }
}