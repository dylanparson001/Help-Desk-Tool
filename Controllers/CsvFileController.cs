using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Views;
using Serilog;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Controllers
{
    public class CsvFileController : BaseController
    {
        private ClearContainerController _clearContainerController = new ClearContainerController();
        private readonly ILogger _logger = Log.ForContext<Igps>();

        private static List<string> sourceFilePaths = new List<string>();

        // Specify the desired output zip file
        private static string zipFilePath = "";

        private static string currentDateString = "";

        private static string zoutFileNameOnly = "";
        private static string zoutCsvFileName = "";

        private static string snapshotFileNameOnly = "";
        private static string snapshotCsvFileName = "";

        private static string zoutLocationCsvFileNameOnly = "";
        private static string zoutLocationCsvFileName = "";

        private static string snapshotLocationCsvFileNameOnly = "";
        private static string snapshotLocationCsvFileName = "";

        private static string ClearContainerFilePath = "";
        private static string siteId = ConfigurationManager.AppSettings.Get("siteId");


        public static string GetCurrentFolderPath()
        {
            return ConfigurationManager.AppSettings.Get("clearContainerPath");
        }

        public async Task SaveCsvFilesAndZip(string txtZoutCount, List<string> txtZoutContainersToClear,
            List<string> txtSnapshotContainers, string txtSnapshotCount, bool saveSnapshot,
            List<IGPS_DEPOT_GLN> listIgpsDepotGln)
        {
            siteId = ConfigurationManager.AppSettings.Get("siteId");

            var rnd = new Random();

            int rand = rnd.Next(1, 100);
            await SaveContainersFromList(txtZoutCount, txtZoutContainersToClear, rand, listIgpsDepotGln);
            if (saveSnapshot)
            {
                await SaveSnapShot(txtSnapshotCount, txtSnapshotContainers, rand);
            }

            SaveToArchive(saveSnapshot, rand);
        }


        public async Task SaveContainersFromList(string txtNumToBeDeleted,
            List<string> txtContainersToClear, int rand, List<IGPS_DEPOT_GLN> listIgpsDepotGln)
        {
            ClearContainerFilePath = GetCurrentFolderPath();
            var grais = txtNumToBeDeleted;

            if (!Directory.Exists($"{ClearContainerFilePath}"))
            {
                Directory.CreateDirectory(ClearContainerFilePath);
            }

            // List from db
            //var igpsDepotGln = await _clearContainerController.GetContainersFromList(txtContainersToClear);
            var igpsDepotLocation = await _clearContainerController.GetLocationContainersFromList(txtContainersToClear);
            // check for null 
            if (listIgpsDepotGln == null)
            {
                return;
            }

            // Generate csv
            var csv = new StringBuilder();
            var csv2 = new StringBuilder();


            DateTime currentDate = DateTime.Now;

            // Date will be part of file name
            currentDateString = currentDate.Date.ToLongDateString();

            zoutFileNameOnly = $"{siteId} IGPS_DEPOT_GLN ZOUT {currentDateString} {grais} GRAIs";
            zoutCsvFileName = $"{ClearContainerFilePath}/{zoutFileNameOnly}";


            zoutLocationCsvFileNameOnly =
                $"{siteId} IGPS_DEPOT_LOCATION ZOUT {currentDateString} {igpsDepotLocation.Count} CONTAINERS";
            zoutLocationCsvFileName = $"{ClearContainerFilePath}/{zoutLocationCsvFileNameOnly}";


            sourceFilePaths.Add(zoutCsvFileName);
            sourceFilePaths.Add(zoutLocationCsvFileName);


            foreach (IGPS_DEPOT_GLN gln in listIgpsDepotGln)
            {
                var first = gln.Gln;
                var second = gln.Grai;
                var third = gln.Date_Time;

                var newLine = string.Format($"{first},{second},{third}");
                csv.AppendLine(newLine);
            }

            try
            {
                // if the file exists insert a random number to differentiate it
                if (File.Exists($"{zoutCsvFileName}.csv"))
                {
                    zoutCsvFileName = $"{zoutCsvFileName} ({rand})";
                    zoutFileNameOnly = $"{zoutFileNameOnly} ({rand})";
                }

                // Using statement for StreamWriter to ensure proper disposal
                using (var streamWriter = new StreamWriter($"{zoutCsvFileName}.csv"))
                {
                    streamWriter.Write(csv.ToString());
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving results");
                Console.WriteLine(ex);
            }


            foreach (IGPS_DEPOT_LOCATION gln in igpsDepotLocation)
            {
                var first = gln.SiteId;
                var second = gln.Gln;
                var fourth = gln.Status;
                var fifth = gln.Date_Time;
                var sixth = gln.Description;
                var seventh = gln.Visible;
                var eith = gln.SubStatus;
                var ninth = gln.SkuType;

                var newLine =
                    string.Format($"{first},{second}, {fourth}, {fifth}, {sixth}, {seventh}, {eith}, {ninth}");
                csv2.AppendLine(newLine);
            }

            try
            {
                // if the file exists insert a random number to differentiate it
                if (File.Exists($"{zoutLocationCsvFileName}.csv"))
                {
                    zoutLocationCsvFileName = $"{zoutLocationCsvFileName} ({rand})";
                }

                using (var streamWriter = new StreamWriter($"{zoutLocationCsvFileName}.csv"))
                {
                    streamWriter.Write(csv2.ToString());
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error Occured");
            }

            listIgpsDepotGln.Clear();
        }

        public async Task SaveSnapShot(string txtNumToBeDeleted,
            List<string> txtContainersToClear, int rand)
        {
            siteId = ConfigurationManager.AppSettings.Get("siteId");

            ClearContainerFilePath = GetCurrentFolderPath();
            var grais = txtNumToBeDeleted;


            if (!Directory.Exists($"{ClearContainerFilePath}"))
            {
                Directory.CreateDirectory(ClearContainerFilePath);
            }

            var stringOfContainers = ConcatStringFromList(txtContainersToClear);
            // List from db
            //var igpsDepotGln = await _clearContainerController.GetContainersFromList(txtContainersToClear);
            var igpsDepotGln = await _igpsDepotGlnRepository.ReadContainersFromList(stringOfContainers);
            var igpsDepotLocation = await _igpsDepotLocationRepository.ReadAllContainers();
            int igpsDepotLocationCount = igpsDepotLocation.Count;

            // check for null
            if (igpsDepotGln == null)
            {
                return;
            }

            // Generate csv
            var csv = new StringBuilder();
            var csv2 = new StringBuilder();

            snapshotFileNameOnly = $"{siteId} IGPS_DEPOT_GLN SNAPSHOT {currentDateString} {grais} GRAIs";
            snapshotCsvFileName = $"{ClearContainerFilePath}/{snapshotFileNameOnly}";

            snapshotLocationCsvFileNameOnly =
                $"{siteId} IGPS_DEPOT_LOCATION SNAPSHOT {currentDateString} {igpsDepotLocationCount} CONTAINERS";
            snapshotLocationCsvFileName = $"{ClearContainerFilePath}/{snapshotLocationCsvFileNameOnly}";

            sourceFilePaths.Add(snapshotCsvFileName);
            sourceFilePaths.Add(snapshotLocationCsvFileName);

            if (igpsDepotGln == null) return;

            foreach (IGPS_DEPOT_GLN gln in igpsDepotGln)
            {
                var first = gln.Gln;
                var second = gln.Grai;
                var third = gln.Date_Time;

                var newLine = string.Format($"{first},{second},{third}");
                csv.AppendLine(newLine);
            }

            try
            {
                // if the file exists insert a random number to differentiate it
                if (File.Exists($"{snapshotCsvFileName}.csv"))
                {
                    snapshotCsvFileName = $"{snapshotCsvFileName} ({rand})";
                    snapshotFileNameOnly = $"{snapshotFileNameOnly} ({rand})";
                }

                using (var streamWriter = new StreamWriter($"{snapshotCsvFileName}.csv"))
                {
                    streamWriter.Write(csv.ToString());
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error Occured");
            }

            foreach (IGPS_DEPOT_LOCATION gln in igpsDepotLocation)
            {
                var first = gln.SiteId;
                var second = gln.Gln;
                var third = gln.Gln96;
                var fourth = gln.Status;
                var fifth = gln.Date_Time;
                var sixth = gln.Description;
                var seventh = gln.Visible;
                var eighth = gln.SubStatus;

                var newLine =
                    string.Format($"{first},{second}, {third}, {fourth}, {fifth}, {sixth}, {seventh}, {eighth}");
                csv2.AppendLine(newLine);
            }

            try
            {
                // if the file exists insert a random number to differentiate it
                if (File.Exists($"{snapshotLocationCsvFileName}.csv"))
                {
                    snapshotLocationCsvFileName = $"{snapshotCsvFileName} ({rand})";
                    snapshotLocationCsvFileNameOnly = $"{snapshotLocationCsvFileNameOnly} ({rand})";
                }

                using (var streamWriter = new StreamWriter($"{snapshotLocationCsvFileName}.csv"))
                {
                    streamWriter.Write(csv2.ToString());
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error Occured");
            }

            igpsDepotGln.Clear();
            GC.Collect();
        }


        private static void SaveToArchive(bool snapshot, int rand)
        {
            ClearContainerFilePath = GetCurrentFolderPath();

            if (snapshot)
            {
                if (File.Exists(Path.Combine(ClearContainerFilePath, $"{snapshotFileNameOnly}.zip")))
                {
                    snapshotFileNameOnly = $"{snapshotFileNameOnly} ({rand})";
                }


                using (var archive = ZipFile.Open(Path.Combine(ClearContainerFilePath, $"{snapshotFileNameOnly}.zip"),
                           ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile($"{zoutCsvFileName}.csv", $"{zoutFileNameOnly}.csv");
                    archive.CreateEntryFromFile($"{snapshotCsvFileName}.csv", $"{snapshotFileNameOnly}.csv");
                    archive.CreateEntryFromFile($"{snapshotLocationCsvFileName}.csv",
                        $"{snapshotLocationCsvFileNameOnly}.csv");
                    archive.CreateEntryFromFile($"{zoutLocationCsvFileName}.csv", $"{zoutLocationCsvFileNameOnly}.csv");
                }
            }
            else
            {
                if (File.Exists(Path.Combine(ClearContainerFilePath, $"{zoutFileNameOnly}.zip")))
                {
                    zoutFileNameOnly = $"{zoutFileNameOnly} ({rand})";
                }

                using (var archive = ZipFile.Open(Path.Combine(ClearContainerFilePath, $"{zoutFileNameOnly}.zip"),
                           ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile($"{zoutCsvFileName}.csv", $"{zoutFileNameOnly}.csv");
                    archive.CreateEntryFromFile($"{zoutLocationCsvFileName}.csv", $"{zoutLocationCsvFileNameOnly}.csv");
                }
            }

            if (File.Exists($"{snapshotCsvFileName}.csv"))
            {
                try
                {
                    File.Delete($"{snapshotCsvFileName}.csv");
                    File.Delete($"{snapshotLocationCsvFileName}.csv");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            try
            {
                File.Delete($"{zoutCsvFileName}.csv");
                File.Delete($"{zoutLocationCsvFileName}.csv");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task SaveCsvOfIndividualGrais(string txtZoutCount, List<string> txtGraisToClear, string glnClear,
            int rand)
        {
            ClearContainerFilePath = GetCurrentFolderPath();
            var grais = txtZoutCount;

            if (!Directory.Exists($"{ClearContainerFilePath}"))
            {
                Directory.CreateDirectory(ClearContainerFilePath);
            }

            // List from db
            var igpsDepotGln = await _igpsDepotGlnRepository.ReadFromGraiList(txtGraisToClear);


            // check for null 
            if (igpsDepotGln == null)
            {
                return;
            }

            // Generate csv
            var csv = new StringBuilder();
            DateTime currentDate = DateTime.Now;

            // Date will be part of file name
            currentDateString = currentDate.Date.ToLongDateString();
            zoutFileNameOnly = $"{siteId} ZOUT {glnClear} {currentDateString} {grais} GRAIs";

            //zoutCsvFileName = Path.Combine(ClearContainerFilePath, zoutFileNameOnly);
            zoutCsvFileName = $"{ClearContainerFilePath}/{zoutFileNameOnly}";

            foreach (IGPS_DEPOT_GLN gln in igpsDepotGln)
            {
                var first = gln.Gln;
                var second = gln.Grai;
                var third = gln.Date_Time;

                var newLine = string.Format($"{first},{second},{third}");
                csv.AppendLine(newLine);
            }

            try
            {
                // if the file exists insert a random number to differentiate it
                if (File.Exists($"{zoutCsvFileName}.csv"))
                {
                    zoutCsvFileName = $"{zoutCsvFileName} ({rand})";
                }

                // Using statement for StreamWriter to ensure proper disposal
                using (var streamWriter = new StreamWriter($"{zoutCsvFileName}.csv"))
                {
                    streamWriter.Write(csv.ToString());
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving results");
                Console.WriteLine(ex);
            }

            igpsDepotGln.Clear();
        }    }
}