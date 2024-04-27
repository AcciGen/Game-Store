using Game_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Application.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<SystemRequirement> SystemRequirements { get; set; }

        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
