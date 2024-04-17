using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//CarAdd();
//CarTest();
//CarList();
RentTest();
static void RentTest()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    Rental rental = new Rental { CarId = 5, CustomerId = 1, RentDate = DateTime.Now };
    rentalManager.Add(rental);

    foreach (var rentals in rentalManager.GetAll().Data)
    {
        Console.WriteLine(rentals.Id + "/" + rentals.CarId + "/" + rentals.CustomerId + "/" + rentals.RentDate + "/" + rentals.ReturnDate.ToString()); ;
    }
    
}

static void CarList()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var cars = carManager.GetAll();
    if (cars.Success)
    {
        foreach (var car in cars.Data)
        {
            Console.WriteLine(car.ModelYear + "-" + car.CarName + "-" + car.DailyPrice);
            
        }
        Console.WriteLine(cars.Message);
    }
    else
    {
        Console.WriteLine(cars.Message);
    }
}


static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var result = carManager.GetCarDetails();
    if (result.Success)
    {
        foreach (var item in result.Data)
        {
            Console.WriteLine(item.BrandName + "/" + item.CarName + "/" + item.ColorName + "/" + item.DailyPrice);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}

static CarManager CarAdd()
{
    CarManager carManager = new CarManager(new EfCarDal());


    Car car = new Car { BrandId = 3, CarName = "Ayt", ColorId = 2, DailyPrice = 36, Description = "Bu nasıl araba", ModelYear = 2077 };
    var result=carManager.Add(car);
    if(result.Success)
    {
        Console.WriteLine(result.Message);
        CarList();
        
    }    
    else
    {
        Console.WriteLine(result.Message);

    }

    return carManager;

}