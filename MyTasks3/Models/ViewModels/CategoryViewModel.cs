using System.ComponentModel.DataAnnotations;

namespace MyTasks3.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int CatId { get; set; }
        public string Heading { get; set; }

        [Required(ErrorMessage = "Pole nazwa jest obowiązkowe")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Kolor")]
        public string ColorRgb { get; set; }
        public bool IsMainCategory { get; set; }
    }
}
