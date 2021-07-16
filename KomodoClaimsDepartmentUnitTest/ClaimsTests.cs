using KomodoClaimsDepartmentRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KomodoClaimsDepartmentPOCO.ClaimsPOCO;

namespace KomodoClaimsDepartmentUnitTest
{
    [TestClass]
    public class ClaimsTests
    {
        private ClaimsRepo _claimsRepo;
        private Claims _claims;
        private Claims _lateClaims;

        [TestInitialize]
        public void Initialize()
        {
            _claimsRepo = new ClaimsRepo();
            _claims = new Claims(1, TypeOfClaim.Home, "Hail damage", 1000, DateTime.Parse("07/01/21"), DateTime.Parse("07/02/21"), true);
            _lateClaims = new Claims(1, TypeOfClaim.Car, "Slashed tires", 300, DateTime.Parse("07/07/21"), DateTime.Parse("07/08/21"), false);
        }
        [TestMethod]
        public void POCOTest()
        {
            Claims newClaim = new Claims(2, TypeOfClaim.Theft, "Stolen computer", 1500, DateTime.Parse("07/05/21"), DateTime.Parse("07/06/21"), true);

            Assert.AreEqual(2, newClaim.ClaimID);
            Assert.AreEqual(TypeOfClaim.Theft, newClaim.ClaimType);
            Assert.AreEqual("Stolen computer", newClaim.Description);
            Assert.AreEqual(DateTime.Parse("07/05/21"), newClaim.DateOfIncident);
            Assert.AreEqual(DateTime.Parse("07/06/21"), newClaim.DateOfClaim);
            Assert.AreEqual(true, newClaim.IsValid);
        }
        [TestMethod]
        public void AddClaimTest()
        {
            _claimsRepo.AddClaim(_claims);

            int expected = 1;
            int actual = _claimsRepo.GetList().Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveClaimTest()
        {
            ClaimsRepo content = new ClaimsRepo();
        }
        [TestMethod]
        public void ValidTestTrue()
        {
            _claimsRepo.AddClaim(_claims);

            bool expected = true;
            bool actual = _claims.IsValid;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidTestFalse()
        {
            _claimsRepo.AddClaim(_lateClaims);

            bool expected = false;
            bool actual = _lateClaims.IsValid;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetListTest()
        {
            _claimsRepo.GetList();
            Assert.IsNotNull(_claimsRepo);
        }
    }
}
