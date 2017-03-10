using QuestionmarkTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace QuestionmarkTest.Tests
{
    
    
    /// <summary>
    ///This is a test class for DateDiffModelTest and is intended
    ///to contain all DateDiffModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DateDiffModelTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for DateDiffModel Constructor
        ///</summary>
        [TestMethod()]
        public void DateDiffModelConstructorTest()
        {
            DateDiffModel target = new DateDiffModel();
            Assert.IsNotNull(target,"Target constructor fail");
        }

        /// <summary>
        ///A test for AddMiddleYears
        ///Date difference for the same year
        ///</summary>
        [TestMethod()]
        public void AddMiddleYearsTest()
        {
            int s_year = 2000; 
            int e_year = 2000; 
            int expected = 0; 
            int actual;
            actual = DateDiffModel_Accessor.AddMiddleYears(s_year, e_year);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AddMiddleYears
        ///Date difference in days for 1 year apart
        ///</summary>
        [TestMethod()]
        public void AddMiddleYearsTest1()
        {
            int s_year = 2000;
            int e_year = 2001;
            int expected = 0;
            int actual;
            actual = DateDiffModel_Accessor.AddMiddleYears(s_year, e_year);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AddMiddleYears
        ///Date difference in days for 2 year
        ///</summary>
        [TestMethod()]
        public void AddMiddleYearsTest2()
        {
            int s_year = 2000;
            int e_year = 2002;
            int expected = 365;
            int actual;
            actual = DateDiffModel_Accessor.AddMiddleYears(s_year, e_year);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AddMiddleYears
        ///Date difference in days for 4 year
        ///</summary>
        [TestMethod()]
        public void AddMiddleYearsTest3()
        {
            int s_year = 2000;
            int e_year = 2005;
            int expected = 1461;
            int actual;
            actual = DateDiffModel_Accessor.AddMiddleYears(s_year, e_year);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDays 
        ///for a leap year
        ///</summary>
        [TestMethod()]
        public void GetDaysTest()
        {
            DateDiffModel target = new DateDiffModel();
            int[] dt_start = new int[] {2000, 01, 01 };
            int[] dt_end = new int[] { 2001, 01, 01 }; 
            long expected = 366; 
            long actual;
            actual = target.GetDays(dt_start, dt_end);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDays 
        ///for a leap year + normal year
        ///</summary>
        [TestMethod()]
        public void GetDaysTest1()
        {
            DateDiffModel target = new DateDiffModel();
            int[] dt_start = new int[] { 1999, 01, 01 };
            int[] dt_end = new int[] { 2001, 01, 01 };
            long expected = 731;
            long actual;
            actual = target.GetDays(dt_start, dt_end);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetDays 
        ///</summary>
        [TestMethod()]
        public void GetDaysTest2()
        {
            DateDiffModel target = new DateDiffModel();
            int[] dt_start = new int[] { 1999, 01, 01 };
            int[] dt_end = new int[] { 2005, 04, 10 };
            long expected = 2291;
            long actual;
            actual = target.GetDays(dt_start, dt_end);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDays 
        ///for large date diff
        ///</summary>
        [TestMethod()]
        public void GetDaysTest3()
        {
            DateDiffModel target = new DateDiffModel();
            int[] dt_start = new int[] { 1900, 12, 01 };
            int[] dt_end = new int[] { 2005, 04, 10 };
            long expected = 38116;
            long actual;
            actual = target.GetDays(dt_start, dt_end);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for YrType
        ///check leap year
        ///</summary>
        [TestMethod()]
        public void LeapYrTypeTest()
        {
            int year = 2000; 
            int expected = 366; 
            int[] actual;
            actual = DateDiffModel_Accessor.YrType(year);
            Assert.AreEqual(expected, actual.GetValue(12));
         }

        /// <summary>
        ///A test for YrType
        ///check non leap year
        ///</summary>
        [TestMethod()]
        public void NonLeapYrTypeTest()
        {
            int year = 2001;
            int expected = 365;
            int[] actual;
            actual = DateDiffModel_Accessor.YrType(year);
            Assert.AreEqual(expected, actual.GetValue(12));
        }

    }
}
