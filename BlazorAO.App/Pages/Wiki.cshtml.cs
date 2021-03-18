using BlazorAO.App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorAO.Pages
{
    public class WikiModel : PageModel
    {        
        public WikiModel(WikiReader wikiReader)
        {
            WikiReader = wikiReader;
        }

        public WikiReader WikiReader { get; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public void OnGet()
        {
            if (Id != 0) WikiReader.LoadTopic(Id);
        }
    }
}
