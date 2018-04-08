using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApp.Dal.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}