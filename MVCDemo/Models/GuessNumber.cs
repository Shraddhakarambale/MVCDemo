using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class GuessNumber
    {
        public int SecretNum { get; set; }

        [Display(Name = "Your guess")]
        public int GuessNum { get; set; }
        public string Msg { get; set; }

       
    }
}
