using System;
using System.Collections.Generic;
using System.Text;
using Agile.Repository.Abstract.IRepository;
using Agile.Repository.Abstract.Models;

namespace Agile.Repository.Repository
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AgileContext dbContext) : base(dbContext)
        {
        }
    }
}
