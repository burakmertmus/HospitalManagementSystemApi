// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalManagementSystemApi.Models
{
    public partial class Appointment
    {
        [Key]
        public int appointment_id { get; set; }
        public int doc_id { get; set; }
        public int pat_id { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime appointment_date { get; set; }
    }
}