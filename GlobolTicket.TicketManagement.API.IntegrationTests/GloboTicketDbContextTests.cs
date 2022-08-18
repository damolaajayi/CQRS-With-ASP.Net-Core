//using GloboTicket.TicketManagement.Domain.Entities;
//using GloboTicket.TicketManagement.Persistence;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Shouldly;
//using Xunit;

//namespace GlobolTicket.TicketManagement.API.IntegrationTests
//{
//    public class GloboTicketDbContextTests
//    {
//        private readonly GloboTicketDbContext _globolTicketDbContext;
//        private readonly Mock<ILoggedInUserService> _loggedInUsrrServiceMock;
//        private readonly string _loggedInUserId;

//        public GloboTicketDbContextTests()
//        {
//            var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

//            _loggedInUserId = "0000000-0000-0000-0000000000";
//            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
//            _globolTicketDbContext = new GloboTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
//        }

//        [Fact]
//        public async void Save_SetCreatedByProperty()
//        {
//            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event " };
//            _globolTicketDbContext.Events.Add(ev);
//            await _globolTicketDbContext.SaveChangesAsync();
//            ev.CreatedBy.ShouldBe(_loggedInUserId);
//        }

//    }
//}