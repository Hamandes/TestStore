using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain.Dtos
{
    public class UserModel
    {
        [Required]
        public long ApplicationUserId { get; set; }
        [Required]
        [StringLength(150)]
        public string FullName { get; set; }
        [Required]
        [StringLength(150)]
        public string EmailAddress { get; set; }
        [Required]
        public DateTimeOffset LastLogIn { get; set; }
        [Required]
        public Guid AzureAdB2cobjectId { get; set; }
        public string Role { get; set; }
    }
}
