using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence.Contexts;

namespace Persistence.Tests.Repositories.EventRepository
{
    [TestClass]
    public class AddAsync_Should
    {
        [TestMethod]
        public async Task Add_Event_To_Database()
        {
            var databaseName = nameof(Add_Event_To_Database);

            var options = Utilities.GetOptions(databaseName);

            await using var actAndAssertContext = new ApplicationDbContext(options);

            var sender = "George";
            var receiver = "Kate";
            var message = "George enters the room";
            var id = Guid.Parse("20d81e7c-3bc5-4694-bfe8-773c5c638bfb");

            var tempEvent = new Event
            {
                Id = id,
                CreatedOn = DateTime.Parse("2021-01-02T12:15:01.453616Z"),
                Sender = sender,
                Receiver = receiver,
                EventType = EventType.Enter,
                Message = message
            };

            var sut = new Persistence.Repositories.EventRepository(actAndAssertContext);

            Assert.IsTrue(!actAndAssertContext.Events.Any());

            await sut.AddAsync(tempEvent);
            var singleEvent = actAndAssertContext.Events.FirstOrDefault();

            Assert.IsTrue(actAndAssertContext.Events.Count() == 1);
            Assert.IsTrue(singleEvent?.Id == id);
            Assert.IsTrue(singleEvent?.Sender == sender);
            Assert.IsTrue(singleEvent?.Receiver == receiver);
            Assert.IsTrue(singleEvent?.Message == message);
            Assert.IsTrue(singleEvent?.EventType == EventType.Enter);
        }
    }
}
