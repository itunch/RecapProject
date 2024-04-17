using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapDBContext>, IRentalDal
    {
        public Rental GetRentedCar(int carId)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result=context.Set<Rental>().Where(c=>c.CarId==carId&&c.ReturnDate==null);
                return result.SingleOrDefault();
            }
        }
    }
}
