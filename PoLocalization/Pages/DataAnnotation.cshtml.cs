#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace PoLocalization.Pages
{
    public class DataAnnotationModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        { }

        public void OnPost()
        { }

        public class InputModel
        {
            [Required(ErrorMessage = "Field mandatory")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Field mandatory")]
            [Range(18, 100, ErrorMessage = "Must be greater or equal than 18.")]
            public int Age { get; set; }
        }
    }
}
