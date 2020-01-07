using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fundstrading.web.Models;
using fundstrading.domain.Services;
using fundstrading.repositories;
using fundstrading.common;
using System.Linq;

namespace fundstrading.web.Controllers
{
    public class SearchOrderController : Controller
    {
        private readonly ISearchFixMessageService _searchFixMessageService;
        private readonly IApiRequestRepository _apiRequestRepository;
        private readonly IApiResponseRepository _apiResponseRepository;

        public SearchOrderController(ISearchFixMessageService searchFixMessageService, IApiRequestRepository apiRequestRepository, IApiResponseRepository apiResponseRepository)

        {
            _searchFixMessageService = searchFixMessageService;
            _apiRequestRepository = apiRequestRepository;
            _apiResponseRepository = apiResponseRepository;
        }

        // GET: SearchOrderController
        public async Task<IActionResult> Index()
        {
            string selectedOrderId = null;
            string selectedChannel = "";
            int selectedChannelId = 0;
            string selectedDate = DateTime.Today.AddDays(-5).ToString("yyyy-MM-dd");

            // get params or set defaults
            if (Request.Method == "POST")
            {
                selectedOrderId = Request.Form["tbClOrderId"];
                selectedDate = Request.Form["tbDate"];
                selectedChannel = Request.Form["ddlChannels"];
                //The value of the enumeration is returned and not the display text
                if (selectedChannel != "")
                {
                    selectedChannelId = Convert.ToInt32(selectedChannel);
                }
            }

            // convert string date to DateTime
            if (!DateTime.TryParse(selectedDate, out DateTime messDate))
            {
                selectedDate = DateTime.Today.ToString("yyyy-MM-dd");
                messDate = DateTime.Today.Date;
            }
            ViewData["tbDate"] = selectedDate;
            ViewData["tbClOrderId"] = selectedOrderId;
            ViewData["clOrderId"] = selectedOrderId;

            IEnumerable<domain.Models.Channel> servicechannels = await _searchFixMessageService.GetChannels();
            var channels = servicechannels.Select(x =>
            {
                return new SelectListItem { Value = x.Id.ToString(), Text = x.Description };
            });
            ViewData["Channels"] = channels;

            SearchOrderViewModel data = new SearchOrderViewModel
            {
                FixMessage = await _searchFixMessageService.SearchOrderAsync(messDate, selectedOrderId, selectedChannelId)
            };
            
            // get commandId and tag values
            // replace SOH characters with carriage returns
            //TODO: Can one clordid have multiple commandids?
            var registId = "";
            foreach (var message in data.FixMessage)
            {
                var buffer = message.Raw.Split(Constants.SOH + Constants.TAG513);
                if (buffer.Length > 1)
                {
                    registId = buffer[1].Split(Constants.SOH)[0];
                }
            }

            ViewData["registId"] = registId;

            data.FixMessage = await _searchFixMessageService.SearchOrderAndRegistIdAsync(messDate, selectedOrderId, registId, selectedChannelId);
            var commandId = new List<long>();
            foreach (var message in data.FixMessage)
            {
                commandId.Add(message.Commandid);
                message.Raw = message.Raw.Replace(Constants.SOH, Constants.NEWLINE);
            }

            // populate apiRequest
            data.ApiRequest = await _apiRequestRepository.SearchOrderAsync(commandId);
            foreach (var message in data.ApiRequest)
            {
                message.Raw = JSONIndented(message.Raw);
            }

            // populate apiResponse
            data.ApiResponse = await _apiResponseRepository.SearchOrderAsync(commandId);
            foreach (var message in data.ApiResponse)
            {
                message.Raw = JSONIndented(message.Raw);
            }

            return View(data);

            // pretty print json
            string JSONIndented(string json)
            {
                try
                {
                    dynamic parsedJson = JsonConvert.DeserializeObject(json);
                    return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                }
                catch
                {
                    return json;
                }
            }
        }
    }
}
