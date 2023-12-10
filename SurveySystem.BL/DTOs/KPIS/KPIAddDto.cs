using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveySystem.BL.DTOs.KPIS
{
    public class KPIAddDto
    {
        public int KPINum { get; set; }
        public string KPIDescription { get; set; } = string.Empty;
        public int DepNo { get; set; }
        public bool MeasurementUnit { get; set; }
        public int TargetedValue { get; set; }
    }
}
