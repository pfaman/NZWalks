using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "CODE HAS TO BE MINIMUM 3 CHARACTER")]
        [MaxLength(5, ErrorMessage = "CODE HAS TO BE MAXIMUM 5 CHARACTER")]
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string? RegionImageUrl { get; set; }
    }
}
