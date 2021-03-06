﻿using System.Collections.Generic;
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

        public Dictionary<string, int> GetVolunteerRegistrationByTimeslot()
        {
            var result = new Dictionary<string, int>();
            var volunteers = dbContext.RegistrationRecords;

            foreach (var volunteer in volunteers.Where(x => !string.IsNullOrEmpty(x.PreferredTimeSlot) 
                                                    && x.PreferredTimeSlot != "Please select a time slot"))
            {
                if (result.ContainsKey(volunteer.PreferredTimeSlot))
                {
                    result[volunteer.PreferredTimeSlot]++;
                }
                else
                {
                    result[volunteer.PreferredTimeSlot] = 1;
                }
            }

            return result;
        }
    }
}
