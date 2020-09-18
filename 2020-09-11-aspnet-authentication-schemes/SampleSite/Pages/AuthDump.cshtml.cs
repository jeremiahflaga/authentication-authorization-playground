using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleSite.Pages
{
    public class AuthDumpModel : PageModel
    {
        private readonly AuthenticationService authenticationService;

        public AuthDumpModel(IAuthenticationService authenticationService)
        {
            this.authenticationService = (AuthenticationService)authenticationService;
        }

        public IEnumerable<AuthenticationScheme> Schemes { get; set; }
        public AuthenticationScheme DefaultAuthenticate { get; set; }
        public AuthenticationScheme DefaultChallenge { get; set; }
        public AuthenticationScheme DefaultForbid { get; set; }
        public AuthenticationScheme DefaultSignIn { get; set; }
        public AuthenticationScheme DefaultSignOut { get; set; }

        public async Task OnGet()
        {
            Schemes = await authenticationService.Schemes.GetAllSchemesAsync();
            DefaultAuthenticate = await authenticationService.Schemes.GetDefaultAuthenticateSchemeAsync();
            DefaultChallenge = await authenticationService.Schemes.GetDefaultChallengeSchemeAsync();
            DefaultForbid = await authenticationService.Schemes.GetDefaultForbidSchemeAsync();
            DefaultSignIn = await authenticationService.Schemes.GetDefaultSignInSchemeAsync();
            DefaultSignOut = await authenticationService.Schemes.GetDefaultSignOutSchemeAsync();
        }
    }
}
