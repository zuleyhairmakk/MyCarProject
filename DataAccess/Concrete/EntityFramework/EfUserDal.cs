﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
  public  class EfUserDal: EfEntityRepositoryBase<Users, CarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(Users user)
        {
            using (var context = new CarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim {
                                 Id = operationClaim.Id, 
                                 Name = operationClaim.Name 
                             };
                return result.ToList();

            }
        }
    }
}
