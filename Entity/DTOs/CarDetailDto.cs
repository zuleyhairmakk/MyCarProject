﻿
using Core.Entities;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
  public   class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string ModelYear { get; set; }
        public string Description { get; set; }
        public int MinFindeksScore { get; set; }
        public List<CarImages> ImagePaths { get; set; }

    }
}
