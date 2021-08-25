using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystemApi.RequestModels
{
    public class PatientCreateUpdateModel
    {
       
        public string pat_first_name { get; set; }
        public string pat_last_name { get; set; }
        public string pat_insurance_no { get; set; }
        public string pat_ph_no { get; set; }
        public string pat_address { get; set; }
    }
}
