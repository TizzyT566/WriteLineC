using System;

namespace TizzyT
{
    /// <summary>
    /// Represents the standard input, output, and error streams for console applications. This class cannot be inherited.
    /// </summary>
    public static class Console
    {
        /// <summary>
        /// An object to store ConsoleColor information on how to print text.
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

        /// <summary>
        /// Synonymous to System.Console.WriteLine() with ability to include ConsoleColor information.
        /// </summary>
        /// <param name="args"></param>
        public static void WriteLine(params ConsoleTextColorInfo[] args)
        {
            Write(args);
            System.Console.WriteLine();
        }

        /// <summary>
        /// Synonymous to System.Console.Write() with ability to include ConsoleColor information.
        /// </summary>
        /// <param name="args"></param>
        public static void Write(params ConsoleTextColorInfo[] args)
        {
            ConsoleColor prevFore = System.Console.ForegroundColor;
            ConsoleColor prevBack = System.Console.BackgroundColor;
            foreach (ConsoleTextColorInfo arg in args)
            {
                System.Console.ForegroundColor = arg.ForeColor ?? prevFore;
                System.Console.BackgroundColor = arg.BackColor ?? prevBack;
                System.Console.Write(arg.Text);
            }
            System.Console.ForegroundColor = prevFore;
            System.Console.BackgroundColor = prevBack;
        }
    }
}