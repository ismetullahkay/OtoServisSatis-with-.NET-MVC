﻿using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Concrete
{
    public class UserRepository : Repository<Kullanici>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<Kullanici>> GetCustomUserList()
        {
            return await _dbSet.AsNoTracking().Include(x => x.Rol).ToListAsync();
        }

        public async Task<List<Kullanici>> GetCustomUserList(Expression<Func<Kullanici, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Rol).ToListAsync();
        }
    }
}
