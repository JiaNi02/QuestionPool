using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuestionPool.Models;

namespace QuestionPool.Pages.question
{
    public class DisplayQuestionModel : PageModel
    {

        public List<string>? SelectedData { get; set; }

        public void OnGet(string? selectedData)
        {

            if (selectedData != null)
            {
                SelectedData = JsonConvert.DeserializeObject<List<string>>(selectedData);
            }
        }
    }
}
