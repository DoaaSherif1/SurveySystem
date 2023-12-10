using SurveySystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SurveySystem.DAL.Repo
{
    public interface IKPISRepo
    {
        IEnumerable<TbiKPI> GetAll();
        List<TbiKPI>? GetByDepNo(int dep);
        TbiKPI? GetByKPINum(int kpiNum);
        void Add(TbiKPI entity);
        void Update(TbiKPI entity);
        void Delete(TbiKPI entity);

        int SaveChanges();
    }
}
