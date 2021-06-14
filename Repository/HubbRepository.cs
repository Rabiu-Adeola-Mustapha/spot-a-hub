
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class HubbRepository : RepositoryBase<Hubb>, IHubbRepository
    {
        public HubbRepository(AppDbContext context) : base(context)
        {

        }
        public void CreateHubb(Hubb hubb)
        {
            Create(hubb);
        }

        public void DeleteSingleHubbId(Guid id)
        {
            DeleteSingleHubbId(id);
        }


        public IEnumerable<Hubb> GetHubs(bool trackChanges)
        {
            var getHubs = FindAll(trackChanges).AsNoTracking().ToList();

            if (getHubs == null)
            {
                return new List<Hubb>();
            }

            return getHubs;
        }

     

        public void UpdateHubb(Hubb hubb)
        {
            Update(hubb);
        } 
        
        public async Task<Hubb> GetHubbById(Guid id, bool trackchanges)
        {
            var getHub = await FindByCondition(h => h.HubbId == id, trackchanges)
                .AsNoTracking()              
                .SingleOrDefaultAsync();

            if (getHub == null)
            {
                return null;
            }

            return getHub;
        }

        public async Task<Hubb> GetHubbByName(string name, bool trackchanges)
        {
            var getHub = await FindByCondition(h => h.Name == name, trackchanges)
                 .AsNoTracking()
                 .SingleOrDefaultAsync();

            if (getHub == null)
            {
                return null;
            }

            return getHub;
        }

        public async Task<IEnumerable<Hubb>> GetHubbsByState(string state, bool trackchanges)
        {
            var getHub = await FindByCondition(h => h.State == state, trackchanges)
                .AsNoTracking()
                .ToListAsync();

            if (getHub == null || getHub.Count == 0)
            {
                return null;
            }

            return getHub;
        }

        public async Task<IEnumerable<Hubb>> GetHubbsByTag(string tag, bool trackchanges)
        {
            var getHub = await FindByCondition(h => h.Tags == tag, trackchanges)
               .AsNoTracking()
               .ToListAsync();

            if (getHub == null || getHub.Count == 0)
            {
                return null;
            }

            return getHub;
        }

        public async Task<Hubb> CheckIfHubExistsByName(string name, bool trackchanges)
        {
            //come and take a look at this logic again mr man
            var getHub = await FindByCondition(h => h.Name.Equals(name) || h.Name.Contains(name), trackchanges)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (getHub == null)
            {
                return null;
            }

            

            return getHub;
        }
    }
}
