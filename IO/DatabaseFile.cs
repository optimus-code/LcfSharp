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
            using (var reader = new LcfReader(stream))
            {
                var headerLength = reader.ReadInt();
                var header = reader.ReadString(headerLength);

                if (string.IsNullOrEmpty( header ) || header.Length != 11)
                    throw new InvalidDataException();

                if (header != "LcfDataBase")
                    Console.WriteLine("This may not be a correct database format");

                var database = new Database();
                database.LdbHeader = header;
            }
        }
    }
}
