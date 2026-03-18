using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL.Model
{
    public class LogCleanerSettings
    {
        public int DaysToKeep { get; set; }
        public string[]? Folders { get; set; }
    }
}
