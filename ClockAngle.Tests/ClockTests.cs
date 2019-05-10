using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClockAngle.Tests
{
    /// <summary>
    /// Unit tests for the Clock class.
    /// </summary>
    [TestClass]
    public class ClockTests
    {

        #region Constructor Tests

        [TestMethod]
        public void Clock_0100AM_ExpectedResult()
        {
            var expectedHour = 1;
            var expectedMinute = 0;

            var clock = new Clock(1, 0);
            var actualHour = clock.Hour;
            var actualMinute = clock.Minute;

            Assert.AreEqual(expectedHour, actualHour);
            Assert.AreEqual(expectedMinute, actualMinute);
        }

        [TestMethod]
        public void Clock_0430PM_ExpectedResult()
        {
            var expectedHour = 16;
            var expectedMinute = 30;

            var clock = new Clock(16, 30);
            var actualHour = clock.Hour;
            var actualMinute = clock.Minute;

            Assert.AreEqual(expectedHour, actualHour);
            Assert.AreEqual(expectedMinute, actualMinute);
        }

        #endregion


        #region SetTime() Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetTime_MinuteTooSmall_ThrowsException()
        {
            var clock = new Clock();
            clock.SetTime(1, -1);

            // Assert - ArgumentOutOfRangeException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetTime_MinuteTooLarge_ThrowsException()
        {
            var clock = new Clock();
            clock.SetTime(1, 60);

            // Assert - ArgumentOutOfRangeException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetTime_HourTooSmall_ThrowsException()
        {
            var clock = new Clock();
            clock.SetTime(-1, 0);

            // Assert - ArgumentOutOfRangeException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetTime_HourTooLarge_ThrowsException()
        {
            var clock = new Clock();
            clock.SetTime(24, 0);

            // Assert - ArgumentOutOfRangeException
        }

        #endregion

        #region GetClockHandAngle() Tests


        [TestMethod]
        public void GetClockHandAngle_Midnight_CorrectResult()
        {
            var expected = 0;

            var clock = new Clock(0, 0);
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClockHandAngle_1AM_CorrectResult()
        {
            var expected = 30;

            var clock = new Clock(1, 0);
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClockHandAngle_6AM_CorrectResult()
        {
            var expected = 180;

            var clock = new Clock(6, 0);
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClockHandAngle_11AM_CorrectResult()
        {
            var expected = 30;

            var clock = new Clock(11, 0);
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClockHandAngle_Noon_CorrectResult()
        {
            var expected = 0;

            var clock = new Clock(12, 0);
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClockHandAngle_1PM_CorrectResult()
        {
            var expected = 30;

            var clock = new Clock(13, 0);
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClockHandAngle_9PM_CorrectResult()
        {
            var expected = 90;

            var clock = new Clock(21, 0);
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClockHandAngle_0101AM_CorrectResult()
        {
            double expected = 24.5;

            var clock = new Clock(1, 1);
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClockHandAngle_0159AM_CorrectResult()
        {
            double expected = 65.5;

            var clock = new Clock(1, 59);
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClockHandAngle_DoubleMethodCall_CorrectResult()
        {
            double expected = 65.5;

            var clock = new Clock(1, 59);
            clock.GetClockHandAngle();
            var actual = clock.GetClockHandAngle();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ToString() Tests

        [TestMethod]
        public void ToString_0100AM_CorrectResult()
        {
            var expected = "1:00 AM";

            var clock = new Clock(1, 0);
            var actual = clock.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_0100PM_CorrectResult()
        {
            var expected = "1:00 PM";

            var clock = new Clock(13, 0);
            var actual = clock.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_Noon_CorrectResult()
        {
            var expected = "12:00 PM";

            var clock = new Clock(12, 0);
            var actual = clock.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_0245PM_CorrectResult()
        {
            var expected = "2:45 PM";

            var clock = new Clock(14, 45);
            var actual = clock.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_DoubleMethodCall_CorrectResult()
        {
            var expected = "1:59 PM";

            var clock = new Clock(13, 59);
            clock.ToString();
            var actual = clock.ToString();

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
