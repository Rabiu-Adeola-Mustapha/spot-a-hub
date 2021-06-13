
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IHubbRepository
    {
        void CreateHubb(Hubb hubb);
        void UpdateHubb(Hubb hubb);
        void DeleteSingleHubbId(Guid id);
        Task<Hubb> GetHubbById(Guid id, bool trackchanges);
    }
}
