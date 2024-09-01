using System.IO;
using System.Linq;

namespace LcfSharp.Tests
{
    [TestClass]
    public class Lmu : LcfTester
    {
        [TestMethod]
        public void Read( )
        {
            var mapTree = ExecuteWithTiming( ( ) => LmtFile.Load( Path.Combine( "Data", "RPG_RT.lmt" ) ) );


            var mapName = mapTree?.Maps?.FirstOrDefault( m => m.ID == 168 ).Name;
            var map = ExecuteWithTiming( ( ) => LmuFile.Load( Path.Combine( "Data", "Map0168.lmu" ) ) );

            Assert.IsNotNull( map );

            //Assert.IsTrue( map.Width == 100 );
            //Assert.IsTrue( map.Height == 135 );
        }
    }
}