# WriteLineC
A little helper to make writing text with color easier.

## Usage

### Methods

```csharp
/// <summary>
/// Synonymous to System.Console.WriteLine() with ability to include ConsoleColor information.
/// </summary>
/// <param name="args"></param>
public static void WriteLine(params ConsoleTextColorInfo[] args)
```

```csharp
/// <summary>
/// Synonymous to System.Console.Write() with ability to include ConsoleColor information.
/// </summary>
/// <param name="args"></param>        
public static void Write(params ConsoleTextColorInfo[] args)
```

```csharp
/// <summary>
/// Prompts the user for input after a message.
/// </summary>
/// <param name="message">The message to prompt the user.</param>
/// <returns>The users input.</returns>
public static string PromptLine(params ConsoleTextColorInfo[] message)
```

```csharp
/// <summary>
/// Prompts the user for input with a message.
/// </summary>
/// <param name="message">The message to prompt the user.</param>
/// <returns>The users input.</returns>
public static string Prompt(params ConsoleTextColorInfo[] message)
```

### Example

```csharp
using static TizzyT.Console;

// Write normally
WriteLine("Hello world");

// Write text in red
WriteLine(("Hello World", Red));

// Write Hello in red and world in blue with green background
WriteLine(("Hello", Red), " ", ("world", Blue, Green));
```

![Output](https://raw.githubusercontent.com/TizzyT566/WriteLineC/master/output.jpg)