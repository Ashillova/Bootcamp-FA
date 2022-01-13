using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FitnessApp.Models
{
    public class Class1
    {
        public class MyDbContext :DbContext
        {
            public DbSet<SignUp> NewUser { get; set; }
            public MyDbContext() : base("FitnessSQL")
            {

            }

        }
    }
}