using System;
using System.Collections.Generic;

namespace REST_API.Models
{
    public partial class Battery
    {
        public long Id { get; set; }
        public long building_id { get; set; }
        public long? employee_id { get; set; }

        public string battery_status { get; set; }
        public string certificate_of_operations { get; set; }
        public string information { get; set; }
        public string notes { get; set; }

        public DateTime? date_of_commissioning { get; set; }
        public DateTime? date_of_last_inspection { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
