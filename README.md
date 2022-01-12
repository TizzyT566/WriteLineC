# WriteLineC
A little helper to make writing text with color easier.

## Usage

### Methods

```csharp
/// <summary>
/// Synonymous to System.Console.WriteLine() with ability to include ConsoleColor information.
/// </summary>
/// <param name="textColorInfo">Text and their color information.</param>
public static void WriteLine(params ConsoleTextColorInfo[] textColorInfo)
```

```csharp
/// <summary>
/// Synonymous to System.Console.Write() with ability to include ConsoleColor information.
/// </summary>
/// <param name="textColorInfo">Text and their color information.</param>        
public static void Write(params ConsoleTextColorInfo[] textColorInfo)
```

```csharp
/// <summary>
/// Prompts the user for input after a message.
/// </summary>
/// <param name="textColorInfo">Text and their color information.</param>
/// <returns>The users input.</returns>
public static string PromptLine(params ConsoleTextColorInfo[] textColorInfo)
```

```csharp
/// <summary>
/// Prompts the user for input with a message.
/// </summary>
/// <param name="textColorInfo">Text and their color information.</param>
/// <returns>The users input.</returns>
public static string Prompt(params ConsoleTextColorInfo[] textColorInfo)
```

### Example

```csharp
using static WriteLineC.Console;

// Write normally
WriteLine("Hello world");

// Write text in red
WriteLine(("Hello World", Red));

// Write Hello in red and world in blue with green background
WriteLine(("Hello", Red), " ", ("world", Blue, Green));
```

![Output](https://raw.githubusercontent.com/TizzyT566/WriteLineC/master/output.jpg)