
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IHubbRepository
    {
        void CreateHubb(Hubb hubb);
        void UpdateHubb(Hubb hubb);
        IEnumerable<Hubb> GetHubs(bool trackChanges);
        void DeleteSingleHubbId(Guid id);
        Task<Hubb> GetHubbByName(string name, bool trackchanges);
        Task<Hubb> GetHubbByNameSpecial(string name, bool trackchanges);
        Task<IEnumerable<Hubb>> GetHubbsByState(string state, bool trackchanges);
        Task<IEnumerable<Hubb>> GetHubbsByTag(string tag, bool trackchanges);

        
    }
}
