using System.IO;

namespace LcfSharp.Tests
{
    [TestClass]
    public class Lmu : LcfTester
    {
        [TestMethod]
        public void Read( )
        {
            var map = ExecuteWithTiming( ( ) => LmuFile.Load( Path.Combine( "Data", "Map0006.lmu" ) ) );

            Assert.IsNotNull( map );

            //Assert.IsTrue( map.Width == 100 );
            //Assert.IsTrue( map.Height == 135 );
        }
    }
}