using System;

namespace ClockAngle
{
    /// <summary>
    /// Provides 
    /// </summary>
    public class Clock
    {
        public int Hour { get; private set; } = 0;
        public int Minute { get; private set; } = 0;

        public Clock() { }

        public Clock(int hour, int minute) => SetTime(hour, minute);

        /// <summary>
        /// Set the time held by this clock.
        /// </summary>
        /// <param name="hour">The hour of the day.</param>
        /// <param name="minute">The minute.</param>
        public void SetTime(int hour, int minute)
        {
            ValidateTime(hour, minute);

            Hour = hour;
            Minute = minute;
        }


        /// <summary>
        /// Determines the smaller angle between the hour and minute hand of a clock.
        /// </summary>
        /// <returns>The angle between the hour hand and the minute hand.</returns>
        public double GetClockHandAngle()
        {
            int hour = Hour;
            int minute = Minute;

            if (hour > 11) hour -= 12;

            const int DEGREE_PER_HOUR = 30;   // 360 degrees / 12 hours per revolution
            const int DEGREE_PER_MINUTE = 6;  // 360 degrees / 60 minutes per revolution 

            int angleOfMinuteHand = minute * DEGREE_PER_MINUTE;

            // The hour hand moves with the minute hand.
            double fractionOfHour = minute / 60.0;
            double angleOfHourHand = (hour + fractionOfHour) * DEGREE_PER_HOUR;

            double angle = Math.Abs(angleOfHourHand - angleOfMinuteHand);
            return angle < 180 ? angle : 360 - angle;
        }

        /// <summary>
        /// Returns a string representation of the time. (e.g. 3:45 PM)
        /// </summary>
        /// <returns>A string representation of the time.</returns>
        public override string ToString()
        {
            int hour = Hour, minute = Minute;
            var period = hour > 11 ? "PM" : "AM";
            
            if (hour > 11) hour -= 12;
            if (hour == 0) hour = 12;

            return $"{hour}:{minute:00} {period}";
        }

        /// <summary>
        /// Validates that the hour and minute are within the military time expected values
        /// </summary>
        /// <param name="hour">The hour of the day.</param>
        /// <param name="minute">The minute</param>
        private void ValidateTime(int hour, int minute)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour));
            }
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute));
            }
        }
    }
}
