using System;
namespace NZWalks.API.Models.Domain
{
    /// <summary>
    /// Summary description for Region
    /// </summary>
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }

    }
}
