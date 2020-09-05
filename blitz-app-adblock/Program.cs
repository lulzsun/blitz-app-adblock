using System;
using System.IO;
using asardotnet;

namespace blitz_app_adblock {
    class Program {
        private static string appPath =>
            $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Programs\\Blitz\\resources";
        static void Main(string[] args) {
            if (File.Exists($"{appPath}\\app.asar")) {
                Console.WriteLine($"{appPath}\\app.asar found!");
                var asar = new AsarArchive($"{appPath}\\app.asar");
                var extractor = new AsarExtractor();

                try {
                    Console.WriteLine("Extracting...");
                    extractor.ExtractAll(asar, $"{appPath}\\app\\", true);
                } catch (IOException) {
                    Console.WriteLine("Error extracting files! Make sure Blitz app is closed before trying again.");
                    Console.ReadKey();
                    return;
                }

                string fileToPatch = $"{appPath}\\app\\src\\createWindow.js";

                Console.WriteLine(fileToPatch);
                Console.WriteLine("Patching...");

                ModifyFileAtLine("session: true,", fileToPatch, 105);
                ModifyFileAtLine(

                    "const filter = {" +
                    "   urls: ['*://*.doubleclick.net/*']" +
                    "};" +

                    "windowInstance.webContents.session.webRequest.onBeforeRequest(filter, (details, callback) => {" +
                    "   callback({cancel: true});" +
                    "});"

                , fileToPatch, 118);

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
