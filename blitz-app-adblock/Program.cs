using System;
using System.IO;
using System.Net;
using System.Text;
using asardotnet;
using blitz_app_adblock.Properties;

namespace blitz_app_adblock {
    class Program {
        private static string appPath =>
            $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Programs\\Blitz\\resources";
        static void Main(string[] args) {
            if (File.Exists($"{appPath}\\app.asar")) {
                Console.WriteLine("app.asar found!");

                try {
                    Console.WriteLine("Extracting...");
                    var asar = new AsarArchive($"{appPath}\\app.asar");
                    var extractor = new AsarExtractor();
                    extractor.ExtractAll(asar, $"{appPath}\\app\\", true);
                } catch (IOException) {
                    Console.WriteLine("Error extracting files! Make sure Blitz app is closed before trying again.");
                    Console.ReadKey();
                    return;
                }
            
                Console.WriteLine("Downloading Easylists...");
                new WebClient().DownloadFile("https://easylist.to/easylist/easylist.txt", $"{appPath}\\app\\src\\easylist.txt");
                new WebClient().DownloadFile("https://easylist.to/easylist/easyprivacy.txt", $"{appPath}\\app\\src\\easyprivacy.txt");

                Console.WriteLine("Patching...");
                string fileToPatch = $"{appPath}\\app\\src\\createWindow.js";

                // copy adblocker lib to src
                File.WriteAllBytes($"{appPath}\\app\\src\\adblocker.umd.min.js", Encoding.UTF8.GetBytes(Resources.adblocker_umd_min));
                // start writing our payload to createWindow.js
                ModifyFileAtLine("session: true,", fileToPatch, 105);
                ModifyFileAtLine(

                "try {" +
                    "const fs = require('fs');" +
                    "const { FiltersEngine, Request} = require('./adblocker.umd.min.js');" +
                    "const filters = fs.readFileSync(require.resolve('./easylist.txt'), 'utf-8') + fs.readFileSync(require.resolve('./easyprivacy.txt'), 'utf-8');" +
                    "const engine = FiltersEngine.parse(filters);" +

                    "windowInstance.webContents.session.webRequest.onBeforeRequest({ urls:['*://*/*']}, (details, callback) => {" +
                        "const { match } = engine.match(Request.fromRawDetails({ url: details.url}));" +
                        "if (match == true) {" +
                            "log.info('BLOCKED:', details.url);" +
                            "callback({cancel: true});" +
                        "} else {" +
                            "callback({cancel: false});" +
                        "}" +
                    "});" +
                "} catch (error) {" +
                    "log.error(error);" +
                "}"

                , fileToPatch, 118);
                // end file writes

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Patching complete! GLHF :)");
            } else {
                Console.WriteLine("app.asar not found!");
            }
            Console.ReadKey();
        }

        public static void ModifyFileAtLine(string newText, string fileName, int line_to_edit) {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
            Console.WriteLine(fileName + ">>> Writing to line " + line_to_edit + ": " + newText);
        }
    }
}