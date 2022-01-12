# WriteLineC
A little helper to make writing text with color easier.

## Usage

```csharp
using static TizzyT.Console;

// Write normally
WriteLine("Hello world");

// Write text in red
WriteLine(("Hello World", Red));

// Write Hello in read and world in blue with green background
WriteLine(("Hello", Red), " ", ("world", Blue, Green));
```