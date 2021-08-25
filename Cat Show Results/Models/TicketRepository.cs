using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat_Show_Results.Models
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _appDbContext;

        public TicketRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Ticket> AllTickets => _appDbContext.Tickets;
    }
}
