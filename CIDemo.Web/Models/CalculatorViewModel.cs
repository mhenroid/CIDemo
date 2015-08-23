using System.ComponentModel.DataAnnotations;

namespace CIDemo.Web.Models
{
    public class CalculatorViewModel
    {
        [Required(ErrorMessage = "A value for n is required")]
        [Range(0, 100000)]
        public int N { get; set; }

        public string Result { get; set; }
    }
}