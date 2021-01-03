using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence.Contexts;

namespace Persistence.Tests.Repositories.EventRepository
{
    [TestClass]
    public class GetAllOrderedDesc_Should
    {
        [TestMethod]
        public async Task Return_Correct_Count_Of_Ordered_Events()
        {
            var databaseName = nameof(Return_Correct_Count_Of_Ordered_Events);

            var options = Utilities.GetOptions(databaseName);

            Utilities.FillContextWithData(options);

            await using var actAndAssertContext = new ApplicationDbContext(options);

            var sut = new Persistence.Repositories.EventRepository(actAndAssertContext);

            var events = await sut.GetAllOrderedDesc();

            var orderedEventsFromContext = actAndAssertContext.Events.OrderByDescending(x => x.CreatedOn);

            Assert.IsTrue(actAndAssertContext.Events.Count() == events.Count());
            Assert.AreEqual(events.FirstOrDefault()?.Id, orderedEventsFromContext.FirstOrDefault()?.Id);
        }
    }
}