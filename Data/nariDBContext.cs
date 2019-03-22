using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace narilearsi.Data
{
    public class NariDBContext : DbContext
    {
        public NariDBContext(DbContextOptions<NariDBContext> options)
            : base(options)
        { 
        
        }
    }
}
