using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.CarId
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             join cu in context.Customers
                             on re.CustomerId equals cu.CustomerId
                             join us in context.Users
                             on cu.UserId equals us.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = re.RentalId,
                                 BrandName = br.BrandName,
                                 CarName = ca.CarName,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate =re.ReturnDate,
                             };
                return result.ToList();
            }
        }
    }
}
