﻿using static WriteLineC.Console;

// Write normally
WriteLine("Hello world");

// Write text in red
WriteLine(("Hello World", Red));

// Write Hello in red and world in blue with green background
WriteLine(("Hello", Red), " ", ("world", Blue, Green));