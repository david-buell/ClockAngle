using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ClockAngle
{
    /// <summary>
    /// Implements Virtual Terminal Sequences to provide more functionality to the console.
    /// If the console doesn't support this operation it'll revert to standard text.
    /// </summary>
    public sealed class VT100Builder
    {
        public static bool ConsoleModeSet { get; private set; } = false;

        public StringBuilder builder;

        public const int STD_OUTPUT_HANDLE = -11;
        public const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
        public const uint DISABLE_NEWLINE_AUTO_RETURN = 0x0008;

        [DllImport("kernel32.dll")]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        /// <summary>
        /// Sets the Windows console to handle virtual terminal sequences. This method
        /// must be called prior to using the console or this builder.
        /// </summary>
        /// <returns></returns>
        public static bool SetConsoleSupportForVT100()
        {
            var iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            if (!GetConsoleMode(iStdOut, out uint outConsoleMode))
            {
                ConsoleModeSet = false;
            }

            outConsoleMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING | DISABLE_NEWLINE_AUTO_RETURN;
            if (!SetConsoleMode(iStdOut, outConsoleMode))
            {
                ConsoleModeSet = false;
            }
            ConsoleModeSet = true;
            return ConsoleModeSet;
        }

        public VT100Builder()
        {
            builder = new StringBuilder();
        }

        public VT100Builder SetTitle(string s)
        {
            if (ConsoleModeSet)
            {
                builder.Append($"\u001b]0;{s}\x07");
            }
            return this;
        }

        public VT100Builder SetForegroundColor(Color c)
        {
            if (ConsoleModeSet)
            {
                builder.Append($"\u001b[38;2;{c.R};{c.G};{c.B}m");
            }
            return this;
        }

        public VT100Builder Bold()
        {
            if (ConsoleModeSet)
            {
                builder.Append($"\u001b[1m");
            }
            return this;
        }

        public VT100Builder Underline()
        {
            if (ConsoleModeSet)
            {
                builder.Append($"\u001b[4m");
            }
            return this;
        }

        public VT100Builder SetBackgroundColor(Color c)
        {
            if (ConsoleModeSet)
            {
                builder.Append($"\u001b[48;2;{c.R};{c.G};{c.B}m");
            }
            return this;
        }

        public VT100Builder ResetFormat()
        {
            if (ConsoleModeSet)
            {
                builder.Append($"\u001b[0m");
            }
            return this;
        }

        /// <summary>
        /// Remove all characters from the current VT100Builder instance.
        /// </summary>
        /// <returns>A reference to this instance after the clear operation has completed.</returns>
        public VT100Builder Clear()
        {
            builder.Clear();
            return this;
        }

        public VT100Builder Append(string s)
        {
            builder.Append(s);
            return this;
        }

        public VT100Builder Append(object s)
        {
            builder.Append(s);
            return this;
        }

        public VT100Builder AppendLine(string s)
        {
            builder.AppendLine(s);
            return this;
        }

        public VT100Builder Append(double d)
        {
            builder.Append(d);
            return this;
        }

        public override string ToString()
        {
            return builder.ToString();
        }
    }
}
