using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeLive.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FreeLiveTest temp = new FreeLiveTest();
            temp.TestCubReader("..\\..\\..\\Assets", "haru.moc");
            // temp.TestDecompressCmo("..\\..\\..\\Assets", "haru_11.cmox");
            temp.TestDeserialize();
        }
    }
}
