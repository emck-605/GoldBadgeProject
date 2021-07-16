using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurancePOCO
{
    public class Badges
    {
        public Badges() { }
        public Badges(int badgeid, List<string> accessToDoor)
        {
            BadgeID = badgeid;
            AccessToDoor = accessToDoor;
        }
        public int BadgeID { get; set; }
        public List<string> AccessToDoor { get; set; }
    }
}
