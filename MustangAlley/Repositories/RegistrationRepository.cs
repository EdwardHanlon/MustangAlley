using System.Collections.Generic;
using System.Linq;
using MustangAlley.ViewModels.Registration;
using MustangAlley.Models;

namespace MustangAlley.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private RegistrationContext dbContext;

        public RegistrationRepository(RegistrationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveRegistration(RegistrationViewModel model)
        {
            dbContext.RegistrationRecords.Add(model);
            dbContext.SaveChanges();
        }

        //public CarRegistrationCountViewModel GetCarCountByYear()
        //{
        //    var carDictionary = new Dictionary<string, int>();
        //    var registeredCars = dbContext.RegistrationRecords.Where(x => x.Year != null && x.Year > 0).OrderBy(ord => ord.Year).ToList();

        //    foreach (var car in registeredCars)
        //    {
        //        if (carDictionary.ContainsKey(car.Year.ToString()))
        //        {
        //            carDictionary[car.Year.ToString()]++;
        //        }
        //        else
        //        {
        //            carDictionary[car.Year.ToString()] = 1;
        //        }
        //    }

        //    return new CarRegistrationCountViewModel { RegistrationByYear = carDictionary};
        //}
    }
}
