using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Fever
    {
        //data annotation

        [Display(Name = "Body Temperatuer")]
        public double BTemp { get; set; }
        public string TestResult { get; set; }
    }
}
