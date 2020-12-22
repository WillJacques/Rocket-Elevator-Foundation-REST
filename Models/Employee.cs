using System;
using System.Collections.Generic;

namespace REST_API.Models
{
    public partial class Employee
    {
        public long Id { get; set; }
        public long? admin_user_id { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}