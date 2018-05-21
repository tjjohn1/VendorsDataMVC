using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Web.Hosting;
using CasinoDataMVC.Models;

namespace CasinoDataMVC.DataProcessing
{
    public class csvTo2dArray
    {
        private string currentDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            return dateTime.ToString("dd/MM/yyyy");
        }
        
        private string uploadCSV(String path)
        {
            //var filePath = HostingEnvironment.MapPath(path);

            string data = File.ReadAllText(path);

            return data;
        }

        public DayTotalsModel csvToArray(string path)
        {
            string[] pathBreaks = path.Split('/');
            string vendor = pathBreaks[pathBreaks.Length - 1].Split('_')[0];
            Console.WriteLine("Vendor" + vendor);
            string csvData = uploadCSV(path);
            Console.WriteLine("Path" + path);
            
            csvData = csvData.Replace('\n', '\r');
            
            string[] csvLines = csvData.Split(new char[] { '\r'},
                StringSplitOptions.RemoveEmptyEntries);

            int numRows = csvLines.Length;
            int numColumns = csvLines[0].Split(',').Length;
            
            DayTotalsModel vendorDayTotals = new DayTotalsModel();
            vendorDayTotals.date = currentDate();
            vendorDayTotals.vendor = vendor;
            TerminalModel[] terminals = new TerminalModel[numRows];

            int grandTotal = 0;

            for (int i = 0; i < terminals.Length; i++)
            {
                string[] rowLine = csvLines[i].Split(',');

                for (int j = 0; j < numColumns; j++)
                {
                    int total = 0;
                    Console.WriteLine(rowLine[j]);
                    switch (j)
                    {
                            case 0:
                                terminals[i].terminal = Convert.ToInt32(rowLine[j]);
                                break;
                            case 1:
                                int ones = Convert.ToInt32(rowLine[j]);
                                terminals[i].ones = ones;
                                total += ones;
                                break;
                            case 2:
                                int fives = Convert.ToInt32(rowLine[j]);
                                terminals[i].fives = fives;
                                total += fives*5;
                                break;
                            case 3:
                                int tens = Convert.ToInt32(rowLine[j]);
                                terminals[i].tens = tens;
                                total += tens*10;
                                break;
                            case 4:
                                int twenties = Convert.ToInt32(rowLine[j]);
                                terminals[i].twenties = twenties;
                                total += twenties*20;
                                break;
                            case 5:
                                int fifties = Convert.ToInt32(rowLine[j]);
                                terminals[i].fifties = fifties;
                                total += fifties*50;
                                break;
                            case 6:
                                int hundreds = Convert.ToInt32(rowLine[j]);
                                terminals[i].hundreds = hundreds;
                                total += hundreds*100;
                                break;
                    }
                    terminals[i].total = total;
                }
                grandTotal += terminals[i].total;
            }
            vendorDayTotals.grand_total = grandTotal;
            return vendorDayTotals;
        }
    }
}