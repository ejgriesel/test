using fundstrading.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace fundstrading.web.Models
{
    public class SearchOrderViewModel
    {
        public IEnumerable<Fixmessage> FixMessage { get; set; }
        public IEnumerable<Apirequest> ApiRequest { get; set; }
        public IEnumerable<Apiresponse> ApiResponse { get; set; }
    }
}
