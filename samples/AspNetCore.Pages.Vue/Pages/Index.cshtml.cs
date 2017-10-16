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
    public class IndexModel : PageModel
    {
        [JsonProperty]
        public string Message { get; set; }
        
        public void OnGet()
        {
            Message = "Hello Vue!";
        }
    }
}
