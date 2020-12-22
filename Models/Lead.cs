using System;
using System.Collections.Generic;

namespace REST_API.Models
{
    public partial class Lead
    {
        public long Id { get; set; }
        public long? user_id { get; set; }

        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string business_name { get; set; }
        public string project_name { get; set; }
        public string department { get; set; }
        public string project_description { get; set; }
        public string message { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
