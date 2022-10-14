﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserHeight : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HeightId { get; set; }
    }
}
