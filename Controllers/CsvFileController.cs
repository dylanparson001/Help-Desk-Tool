using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iGPS_Help_Desk.Models;

namespace iGPS_Help_Desk.Controllers
{
    public class CsvFileController : BaseController
    {
        private ClearContainerController _clearContainerController = new ClearContainerController();
        public async void SaveContainersFromList(string txtNumToBeDeleted, string ClearContainerFilePath,
            List<string> txtContainersToClear, string siteId)
        {
            var rnd = new Random();
            var grais = txtNumToBeDeleted;

            var igpsDepotGln = new List<IGPS_DEPOT_GLN>();

            if (!Directory.Exists($"{ClearContainerFilePath}"))
            {
                Directory.CreateDirectory(ClearContainerFilePath);
            }

            // List from db
            igpsDepotGln = await _clearContainerController.GetContainersFromList(txtContainersToClear);

            // check for null
            if (igpsDepotGln == null)
            {
                return;
            }

            // Generate csv
            var csv = new StringBuilder();
            DateTime currentDate = new DateTime();

            currentDate = DateTime.Now;

            // Date will be part of file name
            string currentDateString = currentDate.Date.ToLongDateString();
            string csvFileName = $"{ClearContainerFilePath}\\{siteId} ZOUT {currentDateString} {grais} GRAIs";

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
                if (File.Exists($"{csvFileName}.csv"))
                {
                    csvFileName = $"{csvFileName} ({rnd.Next(1, 100)})";
                }
                File.WriteAllText($"{csvFileName}.csv", csv.ToString());
                MessageBox.Show($"File Saved Successfully to {csvFileName}", "ZOUT File Saved Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving results");
                Console.WriteLine(ex);
            }


        }
        public async void SaveSnapShot(string txtNumToBeDeleted, string ClearContainerFilePath,
            List<string> txtContainersToClear, string siteId)
        {
            var rnd = new Random();
            var grais = txtNumToBeDeleted;

            var igpsDepotGln = new List<IGPS_DEPOT_GLN>();

            if (!Directory.Exists($"{ClearContainerFilePath}"))
            {
                Directory.CreateDirectory(ClearContainerFilePath);
            }

            // List from db
            igpsDepotGln = await _clearContainerController.GetContainersFromList(txtContainersToClear);

            // check for null
            if (igpsDepotGln == null)
            {
                return;
            }

            // Generate csv
            var csv = new StringBuilder();
            DateTime currentDate = new DateTime();

            currentDate = DateTime.Now;

            // Date will be part of file name
            string currentDateString = currentDate.Date.ToLongDateString();
            string csvFileName = $"{ClearContainerFilePath}\\{siteId} SNAPSHOT {currentDateString} {grais} GRAIs";

            if (igpsDepotGln == null) return;

            foreach (IGPS_DEPOT_GLN gln in igpsDepotGln)
            {
                var first = gln.Gln;
                var second = gln.Grai;
                var third = gln.Date_Time;

                var newLine = string.Format($"{first},{second},{third}");
                csv.AppendLine(newLine);
            }

            Console.WriteLine("debug");
            try
            {
                // if the file exists insert a random number to differentiate it
                if (File.Exists($"{csvFileName}.csv"))
                {
                    csvFileName = $"{csvFileName} ({rnd.Next(1, 100)}).csv";
                }
                File.WriteAllText($"{csvFileName}.csv", csv.ToString());
                MessageBox.Show($"File Saved Successfully to {csvFileName}", "Snapshot File Saved Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving results");
                Console.WriteLine(ex);
            }

        }
    }
}