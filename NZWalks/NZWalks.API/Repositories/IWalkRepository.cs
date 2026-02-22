using NZWalks.API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {

        Task<Walk> CreateAsync(Walk walk);
        // Task<List<Walk>> GetAllAsync(); // Commnetd for Filter Testing

        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
        string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);
        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);

        Task<Walk?> DeleteByIdAsync(Guid id);

    }
}
