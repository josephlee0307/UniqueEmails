using System.ComponentModel.DataAnnotations;

namespace UniqueEmails.Dtos
{
    public class EmailForEmailStringDto
    {
        [Required]
        public string EmailString { get; set; }
    }
}