using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using project.Models;

namespace project.Services
{
    public class MickeyMouseService : IActorService
    {
        public Task<List<Actor>> GetActors(){
            Actor[] family = { new Actor(){
                        Id = 98,
                        FirstName = "Mickey",
                        LastName = "Mouse",
                        DateOfBith = new DateTime (1928, 1, 2),
                        CountryCode = "USA"
                    },
                    new Actor(){
                        FirstName = "Minnie",
                        LastName = "Mouse",
                        DateOfBith = new DateTime (1931, 1, 2),
                        Id = 97,
                        CountryCode = "USA"    
                    }};
            List<Actor> listAct = family.ToList();
            return Task.FromResult(listAct);
        }
    }
}        