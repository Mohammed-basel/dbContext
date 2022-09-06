using System.ComponentModel.DataAnnotations;

namespace dbContext
{
    public class Company
    {
        [Key]
        public int Id { get; set; }


        public string? Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public ICollection<Employee>? Employee
        {
            get; set;
        }
    }
}

