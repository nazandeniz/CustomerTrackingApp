using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTrackingApp
{

    public class Customer
    {
        public int ID { get; set; } // Otomatik artan ID
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public string GetSummary()
        {
            return $"ID: {ID}\nAd: {Name} {Surname}\nTelefon: {Phone}\nMail: {Mail}";
        }
    }

}
