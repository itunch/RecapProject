﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
<<<<<<< HEAD
            Rental check = _rentalDal.GetRentedCar(rental.CarId);
            if (check==null || check.ReturnDate!=null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalListed);
            }
            return new ErrorResult(Messages.CarIsNotAvailable);
=======
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalListed);
>>>>>>> 4977b0e516147e61e8f7f8cb688d9acc09651d4c
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);

        }

        public IDataResult<Rental> GetById(int customerId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == customerId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
