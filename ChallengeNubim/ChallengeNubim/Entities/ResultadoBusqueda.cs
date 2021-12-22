using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeNubim.Entities
{
    public class ResultadoBusqueda
    {
        public string country_default_time_zone { get; set; }
        public string site_id { get; set; }
        public string query { get; set; }
        public List<result> Results { get; set; }


    }

    public class result
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public decimal price { get; set; }
        public string permalink { get; set; }

        public seller Seller { get; set; }


    }

    public class seller
    {
        public string id { get; set; }
    }

}