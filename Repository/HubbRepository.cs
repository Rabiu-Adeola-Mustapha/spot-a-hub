
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
    }
}
