using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AspNetCore.Pages.Vue.Pages
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ListModel : PageModel
    {
        [JsonProperty]
        public List<string> EmailAddresses { get; set; }
            = new List<string>();
        
        public void OnGet()
        {
            EmailAddresses.Add("foo@example.com");
            EmailAddresses.Add("bar@example.com");
        }
    }
}
