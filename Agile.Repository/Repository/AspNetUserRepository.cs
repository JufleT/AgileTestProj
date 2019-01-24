using System;
using System.Collections.Generic;
using System.Text;
using Agile.Repository.Abstract.IRepository;
using Agile.Repository.Abstract.Models;

namespace Agile.Repository.Repository
{
    public class AspNetUserRepository : BaseRepository<AspNetUser>, IAspNetUserRepository
    {
        public AspNetUserRepository(AgileContext dbContext) : base(dbContext)
        {
        }
    }
}
