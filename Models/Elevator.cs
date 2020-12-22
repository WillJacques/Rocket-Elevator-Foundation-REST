using System;
using System.Collections.Generic;

namespace REST_API.Models
{
    public partial class Elevator
    {
        public long Id { get; set; }
        public long column_id { get; set; }

        public string serial_number { get; set; }
        public string model { get; set; }
        public string type_of_building { get; set; }
        public string status { get; set; }
        public string inspection_certificate { get; set; }
        public string information { get; set; }
        public string notes { get; set; }

        public DateTime? commissioning_date { get; set; }
        public DateTime? last_inspection_date { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
