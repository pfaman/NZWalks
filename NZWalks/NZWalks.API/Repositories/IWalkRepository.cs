using NZWalks.API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {

        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();

        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);

        Task<Walk?> DeleteByIdAsync(Guid id);

    }
}
