using System.ComponentModel.DataAnnotations;

namespace SampleApp.Dal.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}