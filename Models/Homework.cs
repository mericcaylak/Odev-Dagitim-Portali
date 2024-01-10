using System.ComponentModel.DataAnnotations;

namespace uyg05_IdentityApp.Models

{
    public class Homework
    {
        public int Id { get; set; }
        
        [Display(Name = "Ders Adı")]

        [Required(ErrorMessage = "Lütfen Ders Adı Giriniz!")]
        public string Name { get; set; }

        [Display(Name = "Ödev Konusu")]

        [Required(ErrorMessage = "Lütfen Ödev Konusu Giriniz!")]
        public string Description { get; set; }

        [Display(Name = "Ödev Durumu")]

        [Required(ErrorMessage = "Lütfen Ödev Durumu Giriniz!")]
        public bool Status { get; set; }
        
        [Display(Name = "Puan")]

        [Required(ErrorMessage = "Lütfen Puan Giriniz!")]
        public decimal Price { get; set; }
    }
}




