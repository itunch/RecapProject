﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        Rental GetRentedCar(int carId);
        List<RentalDetailDto> GetRentAllDto();
    }
}
