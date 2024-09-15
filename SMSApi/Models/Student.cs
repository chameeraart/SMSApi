using System.ComponentModel;

namespace SMSApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Sex { get; set; }
        public string? IdNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Category { get; set; } // Primary, Middle School, Upper School

        [DefaultValue(false)]
        public bool Status { get; set; }

        public void CategorizeByAge()
        {
            var age = DateTime.Now.Year - Birthday.Year;
            Category = age switch
            {
                >= 6 and <= 10 => "Primary",
                >= 11 and <= 15 => "Middle School",
                >= 16 and <= 19 => "Upper School",
                _ => "After School"
            };
        }

    }
}
