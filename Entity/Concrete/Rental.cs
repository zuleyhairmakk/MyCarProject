﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Rental:IEntity
    {
        public int id { get; set; }
        public int CarId { get; set; }
        public string  RentDate { get; set; }
        public string  ReturnDate { get; set; }
    }
}
