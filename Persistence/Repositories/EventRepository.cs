using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Event;
using Application.Enums.Event;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext): base (dbContext)
        {
        }

        protected override IQueryable<Event> Query => dbContext.Events.AsQueryable();
        public async Task<IEnumerable<Event>> GetAllOrderedDesc()
        {
            return await Query
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();
        }
    }
}
