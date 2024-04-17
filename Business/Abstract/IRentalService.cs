using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int customerId);
<<<<<<< HEAD
        //IDataResult<Rental> GetRentedCar(int carId);
=======
>>>>>>> 4977b0e516147e61e8f7f8cb688d9acc09651d4c
    }
}
