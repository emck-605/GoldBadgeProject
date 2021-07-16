using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoClaimsDepartmentPOCO.ClaimsPOCO;

namespace KomodoClaimsDepartmentRepo
{
    public class ClaimsRepo
    {
        private Queue<Claims> _claims = new Queue<Claims>();
        public Queue<Claims> GetList()
        {
            return _claims;
        }
        public void AddClaim(Claims newClaim)
        {
            _claims.Enqueue(newClaim);
        }
        public void RemoveClaim()
        {
            _claims.Dequeue();
        }
        public void IsValid(Claims claim)
        {
            if (claim.DateOfClaim < claim.DateOfIncident)
                claim.DateOfClaim = claim.DateOfIncident;
            TimeSpan difference = claim.DateOfClaim - claim.DateOfIncident;

            if (difference.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
            {
                claim.IsValid = false;
            }
        }
    }
}
