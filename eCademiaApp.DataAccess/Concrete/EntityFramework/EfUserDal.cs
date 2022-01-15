﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, eCademiaAppContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new eCademiaAppContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public UserDetailDto GetUserDetail(string userMail)
        {
            using (var context = new eCademiaAppContext())
            {
                var result =
                    (from u in context.Users
                     join c in context.Customers
                         on u.Id equals c.UserId
                     where u.Email == userMail
                     select new UserDetailDto
                     {
                         Id = u.Id,
                         CustomerId = c.Id,
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         Email = u.Email,
                         CompanyName = c.CompanyName
                     }).First();
                return result;
            }
        }
    }
}