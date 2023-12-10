using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveySystem.DAL.Data.Models
{
    public class TbiKPI
    {
        [Key]
        public int KPINum { get; set; }
        public string KPIDescription { get; set; } = string.Empty;
        public int DepNo { get; set; }
        public bool MeasurementUnit { get; set; }
        public int TargetedValue { get; set; }
    }
}
