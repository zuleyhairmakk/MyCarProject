﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
   public  class Customer:IEntity
    {
        public int CustomerId{ get; set; }
        public int  UserId{ get; set; }
        public string  CompanyName { get; set; }
        public int FindeksScore { get; set; }
    }
}
