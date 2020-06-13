using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lcmsgapi.Models
{
    public class LCMsgContext : DbContext
    {
        public LCMsgContext(DbContextOptions<LCMsgContext> options)
            : base(options)
        {
        }

        public DbSet<LCMsg> LCMsgs { get; set; }
    }
}
