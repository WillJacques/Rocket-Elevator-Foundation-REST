using System;
using System.Collections.Generic;

namespace REST_API.Models
{
    public partial class Quote
    {
       public long Id {get; set;}
       public long? user_id {get; set;}
       public long? apartments {get; set;}
       public long? floors {get; set;}
       public long? basements {get; set;}
       public long? businesses {get; set;}
       public long? elevator_shafts {get; set;}
       public long? parking_spaces {get; set;}
       public long? occupants {get; set;}
       public long? opening_hours {get; set;}
       public string product_line {get; set;}
       public long? install_fee {get; set;}
       public long? total_price {get; set;}
       public long? unit_price {get; set;}
       public long? elevator_number {get; set;}
       public DateTime? created_at {get; set;}
       public DateTime? updated_at {get; set;}
       public string building_type {get; set;}
    }
}