using System.IO;

namespace LcfSharp.Tests
{
    [TestClass]
    public class Lmt : LcfTester
    {
        [TestMethod]
        public void Read( )
        {
            var mapTree = ExecuteWithTiming( ( ) => LmtFile.Load( Path.Combine( "Data", "RPG_RT.lmt" ) ) );

            Assert.IsNotNull( mapTree );

            Assert.IsTrue( mapTree.Maps[0].Name == "Romancing Walker" );
            Assert.IsTrue( mapTree.Maps[1].Name == "Main MAP" );
        }
    }
}