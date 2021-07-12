using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptingExamples
{
    public interface IReport
    {
        string CreateReportData();
    }

    public class StandardReport : IReport
    {
        List<string> rowData; 
        public StandardReport(List<string> rowData)
        {
            this.rowData = rowData;
        }
        public string CreateReportData()
        {
            string result = "";
            for(int i = 0; i < rowData.Count; i++)
            {
                result += string.Format("\n{0}: {1}", i, rowData[i]);
            }
            return result;
        }
    }
}
