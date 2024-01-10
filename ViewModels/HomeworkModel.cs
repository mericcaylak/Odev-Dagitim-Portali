using System.ComponentModel.DataAnnotations;

namespace uyg05_IdentityApp.ViewModels
{
    public class HomeworkModel

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ders Adı Giriniz!")]
        public string Name { get; set; }




        [Required(ErrorMessage = "Konu Giriniz!")]
        public string Description { get; set; }



        public bool Status { get; set; }



        [Required(ErrorMessage = "Puan Giriniz!")]
        public decimal Price { get; set; }
    }
}
