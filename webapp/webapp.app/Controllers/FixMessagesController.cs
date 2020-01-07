using fundstrading.domain.Services;
using fundstrading.web.Models.Adapters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace fundstrading.web.Controllers
{
    public class FixMessageController : Controller
    {
        private readonly ISearchFixMessageService _searchFixMessageService;

        public FixMessageController(ISearchFixMessageService searchFixMessageService)
        {
            _searchFixMessageService = searchFixMessageService;
        }

        public async Task<ActionResult> Search()
        {
            var data = await _searchFixMessageService.SearchAsync(100);
            return View(data.ToViewModel());
        }
    }
}
