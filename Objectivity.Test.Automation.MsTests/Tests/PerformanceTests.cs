﻿/*
The MIT License (MIT)

Copyright (c) 2015 Objectivity Bespoke Software Specialists

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Objectivity.Test.Automation.MsTests.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Objectivity.Test.Automation.Common;
    using Objectivity.Test.Automation.MsTests.PageObjects;

    /// <summary>
    /// Tests to test framework
    /// </summary>
    [TestClass]
    public class PerformanceTests : ProjectTestBase
    {
        /// <summary>
        /// Before the class.
        /// </summary>
        [ClassInitialize]
        public static void BeforeClass(TestContext testContext)
        {
            StartPerformanceMeasure();
        }

        /// <summary>
        /// After the class.
        /// </summary>
        [ClassCleanup]
        public static void AfterClass()
        {
            StopPerfromanceMeasure();
        }

        [DeploymentItem("Objectivity.Test.Automation.MsTests\\DDT.xml"), 
            DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\DDT.xml", "Row", 
            DataAccessMethod.Sequential), TestMethod]
        public void OpenHomePage()
        {
            var loginPage = Pages.Create<HomePage>();
            loginPage.OpenHomePageAndMeasureTime();
        }

        [TestMethod]
        public void FindChildElementsTest()
        {
            var loginPage = Pages.Create<HomePage>()
                                 .OpenHomePage();

            Assert.AreEqual(5, loginPage.CountAllTechnologiesSubLinks());
        }
    }
}