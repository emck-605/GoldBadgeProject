using KomodoInsurancePOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceRepo
{
    public class BadgesRepo
    {
        private Dictionary<int, List<string>> _accessToDoor = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> GetDictionary()
        {
            return _accessToDoor;
        }
        public void AddBadge(Badges badge)
        {
            _accessToDoor.Add(badge.BadgeID, badge.AccessToDoor);
        }
        public void GiveAccess (int badgeid, string accessToDoor)
        {
            List<string> doors = _accessToDoor[badgeid];
            doors.Add(accessToDoor);
        }
        public void RemoveAccess(int badgeid, string accessToDoor)
        {
            List<string> doors = _accessToDoor[badgeid];
            doors.Remove(accessToDoor);
        }
    }
}
