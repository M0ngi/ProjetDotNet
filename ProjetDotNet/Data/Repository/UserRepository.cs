﻿using ProjetDotNet.Data.Context;
using ProjetDotNet.Models;
using System.Linq.Expressions;

namespace ProjetDotNet.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _applicationDbContext) : base(_applicationDbContext)
        {
        }
    }
}