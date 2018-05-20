using System;
using System.IO;
using System.Web.Hosting;

namespace CasinoDataMVC.DataProcessing
{
    public class csvTo2dArray
    {
        private string uploadCSV(String path)
        {
            var filePath = HostingEnvironment.MapPath(path);

            string data = File.ReadAllText(filePath);

            return data;
        }

        public string[,] csvToArray(string csvData)
        {
            csvData = csvData.Replace('\n', '\r');
            
            string[] csvLines = csvData.Split(new char[] { '\r'},
                StringSplitOptions.RemoveEmptyEntries);

            int numRows = csvLines.Length;
            int numColumns = csvLines[0].Split(',').Length;


            string[,] csvFinal = new string[numRows, numColumns];

            for (int i = 0; i < numRows; i++)
            {
                string[] rowLine = csvLines[i].Split(',');

                for (int j = 0; j < numColumns; j++)
                {
                    csvFinal[i, j] = rowLine[j];
                }
            }
            return csvFinal;
        }
    }
}