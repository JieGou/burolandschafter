﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rhino.Geometry;
using HOK.Buro.Factory;
using HOK.Buro.Formats;
using HOK.Buro.Logic;

namespace HOK.Buro.Tests.Relationships.Identify
{
    [TestClass]
    public class FloorPlateRegionsTests
    {
        [TestMethod]
        public void DieFive_ReturnsOneRegion()
        {
            TestFitPackage TestEnv = TestFitFactory.DieFive(1);

            List<Brep> resultGeometry = Logic.Relationships.Identify.FloorPlateRegions(TestEnv);

            bool testResult = (resultGeometry.Count == 1) ? true : false;

            Assert.IsTrue(testResult);
        }
    }
}