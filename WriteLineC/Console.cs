using System;
using System.Threading;

namespace WriteLineC
{
    /// <summary>
    /// A helper to the System.Console class.
    /// </summary>
    public static class Console
    {
        /// <summary>
        /// The color black.
        /// </summary>
        public static ConsoleColor Black = ConsoleColor.Black;
        /// <summary>
        /// The color dark blue.
        /// </summary>
        public static ConsoleColor DarkBlue = ConsoleColor.DarkBlue;
        /// <summary>
        /// The color dark green.
        /// </summary>
        public static ConsoleColor DarkGreen = ConsoleColor.DarkGreen;
        /// <summary>
        /// The color dark cyan (dark blue-green).
        /// </summary>
        public static ConsoleColor DarkCyan = ConsoleColor.DarkCyan;
        /// <summary>
        /// The color dark red.
        /// </summary>
        public static ConsoleColor DarkRed = ConsoleColor.DarkRed;
        /// <summary>
        /// The color dark magenta (dark purplish-red).
        /// </summary>
        public static ConsoleColor DarkMagenta = ConsoleColor.DarkMagenta;
        /// <summary>
        /// The color dark yellow (ochre).
        /// </summary>
        public static ConsoleColor DarkYellow = ConsoleColor.DarkYellow;
        /// <summary>
        /// The color gray.
        /// </summary>
        public static ConsoleColor Gray = ConsoleColor.Gray;
        /// <summary>
        /// The color dark gray.
        /// </summary>
        public static ConsoleColor DarkGray = ConsoleColor.DarkGray;
        /// <summary>
        /// The color blue.
        /// </summary>
        public static ConsoleColor Blue = ConsoleColor.Blue;
        /// <summary>
        /// The color green.
        /// </summary>
        public static ConsoleColor Green = ConsoleColor.Green;
        /// <summary>
        /// The color cyan (blue-green).
        /// </summary>
        public static ConsoleColor Cyan = ConsoleColor.Cyan;
        /// <summary>
        /// The color red.
        /// </summary>
        public static ConsoleColor Red = ConsoleColor.Red;
        /// <summary>
        /// The color magenta (purplish-red).
        /// </summary>
        public static ConsoleColor Magenta = ConsoleColor.Magenta;
        /// <summary>
        /// The color yellow.
        /// </summary>
        public static ConsoleColor Yellow = ConsoleColor.Yellow;
        /// <summary>
        /// The color white.
        /// </summary>
        public static ConsoleColor White = ConsoleColor.White;

        /// <summary>
        /// Structure to store ConsoleColor information on how to print text.
        /// </summary>
        public struct ConsoleTextColorInfo
        {
            /// <summary>
            /// The text.
            /// </summary>
            public string Text { get; }
            /// <summary>
            /// Fore color property for text.
            /// </summary>
            public ConsoleColor? ForeColor { get; }
            /// <summary>
            /// Back color property for text.
            /// </summary>
            public ConsoleColor? BackColor { get; }

            /// <summary>
            /// Constructs a ConsoleTextColorInfo object.
            /// </summary>
            /// <param name="text">The text to be printed.</param>
            /// <param name="foreColor">The fore color for the text.</param>
            /// <param name="backColor">The back color for the text.</param>
            public ConsoleTextColorInfo(string text, ConsoleColor? foreColor = null, ConsoleColor? backColor = null)
            {
                Text = text;
                ForeColor = foreColor;
                BackColor = backColor;
            }
            /// <summary>
            /// Implicitly converts a string to ConsoleTextColorInfo struct.
            /// </summary>
            /// <param name="text"></param>
            public static implicit operator ConsoleTextColorInfo(string text) =>
                new(text);
            /// <summary>
            /// Implicitly converts a (string, ConsoleColor) to ConsoleTextColorInfo struct.
            /// </summary>
            /// <param name="args"></param>
            public static implicit operator ConsoleTextColorInfo((string text, ConsoleColor? foreColor) args) =>
                new(args.text, args.foreColor);
            /// <summary>
            /// Implicitly converts a (string, ConsoleColor, ConsoleColor) to ConsoleTextColorInfo struct.
            /// </summary>
            /// <param name="args"></param>
            public static implicit operator ConsoleTextColorInfo((string text, ConsoleColor? foreColor, ConsoleColor? backColor) args) =>
                new(args.text, args.foreColor, args.backColor);
        }

        private static int ioLock = 0;

        private static void WriteBase(params ConsoleTextColorInfo[] textColorInfo)
        {
            ConsoleColor prevFore = System.Console.ForegroundColor;
            ConsoleColor prevBack = System.Console.BackgroundColor;
            foreach (ConsoleTextColorInfo arg in textColorInfo)
            {
                System.Console.ForegroundColor = arg.ForeColor ?? prevFore;
                System.Console.BackgroundColor = arg.BackColor ?? prevBack;
                System.Console.Write(arg.Text);
            }
            System.Console.ForegroundColor = prevFore;
            System.Console.BackgroundColor = prevBack;
        }

        /// <summary>
        /// Synonymous to System.Console.WriteLine() with ability to include ConsoleColor information.
        /// </summary>
        /// <param name="textColorInfo">Text and their color information.</param>
        public static void WriteLine(params ConsoleTextColorInfo[] textColorInfo)
        {
            SpinWait.SpinUntil(() => Interlocked.Exchange(ref ioLock, 1) == 0);
            WriteBase(textColorInfo);
            System.Console.WriteLine();
            Interlocked.Exchange(ref ioLock, 0);
        }

        /// <summary>
        /// Synonymous to System.Console.Write() with ability to include ConsoleColor information.
        /// </summary>
        /// <param name="textColorInfo">Text and their color information.</param>        
        public static void Write(params ConsoleTextColorInfo[] textColorInfo)
        {
            SpinWait.SpinUntil(() => Interlocked.Exchange(ref ioLock, 1) == 0);
            WriteBase(textColorInfo);
            Interlocked.Exchange(ref ioLock, 0);
        }

        /// <summary>
        /// Prompts the user for input after a message.
        /// </summary>
        /// <param name="textColorInfo">Text and their color information.</param>
        /// <returns>The users input.</returns>
        public static string PromptLine(params ConsoleTextColorInfo[] textColorInfo)
        {
            SpinWait.SpinUntil(() => Interlocked.Exchange(ref ioLock, 1) == 0);
            WriteBase(textColorInfo);
            System.Console.WriteLine();
            string input = System.Console.ReadLine();
            Interlocked.Exchange(ref ioLock, 0);
            return input;
        }

        /// <summary>
        /// Prompts the user for input with a message.
        /// </summary>
        /// <param name="textColorInfo">Text and their color information.</param>
        /// <returns>The users input.</returns>
        public static string Prompt(params ConsoleTextColorInfo[] textColorInfo)
        {
            SpinWait.SpinUntil(() => Interlocked.Exchange(ref ioLock, 1) == 0);
            WriteBase(textColorInfo);
            string input = System.Console.ReadLine();
            Interlocked.Exchange(ref ioLock, 0);
            return input;
        }
    }
}