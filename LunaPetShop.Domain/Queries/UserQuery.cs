using System;
using System.Linq.Expressions;
using LunaPetShop.Domain.Entities;

namespace LunaPetShop.Domain.Queries
{
    public static class UserQuery
    {
      public static Expression<Func<User,bool>>  GetUserByEmail(string Email){
          return x => x.Email == Email;
      }
    }
}