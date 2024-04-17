using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
<<<<<<< HEAD
        Rental GetRentedCar(int carId);
=======
>>>>>>> 4977b0e516147e61e8f7f8cb688d9acc09651d4c
    }
}
