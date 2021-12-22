using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubim2.Entities
{
    public class CurrencyConversion
    {
        
        public string currency_base { get; set; }
        public string currency_quote { get; set; }
        public decimal ratio { get; set; }
        public decimal rate { get; set; }
        public decimal inv_rate { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime valid_until { get; set; }

    }

}
