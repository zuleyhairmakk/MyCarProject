﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class FindeksScoreDto : IDto
    {
        public int CustomerFindeksScore { get; set; }
        public int CarMinFindeksScore { get; set; }
    }
}
