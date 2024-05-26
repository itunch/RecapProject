using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDBContext>, IRentalDal
    {
        public Rental GetRentedCar(int carId)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = context.Set<Rental>().Where(c => c.CarId == carId && c.ReturnDate == null);
                return result.SingleOrDefault();
            }
        }       

        public List<RentalDetailDto> GetRentAllDto()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join u in context.Users on r.CustomerId equals u.Id
                             select new RentalDetailDto { Id=r.Id,CarName=c.CarName,BrandName = b.Name, FullName = u.FirstName +" "+ u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
