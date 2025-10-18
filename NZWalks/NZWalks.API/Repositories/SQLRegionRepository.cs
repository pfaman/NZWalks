using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }


        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            // Find the existing region by ID
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            // If region doesn't exist, return null
            if (existingRegion == null)
            {
                return null;
            }

            // Update properties
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            // Return the updated region
            return existingRegion;
        }


        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
                return null;

            _dbContext.Regions.Remove(existingRegion);
            await _dbContext.SaveChangesAsync();

            return existingRegion;
        }

    }
}
