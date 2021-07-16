using KomodoInsurancePOCO;
using KomodoInsuranceRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoInsuranceUnitTest
{
    [TestClass]
    public class BadgesTests
    {
        private BadgesRepo _insuranceRepo;
        private Badges _badges;

        [TestInitialize]
        public void Initialize()
        {
            List<string> list = new List<string>();
            list.Add("A1");
            _insuranceRepo = new BadgesRepo();
            _badges = new Badges(457811, list);
        }
    }
}
