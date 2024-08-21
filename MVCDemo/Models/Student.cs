using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Student
    {
        [Required]
        public int SId { get; set; }
       
        [Required]
        public string Name { get; set;}
        
        [Required]
        public string Gender { get; set; }
        
        [Required]
        public int Age { get; set;}

        //[Required]
        //[DataType(DataType.PhoneNumber)]
        //[StringLength(25)]
        //public string Phone { get; set;}

        public Student()
        {
            
        }
        public Student(int Id, string name, string gender, int age)
        {
            SId = Id;
            Name = name;
            Gender = gender;
            Age = age;
        }
    }
}
