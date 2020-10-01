using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleSite.Pages
{
    [Authorize(AuthenticationSchemes = "cookie2")]
    public class Page2Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
