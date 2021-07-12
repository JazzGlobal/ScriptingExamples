using System;
using System.Collections.Generic;

namespace ScriptingExamples.csscripts.reporting
{
    public class TitledReport : IReport
    {
        List<string> rowData;
        string title;

        public TitledReport(string title, List<string> rowData)
        {
            this.rowData = rowData;
            this.title = title;
        }
        public string CreateReportData()
        {
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

        private void CleanData()
        {
            this.rowData = new List<string>();
        }
    }
}
