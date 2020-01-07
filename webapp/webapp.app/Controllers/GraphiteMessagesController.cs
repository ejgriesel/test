using fundstrading.services;
using fundstrading.web.Models.Adapters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fundstrading.web.Controllers
{
    public class GraphiteMessageController : Controller
    {
        private readonly ISearchApiRequestService _searchApiRequestService;

        public GraphiteMessageController(ISearchApiRequestService searchApiRequestService)
        {
            _searchApiRequestService = searchApiRequestService;
        }

        public async Task<ActionResult> Search()
        {
            var data = await _searchApiRequestService.SearchAsync(100);
            var viewModel = data.ToViewModel();
            return View(viewModel);
        }
    }
}
