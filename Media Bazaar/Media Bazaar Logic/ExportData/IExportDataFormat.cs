using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_Logic.ExportData
{
    public interface IExportDataFormat
    {
        public string GetCSVString();
    }
}
