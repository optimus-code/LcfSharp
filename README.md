# LcfSharp

LcfSharp is a .NET library for reading and writing RPG Maker 2000/03 Lcf (Ldb, Lmt, Lmu, etc.) files. This library aims to provide a straightforward and efficient way to work with Lcf files in C# applications.

## Features

- **Read Lcf Files**: Parse RPG Maker 2000/03 Lcf files into .NET objects.
- **Write Lcf Files**: Serialise .NET objects back into RPG Maker 2000/03 Lcf files.
- **Modeled on System.Text.Json**: Familiar interface for developers who have worked with `System.Text.Json`.

## Installing

To install LcfSharp from NuGet, use the following command in the NuGet Package Manager Console:

```shell
Install-Package LcfSharp
```

## Usage

To use existing types provided by LcfSharp, such as `Database`, you can deserialise an Lcf file with the following code snippet:

```csharp
using (var stream = File.OpenRead(path))
{
    return LcfSerialiser.Deserialise<Database>(stream);
}
```

## Implementing Your Own Readers/Writers

Each Lcf file has a header and a collection of chunks. To deserialise a type, you need to use the `ILcfRootChunk` interface for the core class (see `Database.cs`).

### Decorate Classes with Attributes

To serialize Lcf chunks, use `[LcfChunk<ChunkEnumType>]` to decorate your classes. The enum value names need to correspond to properties in the class described by that attribute.

#### Example:

```csharp
[LcfChunk<RootChunkEnum>]
public class MyLcfClass : ILcfRootChunk
{
    public List<ChildChunk> Children { get; set; }
}
```

## Handling Child Chunks with IDs

In LcfSharp, some chunks are children of other chunks and have unique IDs. These IDs are read and written automatically as long as you use an `int` type decorated with the `[LcfID]` attribute.

### Example

Here's an example of how to define a class with child chunks that include an ID:

```csharp
[LcfChunk<ChildChunkEnum>]
public class ChildChunk
{
    [LcfID]
    public int ID { get; set; }

    public string PropertyOne { get; set; }

    public int PropertyTwo { get; set; }
}
```

### Enum for Child Chunk Properties

Define an enum to represent the properties of the child chunk:

```csharp
public enum ChildChunkEnum : int
{
    /** String */
    PropertyOne = 0x01,
    /** Integer */
    PropertyTwo = 0x02
}
```

### Ignoring Properties

For properties you don't want to be serialized, use `[LcfIgnore]`.

#### Example:

```csharp
public class MyLcfClass
{
    [LcfIgnore]
    public string IgnoredProperty { get; set; }
}
```

### Always Persist Fields

For fields that must always be serialised/deserialised, even if they equal the default value, decorate them with `[LcfAlwaysPersist]`.

#### Example:

```csharp
public class MyLcfClass
{
    [LcfAlwaysPersist]
    public int AlwaysPersistedProperty { get; set; }
}
```

### Version-Specific Properties

You can decorate properties that correspond to specific versions using `[LcfVersion(LcfEngineVersion.RM2K3)]`.

#### Example:

```csharp
public class MyLcfClass
{
    [LcfVersion(LcfEngineVersion.RM2K3)]
    public string VersionSpecificProperty { get; set; }
}
```

## Handling Collections in Chunks with List<>

When dealing with collections in chunks, the recommended approach is to use the `List<>` type. The length of the list can be determined by one of three methods:

1. **Chunk Length (Default)**: By default, the length of the list is determined by the chunk length.
2. **Using Another Chunk's Length**:
   - You can specify the length using another chunk by decorating the list property with the `[LcfSize((int)ActorChunk.AttributeRanksSize)]` attribute.
3. **Explicit Calculation**:
   - If properties are decorated with `[LcfCalculateSize]`, the list is read until the next chunk, i.e. length is not available ahead of time.

### Special Case: Classes Without ID Property

If the list item is a class that does not contain an ID property (i.e., it is not decorated with `[LcfID]`), the length is read automatically from the stream if no length is provided by the parent chunk (if there is one). In this scenario, the Lcf format doesn't provide a byte length value but a direct number of elements.

### Examples

#### Default Length from Chunk

```csharp
public List<MyItem> Items { get; set; }
```

#### Length from Another Chunk

```csharp
[LcfSize((int)ActorChunk.AttributeRanksSize)]
public List<MyItem> Items { get; set; }
```

#### Automatic based on continuous chunk reading

```csharp
[LcfCalculateSize]
public List<MyItem> Items { get; set; }
```

## Status

Reading is implemented and is mostly working. There may be bugs that need to be ironed out. Writing is not confirmed working yet and needs more time to handle niche scenarios with Lcf writing (like list lengths, etc.).

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
