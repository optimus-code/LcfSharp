# LcfSharp

LcfSharp is a .NET library for reading and writing RPG Maker 2000/03 Lcf (Ldb, Lmt, Lmu, Lsd) files. This library aims to provide a straightforward and efficient way to work with Lcf files in C# applications.

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

To use existing types provided by LcfSharp, such as `LdbFile`, you can load/save an Lcf files with the following code snippets:

### Database

#### Loading

```csharp
LdbFile.Load(path);
```
#### Saving

```csharp
LdbFile.Save(path, ldbFile);
```

### Map Trees

#### Loading

```csharp
LmtFile.Load(path);
```
#### Saving

```csharp
LmtFile.Save(path, lmtFile);
```
### Maps

#### Loading

```csharp
LmuFile.Load(path);
```
#### Saving

```csharp
LmuFile.Save(path, lmuFile);
```

### Saves

#### Loading

```csharp
LsdFile.Load(path);
```
#### Saving

```csharp
LsdFile.Save(path, lsdFile);
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

In LcfSharp, some chunks are children of other chunks and have unique IDs. These IDs are read and written automatically as long as you use an `int` type decorated with the `[LcfID]` attribute with its parent class inheriting `IIndexedItem`.

### Example

Here's an example of how to define a class with child chunks that include an ID:

```csharp
[LcfChunk<ChildChunkEnum>]
public class ChildChunk : IIndexedItem
{
    [LcfID]
    public int ID { get; set; }

    public string PropertyOne { get; set; }

    public int PropertyTwo { get; set; }
}
```

### Enum for Child Chunk Properties

Define an enum to represent the properties of the child chunk (The names must be identical to the property names in the respective class):

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

## Handling Collections in Chunks

When dealing with collections in chunks, the type of list will depend on how you want/need the collection to be stored:

1. **LcfList**:
   Standard lists that are proceeded by an element count when reading/writing.
2. **LcfIndexedList**: 
   Lists where the contents are proceeded by an element count and its items are proceeded by an ID when reading/writing.
3. **LcfPackedList**:
   Fixed-width lists where the count can be calculated by the length of the payload divided by the fixed-size of the element type when reading/writing.
4. **LcfBoundedList**:
   Variable-width lists where the element size is variable so the items have to be read until there are no remaining bytes in the payload.

### Special Cases

#### Dependent Size Chunks
Sometimes you may want or need to specify the size of a list in a separate chunk. Decorating the list property with the `[LcfSize((int)MyChunk.MyItemsSize)]` attribute will ensure the length is written.

```csharp
[LcfSize((int)MyChunk.MyItemsSize)]
public LcfIndexedList<MyItem> Items { get; set; }
```

## String Encoding
LcfSharp supports encoding/decoding strings in various regions.

```csharp
public enum LcfEncodingType
{
    WesternEurope1252,
    JapaneseShiftJis,
    Cyrillic1251,
    CentralEurope1250,
    SimplifiedChineseGb2312,
    TraditionalChineseBig5,
    KoreanUhc
}
```

All strings within LcfSharp data are held in a wrapper class called `LcfString`. The original bytes of the string are retained incase the data loaded doesn't match the encoding set but would require you to handle those cases specifically. The library will write strings in the `EncodingType` specified within `LcfString`. But reading will always use the encoding setting specified in `LcfSerialiserOptions`.

## Status

Reading and writing of all formats (Ldb, Lmt, Lmu, Lsd) is working. In tests that have been run it produces byte-identical output. 

Unknown chunks will not be retained during round-trips and there may be some edge-cases where issues could be encountered. This is not guaranteed to work flawlessly as of yet and is still in alpha.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue on GitHub.

## Acknowledgements

This project couldn't exist without the great work from [liblcf](https://github.com/EasyRPG/liblcf). Special thanks to the authors of liblcf for their invaluable contributions to understanding the Lcf file format.

## License
```
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
```