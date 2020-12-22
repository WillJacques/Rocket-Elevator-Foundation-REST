using System;
using System.Collections.Generic;

namespace REST_API.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string email { get; set; }
        public string encrypted_password { get; set; }
        public string reset_password_token { get; set; }
        public DateTime? reset_password_sent_at { get; set; }
        public DateTime? remember_created_at { get; set; }
    }
}