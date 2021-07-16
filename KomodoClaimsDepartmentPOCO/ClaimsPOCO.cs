using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartmentPOCO
{
    public class ClaimsPOCO
    {
        public enum TypeOfClaim
        {
            Car = 1,
            Home,
            Theft
        }
        public class Claims
        {
            public Claims() { }
            public Claims(int claimID, TypeOfClaim claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
            {
                ClaimID = claimID;
                ClaimType = claimType;
                Description = description;
                ClaimAmount = claimAmount;
                DateOfIncident = dateOfIncident;
                DateOfClaim = dateOfClaim;
                IsValid = isValid;
            }
            public int ClaimID { get; set; }
            public TypeOfClaim ClaimType { get; set; }
            public string Description { get; set; }
            public decimal ClaimAmount { get; set; }
            public DateTime DateOfIncident { get; set; }
            public DateTime DateOfClaim { get; set; }
            public bool IsValid { get; set; }
        }
    }
}
