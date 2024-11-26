using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Warehouse.RazorWebUI.Pages
{
    public class ArtistModel : PageModel
    {
        public int Id { get; private set; }

        // Свойство для хранения результата вычислений
        public int ResultId { get; private set; }

        public void OnGet(int id)
        {
            Id = id;
            PerformCalculations(Id);
        }

        private void PerformCalculations(int id)
        {
            if (id < 10)
            {
                ResultId = id * id; // Присваиваем результат в свойство
            }
            else
            {
                ResultId = id;
            }
        }
    }
}