using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MyTasks3.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Tasks = new Collection<Task>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Kolor")]
        public string ColorRGB { get; set; }
        public bool IsMainCategory { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public ApplicationUser User { get; set; }
    }
}
