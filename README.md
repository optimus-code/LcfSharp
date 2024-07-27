# LcfSharp

LcfSharp is a .NET library for reading and writing RPG Maker 2000/03 Lcf (Ldb, Lmt, Lmu etc.) files. This library aims to provide a straightforward and efficient way to work with Lcf files in C# applications.

## Features

- **Read Lcf Files**: Parse RPG Maker 2000/03 Lcf files into .NET objects.
- **Write Lcf Files**: Serialize .NET objects back into RPG Maker 2000/03 Lcf files.
- **Modeled on System.Text.Json**: Familiar interface for developers who have worked with `System.Text.Json`.

## Status

Reading is implemented and is mostly working. There may be bugs that need to be ironed out. Writing is not confirmed working yet and needs more time to handle niche scenarios with Lcf writing (Like list lengths etc.).

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue on GitHub.

## Acknowledgements

This project couldn't exist without the great work from [liblcf](https://github.com/EasyRPG/liblcf). Special thanks to the authors of liblcf for their invaluable contributions to understanding the Lcf file format.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

LcfSharp Copyright (c) 2024 optimus-code
(A "loose" .NET port of liblcf)
Licensed under the MIT License.

Copyright (c) 2014-2023 liblcf authors
Licensed under the MIT License.

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be included
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.