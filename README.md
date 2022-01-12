# WriteLineC
A little helper to make writing text with color easier

## Usage

```csharp
using static TizzyT.Console;

// Write normally
WriteLine("Hello world");

// 

WriteLine(("Hello", ConsoleColor.Red), " ", ("world", null, ConsoleColor.Green));
```