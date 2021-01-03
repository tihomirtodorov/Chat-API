using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence.Contexts;
using Persistence.Repositories;
using Event = Domain.Entities.Event;

namespace Application.Tests.Features.Events.Queries.GetAllEventsBy
{
    [TestClass]
    public class GetAllEventsBy_Should
    {
        [TestMethod]
        public async Task Add_Event_To_Database()
        {
            var databaseName = nameof(Add_Event_To_Database);

            var options = Utilities.GetOptions(databaseName);

            Utilities.FillContextWithData(options);

            await using var actAndAssertContext = new ApplicationDbContext(options);

            var sut = new EventRepository(actAndAssertContext);

            var events = await sut.GetAllOrderedDesc();

            var orderedEventsFromContext = actAndAssertContext.Events.OrderByDescending(x => x.CreatedOn);

            Assert.IsTrue(actAndAssertContext.Events.Count() == events.Count());
            Assert.AreEqual(events.FirstOrDefault()?.Id, orderedEventsFromContext.FirstOrDefault()?.Id);
        }
    }
}
