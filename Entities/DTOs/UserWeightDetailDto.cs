﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserWeightDetailDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WeightId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Status { get; set; }
        public float Kilogram { get; set; }
    }
}