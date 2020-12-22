using System;
using System.Collections.Generic;

namespace REST_API.Models
{
    public partial class Building
    {
        public long Id { get; set; }
        public long? customer_id { get; set; }
        public long? admin_contact_id { get; set; }
        public long? technical_contact_id { get; set; }
        public long? building_detail_id { get; set; }
        public long? address_id { get; set; }

        public string administrator_full_name { get; set; }
        public string administrator_email { get; set; }
        public string administrator_phone_number { get; set; }
        public string technical_contact_full_name { get; set; }
        public string technical_contact_email { get; set; }
        public string technical_contact_phone { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
