using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain.Images
{
    public class ImageUploadModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public byte[] ImageFileBytes { get; set; }
        public string FileExtension { get; set; }
    }
}
