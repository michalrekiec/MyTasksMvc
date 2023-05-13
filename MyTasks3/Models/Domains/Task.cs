using System;
using System.ComponentModel.DataAnnotations;

namespace MyTasks3.Models.Domains
{
    public class Task
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "Nazwa")]
        public string Title { get; set; }

        [MaxLength(250)]
        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }

        [Display(Name = "Zrealizuj")]
        public bool IsExecuted { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Data")]
        public DateTime? Term { get; set; }

        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
    }
}
