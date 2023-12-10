using Microsoft.EntityFrameworkCore;
using SurveySystem.DAL.Data.Context;
using SurveySystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SurveySystem.DAL.Repo
{
    public class KPISRepo : IKPISRepo
    {
        private readonly KPISContext _context;
        public KPISRepo(KPISContext context)
        {
            _context = context;
        }

        public IEnumerable<TbiKPI> GetAll()
        {
            return _context.Set<TbiKPI>().AsNoTracking();
        }

        public List<TbiKPI> GetByDepNo(int dep)
        {
            return _context.Set<TbiKPI>().Where(kpi => kpi.DepNo == dep).ToList();
        }
        public TbiKPI? GetByKPINum(int kpiNum)
        {
            return _context.Set<TbiKPI>().Find(kpiNum);
        }

        public void Add(TbiKPI entity)
        {
            _context.Set<TbiKPI>().Add(entity);
        }

        public void Update(TbiKPI entity)
        {
        }

        public void Delete(TbiKPI entity)
        {
            _context.Set<TbiKPI>().Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }
}
