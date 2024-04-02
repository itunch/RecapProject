using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


CarManager carManager = new CarManager(new EfCarDal());


Car car = new Car {BrandId=3,CarName="Tesla",ColorId=1,DailyPrice=0,Description="Bu nasıl araba",ModelYear=2000 };
carManager.Add(car);




foreach (var car2 in carManager.GetAll())
{
    Console.WriteLine(car2.CarName+""+car2.Description+" "+car2.ModelYear);
}
