using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystemApi.RequestModels
{
    public class AppointmentUpdateModel
    {
        public int doc_id { get; set; }
        public int pat_id { get; set; }

    }
}
