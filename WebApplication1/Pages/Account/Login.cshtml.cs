using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebApplication1.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
            //this.Credential = new Credential { Name = "admin" };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if(Credential.Name == "admin" && Credential.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@example.com"),
                    new Claim("Admin", "true")

                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", principal);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }

    public class Credential
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
