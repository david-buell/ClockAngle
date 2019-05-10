using System;
using System.Drawing;

namespace ClockAngle
{
    class Program
    {

        static void Main(string[] args)
        {
            VT100Builder.SetConsoleSupportForVT100();

            var builder = new VT100Builder();
            Console.Write(builder.SetTitle("Clock"));

            DisplayAngle(1, 0);
            DisplayAngle(1, 1);
            DisplayAngle(1, 59);
            DisplayAngle(2, 0);
            DisplayAngle(3, 0);
            DisplayAngle(4, 0);
            DisplayAngle(5, 0);
            DisplayAngle(6, 0);
            DisplayAngle(7, 0);
            DisplayAngle(8, 0);
            DisplayAngle(9, 0);
            DisplayAngle(10, 0);
            DisplayAngle(11, 0);
            DisplayAngle(12, 0);
            DisplayAngle(13, 0);
            DisplayAngle(14, 0);
            DisplayAngle(15, 0);
            DisplayAngle(16, 0);
            DisplayAngle(17, 0);
            DisplayAngle(18, 0);
            DisplayAngle(19, 0);
            DisplayAngle(20, 0);
            DisplayAngle(21, 0);
            DisplayAngle(22, 0);
            DisplayAngle(23, 0);

            Console.ReadKey();
        }

        static void DisplayAngle(int hour, int minute)
        {
            var clock = new Clock(hour, minute);
            var result = clock.GetClockHandAngle();
            
            var builder = new VT100Builder();
            builder.Append(clock).Append("\t");
            if (hour < 10 || (hour > 12 && hour < 22)) builder.Append("\t");
            
            builder.Append("= ").SetForegroundColor(Color.LightGreen).Append(result).Append("°").ResetFormat();
            Console.WriteLine(builder);
        }
    }
}
