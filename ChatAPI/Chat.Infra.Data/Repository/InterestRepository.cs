﻿using Chat.Domain.Models;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repository
{
    public class InterestRepository : Repository<Interest>
    {
        public InterestRepository(ChatDbContext context) : base(context)
        {
        }

        protected async override Task<IEnumerable<Interest>> GetAll()
        {
            return await DbSet
                .AsNoTracking()
                .Include(x => x.UserInterests)
                    .ThenInclude(x => x.User)
                .ToListAsync();
        }
    }
}
