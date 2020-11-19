using System;

namespace REST_API.Models
{
    public class intervention
    {
        public long? id { get; set; }
        public long? battery_id { get; set; }
        public long? building_id { get; set; }
        public long? column_id { get; set; }
        public long? customer_id { get; set; }
        public long? elevator_id { get; set; }
        public long? employee_id { get; set; }
        public long? author { get; set; }
        public string result { get; set; }
        public string report { get; set; }
        public string status { get; set; }
        public DateTime? intervention_start { get; set; }
        public DateTime? intervention_stop { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}