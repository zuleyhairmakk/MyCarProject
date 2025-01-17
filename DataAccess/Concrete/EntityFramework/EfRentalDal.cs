﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.id,
                                 CarName = c.CarName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }


        public FindeksScoreDto GetFindeksScores(int carId, int customerId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars.Where(c => c.CarId == carId)
                             from cu in context.Customers.Where(cu => cu.CustomerId == customerId)
                             select new FindeksScoreDto
                             {
                                 CarMinFindeksScore = c.MinFindeksScore,
                                 CustomerFindeksScore = cu.FindeksScore,
                             };

                return result.SingleOrDefault();
            };
        }


    }
}
