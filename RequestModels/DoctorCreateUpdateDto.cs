using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystemApi.RequestModels
{
    public class DoctorCreateUpdateDto
    {

        
        
        public string doc_first_name { get; set; }
        
        public string doc_last_name { get; set; }
        
        public string doc_ph_no { get; set; }
      
        public string doc_address { get; set; }
    }
}
