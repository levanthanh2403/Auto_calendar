using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.auto.Models
{
    public class backup_model
    {
        public string jobId { get; set; }
        public string jobName { get; set; }
        public string ipSource { get; set; }
        public string pathSource { get; set; }
        public string ipDestination { get; set; }
        public string pathDestination { get; set; }
        public string frequency { get; set; } = "";
        public string dateExec { get; set; }
        public string timeExec { get; set; }
        public string status { get; set; }
        public string cronExpression { get; set; }
        public int rowIndex { get; set; }
    }
}
