using SurveySystem.BL.DTOs.KPIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveySystem.BL.Manager
{
    public interface IKPISManager
    {
        List<KPIReadDto> GetAll();
        List<KPIReadDto> GetByDepNo(int dep);
        KPIReadDto? GetByKPINum(int kpiNum);

        int Add(KPIAddDto kpi);
        bool Update(KPIUpdateDto kpi);
        void Delete(int dep);
    }
}
