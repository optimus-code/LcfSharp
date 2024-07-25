using LcfSharp.IO.Converters;
using LcfSharp.Rpg;
using System;
using System.IO;

namespace LcfSharp.IO
{
    /// <summary>
    /// LDB (database) files
    /// </summary>
    public  static class DatabaseFile
    {
        public static Database Load(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return LcfSerializer.Deserialize<Database>(stream, new LcfSerializerOptions
                {
                    Converters = [new LcfEventCommandConverter()]
                });
            }
        }
    }
}