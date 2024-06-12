﻿using System;
using System.Collections.Generic;

namespace LockNLoad.Service.Entities
{
    public partial class User
    {
        public User()
        {
            UserAppointments = new HashSet<UserAppointment>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? GenderId { get; set; }
        public int? Age { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public string? PasswordHash { get; set; }
        public string? Salt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<UserAppointment> UserAppointments { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}