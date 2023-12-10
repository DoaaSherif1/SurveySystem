using Microsoft.AspNetCore.Mvc;
using SurveySystem.BL.DTOs.KPIS;
using SurveySystem.BL.Manager;

namespace SurveySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKPISManager _kpisManager;
        public HomeController(IKPISManager kpisManager)
        {
            _kpisManager = kpisManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(KPIAddDto kpiDto)
        {
            var newKpi = _kpisManager.Add(kpiDto);
            return CreatedAtAction("GetByKPINum", new { Kpi = newKpi }, new { m = "Added Successfuly" });
            
        }

        [HttpPut]
        public ActionResult Update(KPIUpdateDto kpiDto)
        {
            var isFound = _kpisManager.Update(kpiDto);
            if (!isFound)
            {
                return NotFound();
            }

            return NoContent(); //204 Success with not content
        }




        [HttpDelete]
        [Route("{kpiNum}")]
        public ActionResult Delete(int kpiNum)
        {
            _kpisManager.Delete(kpiNum);
            return NoContent();
        }

    }
}
