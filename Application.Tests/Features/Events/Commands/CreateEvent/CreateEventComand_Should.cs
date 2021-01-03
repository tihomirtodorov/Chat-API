using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence.Contexts;
using Persistence.Repositories;
using Event = Domain.Entities.Event;

namespace Application.Tests.Features.Events.Commands.CreateEvent
{
    [TestClass]
    public class CreateEventComand_Should
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

            var sut = new EventRepository(actAndAssertContext);

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
