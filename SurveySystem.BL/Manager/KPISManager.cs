using SurveySystem.BL.DTOs.KPIS;
using SurveySystem.DAL.Data.Models;
using SurveySystem.DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SurveySystem.BL.Manager
{
    public class KPISManager: IKPISManager
    {
        private readonly IKPISRepo _kpisRepo;

        public KPISManager(IKPISRepo kpisRepo)
        {
            _kpisRepo = kpisRepo;
        }

        public List<KPIReadDto> GetAll()
        {
            IEnumerable<TbiKPI> kpisFromDb = _kpisRepo.GetAll();
            return kpisFromDb.Select(t => new KPIReadDto
            {
                KPINum = t.KPINum,
                KPIDescription = t.KPIDescription,
                DepNo = t.DepNo,
                MeasurementUnit= t.MeasurementUnit,
                TargetedValue = t.TargetedValue
            }).ToList();
        }

        public List<KPIReadDto> GetByDepNo(int dep)
        {
            var kpi = _kpisRepo.GetByDepNo(dep);

            return kpi.Select(t => new KPIReadDto
            {
                KPINum = t.KPINum,
                KPIDescription = t.KPIDescription,
                DepNo = t.DepNo,
                MeasurementUnit = t.MeasurementUnit,
                TargetedValue = t.TargetedValue
            }).ToList();
        }
        public KPIReadDto? GetByKPINum(int kpiNum)
        {
            var kpi = _kpisRepo.GetByKPINum(kpiNum);
            if (kpi == null)
            {
                return null;
            }

            return new KPIReadDto
            {
                KPINum = kpi.KPINum,
                KPIDescription = kpi.KPIDescription,
                DepNo = kpi.DepNo,
                MeasurementUnit = kpi.MeasurementUnit,
                TargetedValue = kpi.TargetedValue
            };
        }

        public int Add(KPIAddDto kpiDto)
        {
            var kpi = new TbiKPI
            {
                KPINum = kpiDto.KPINum,
                KPIDescription = kpiDto.KPIDescription,
                DepNo = kpiDto.DepNo,
                MeasurementUnit = kpiDto.MeasurementUnit,
                TargetedValue = kpiDto.TargetedValue
            };
            _kpisRepo.Add(kpi);
            _kpisRepo.SaveChanges();

            return kpi.KPINum;
        }

        public bool Update(KPIUpdateDto kpiDto)
        {
            var kpiFromDb = _kpisRepo.GetByKPINum(kpiDto.KPINum);
            if (kpiFromDb == null)
            {
                return false;
            }

            kpiFromDb.KPINum = kpiDto.KPINum;
            kpiFromDb.KPIDescription = kpiDto.KPIDescription;
            kpiFromDb.DepNo = kpiDto.DepNo;
            kpiFromDb.MeasurementUnit = kpiDto.MeasurementUnit;
            kpiFromDb.TargetedValue = kpiDto.TargetedValue;

            _kpisRepo.Update(kpiFromDb);
            _kpisRepo.SaveChanges();
            return true;
        }

        public void Delete(int kpiNum)
        {
            var kpiFromDb = _kpisRepo.GetByKPINum(kpiNum);
            if (kpiFromDb == null)
            {
                return;
            }

            _kpisRepo.Delete(kpiFromDb);
            _kpisRepo.SaveChanges();
        }
    }
}
