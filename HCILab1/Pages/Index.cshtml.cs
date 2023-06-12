using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCILab1.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string EnterMessage { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostShowMessage()
        {
            Message = EnterMessage;
            return Page();
        }

        public IActionResult OnPostDefaultMessage1()
        {
            EnterMessage = "This is my default message";
            return Page();
        }

        public IActionResult OnPostDefaultMessage2()
        {
            EnterMessage = "This is another default message";
            return Page();
        }

        public IActionResult OnPostExecute(string action)
        {
            switch (action)
            {
                case "ClearField":
                    EnterMessage = string.Empty;
                    break;
                case "CopyText":
                    HttpContext.Session.SetString("Clipboard", EnterMessage);
                    break;
                case "PasteText":
                    EnterMessage = HttpContext.Session.GetString("Clipboard");
                    break;
            }

            return Page();
        }

        public IActionResult OnPostExit()
        {
            return Content("<script>window.close();</script>", "text/html");
        }
    }
}
