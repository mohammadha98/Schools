using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Schools.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Infra.Data.Context
{
  public  class SchoolsDbContext:DbContext
    {
        public SchoolsDbContext(DbContextOptions<SchoolsDbContext> options)
        :base(options)
        {

        }


        //test
        public virtual DbSet<Test> Tests { get; set; }
    }
}
