using System;
using System.Collections.Generic;

namespace REST_API.Models
{
    public partial class Customer
    {
        public long Id { get; set; }
        public long? user_id { get; set; }
        public long? address_id { get; set; }

        public string company_name { get; set; }
        public string company_contact_full_name { get; set; }
        public string company_contact_phone { get; set; }
        public string company_contact_email { get; set; }
        public string company_description { get; set; }
        public string technical_authority_full_name { get; set; }
        public string technical_authority_phone_number { get; set; }
        public string technical_manager_email_service { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}