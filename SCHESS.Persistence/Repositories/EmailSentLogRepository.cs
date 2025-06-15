using Microsoft.EntityFrameworkCore;
using SCHESS.Domain.Entity.System;
using SCHESS.Domain.Repositories;
using SCHESS.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHESS.Persistence.Repositories
{
    public class EmailSentLogRepository : Repository<EmailSentLog>, IEmailSentLogRepository
    {
        public EmailSentLogRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
