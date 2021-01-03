using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Enums.Event;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        public Task<IEnumerable<Event>> GetAllOrderedDesc();
    }
}
