using Microsoft.AspNetCore.Mvc;

namespace MatchStats.Controllers
{
    public class MatchStatsController : Controller
    {
        [Route("")]
        [Route("MatchStats")]
        [Route("MatchStats/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
