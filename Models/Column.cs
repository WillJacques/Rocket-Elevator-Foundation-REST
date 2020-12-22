using System;
using System.Collections.Generic;

namespace REST_API.Models
{
    public partial class Column
    {
        public long Id { get; set; }
        public long battery_id { get; set; }
        public int number_of_floors_served { get; set; }

        public string column_type { get; set; }
        public string column_status { get; set; }
        public string information { get; set; }
        public string notes { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}