﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace konzolna
{
    public class Person
    {



        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }

        public Person()
        {
            Id =Guid.NewGuid();
        }


    }
}