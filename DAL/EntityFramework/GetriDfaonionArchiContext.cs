using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework;

public partial class GetriDfaonionArchiContext : DbContext
{
    public GetriDfaonionArchiContext()
    {
    }

    public GetriDfaonionArchiContext(DbContextOptions<GetriDfaonionArchiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }    
}
