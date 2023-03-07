using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwordLMS.Web.Models;

namespace SwordLMS.Web.Data
{
    public class SwordLMSWebContext : DbContext
    {
        public SwordLMSWebContext (DbContextOptions<SwordLMSWebContext> options)
            : base(options)
        {
        }

        public DbSet<SwordLMS.Web.Models.Category> Category { get; set; } = default!;
    }
}
