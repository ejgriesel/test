using System.Collections.Generic;
using System.Threading.Tasks;
using fundstrading.domain.Models;
using fundstrading.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace fundstrading.web.Controllers
{
    public class ProductMappingController : Controller
    {
        private readonly IProductMappingService _productMappingService;

        public ProductMappingController(IProductMappingService productMappingService)
        {
            _productMappingService = productMappingService;
        }

        // GET: ProductMapping
        public async Task<IActionResult> Index()
        {
            return View(await _productMappingService.ProductMappingList().ConfigureAwait(false));
        }

        // GET: ProductMapping/Details/5
        async public Task<ActionResult> Details(long id)
        {
            var productMapping = await _productMappingService.FindProductMapping(id).ConfigureAwait(false);
            if (productMapping == null)
            {
                return NotFound();
            }

            return View(productMapping);
        }

        // GET: ProductMapping/Create
        public ActionResult Create()
        {
            PopulateChannelsDropDownList();
            return View();
        }

        // POST: ProductMapping/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Productmapping productmapping)
        {
            if (ModelState.IsValid)
            {
                _productMappingService.CreateProductMapping(productmapping);
                return RedirectToAction(nameof(Index));
            }
            return View(productmapping);
        }

        // GET: ProductMapping/Edit/5
        async public Task<ActionResult> Edit(long id)
        {
            var productMapping = await _productMappingService.FindProductMapping(id).ConfigureAwait(false);
            if (productMapping == null)
            {
                return NotFound();
            }

            PopulateChannelsDropDownList(productMapping.Channelid);

            return View(productMapping);
        }

        // POST: ProductMapping/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> Edit(long id, IFormCollection collection)
        {
            var productMapping = await _productMappingService.FindProductMapping(id).ConfigureAwait(false);
            if (productMapping == null)
            {
                return NotFound();
            }

            productMapping.Incoming = collection["Incoming"];
            productMapping.Outgoing = collection["Outgoing"];
            productMapping.Channelid = int.Parse(collection["Channelid"].ToString());

            _productMappingService.UpdateProductMapping(productMapping);

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductMapping/Delete/5
        async public Task<ActionResult> Delete(long id)
        {
            var productMapping = await _productMappingService.FindProductMapping(id).ConfigureAwait(false);
            if (productMapping == null)
            {
                return NotFound();
            }

            PopulateChannelsDropDownList(productMapping.Channelid);

            return View(productMapping);
        }

        // POST: ProductMapping/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> Delete(long id, IFormCollection collection)
        {
            var productMapping = await _productMappingService.FindProductMapping(id).ConfigureAwait(false);
            if (productMapping == null)
            {
                return NotFound();
            }

            _productMappingService.DeleteProductMapping(productMapping);

            return RedirectToAction(nameof(Index));
        }

        private void PopulateChannelsDropDownList(object selectedChannel = null)
        {
            IEnumerable<Channel> channelsQuery = _productMappingService.ChannelList();

            ViewBag.Channelid = new SelectList(channelsQuery, "Id", "Description", selectedChannel);
        }
    }
}