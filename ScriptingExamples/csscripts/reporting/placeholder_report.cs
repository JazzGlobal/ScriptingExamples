//css_ref SqlConnector.dll

using System;
using System.Data;
using System.Collections.Generic;
using SqlConnector;

namespace ScriptingExamples.csscripts.reporting
{
    public class AlarmsReport : IReport
    {
        List<string> rowData;
        string title;


        public AlarmsReport(string title, List<string> rowData)
        {
            this.rowData = rowData;
            this.title = "Alarms Report";
        }

        public string CreateReportData()
        {

            var dt = QueryForAlarmData();
            PrintDataTable(dt);

            DateTime d = DateTime.Now;
            string result = "";
            result += string.Format("\t\t\t\t\t{0}", title);
            for (int i = 0; i <= rowData.Count - 1; i++)
            {
                string appendedValue = (i % 2 == 0) ? "Even Line" : "Odd Line";
                result += string.Format("\nLine {0}: \t\t\t{1} \t {2} {3}", i, d, rowData[i], appendedValue);
            }
            return result;
        }

        private DataTable QueryForAlarmData()
        {
            SqlConnector.SQLConnector conn = new SQLConnector("");
            conn.InitializeConnection();

            conn.Open();

            DataTable table = new DataTable();
            List<DataRow> queried_data = new List<DataRow>();

            var command = conn.CreateCommand("USE [202107SCAN] SELECT TOP 10 * FROM SCANS;");
            var reader = conn.ReadResults(command);


            for (int i = 0; i < reader.FieldCount; i++)
            { // Populate data table with columns.
                table.Columns.Add(new DataColumn(reader.GetName(i)));
            }

            while (reader.Read())
            {
                var row = new object[reader.FieldCount];
                reader.GetSqlValues(row);
                table.Rows.Add(row);
            }
            conn.Close();
            return table;
        }


        private void PrintDataTable(DataTable table)
        {
            foreach (DataColumn column in table.Columns)
            {
                foreach (DataRow row in table.Rows)
                {
                    Console.Write("\t{0}\t", row[column]);

                }
                Console.WriteLine();
            }
        }
    }
}
