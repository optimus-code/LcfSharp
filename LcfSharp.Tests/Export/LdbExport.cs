/// <copyright>
/// 
/// LcfSharp Copyright (c) 2024 optimus-code
/// (A "loose" .NET port of liblcf)
/// Licensed under the MIT License.
/// 
/// Copyright (c) 2014-2023 liblcf authors
/// Licensed under the MIT License.
/// 
/// Permission is hereby granted, free of charge, to any person obtaining
/// a copy of this software and associated documentation files (the
/// "Software"), to deal in the Software without restriction, including
/// without limitation the rights to use, copy, modify, merge, publish,
/// distribute, sublicense, and/or sell copies of the Software, and to
/// permit persons to whom the Software is furnished to do so, subject to
/// the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included
/// in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
/// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
/// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
/// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
/// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
/// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
/// </copyright>

using System;
using LcfSharp.IO;
using LcfSharp.IO.Types;
using System.IO;

namespace LcfSharp.Tests.Export
{
    /// <summary>
    /// Tests ldb export conversion and serialization.
    /// </summary>
    [TestClass]
    public class LdbExport
    {
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Checks the file ldbexport serialization.
        /// </summary>
        /// <param name="sourceFile">The source fixture file.</param>
        /// <param name="projectName">The project name.</param>
        [TestMethod]
        [DataRow( "RPG_RT.ldb", "DefaultProject" )]
        [DataRow( "RPG_RT_rw.ldb", "RomancingWalker" )]
        public void WriteFile( string sourceFile, string projectName )
        {
            var sourcePath = Path.Combine(
                AppContext.BaseDirectory, "Data", sourceFile );

            var outputDirectory = Path.Combine(
                AppContext.BaseDirectory, "ExportedLdb", projectName );
            Directory.CreateDirectory( outputDirectory );

            var outputPath = Path.Combine( outputDirectory, "RPG_RT.ldb" );

            var database = LdbFile.Load( sourcePath );
            Assert.IsNotNull( database );

            using ( var stream = File.Create( outputPath ) )
            {
                LcfSerialiser.Serialise( stream, database,
                    new LcfSerialiserOptions
                    {
                        Format = LcfFormat.LDB,
                        Version = LcfEngineVersion.RM2K
                    } );
            }

            TestContext.WriteLine( $"Generated LDB: {outputPath}" );
            TestHelpers.AssertBuffer(
                File.ReadAllBytes( sourcePath ),
                File.ReadAllBytes( outputPath ) );
        }
    }
}