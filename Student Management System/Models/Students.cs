using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Students
    {
        [Key] public int StudentId { get; set; }
        [Required] public string? StudentName { get; set; }
        [Required] public string? Email { get; set; }
        [Required] public string? Course { get; set; }
        public DateTime DOJ { get; set; }
    }
}
