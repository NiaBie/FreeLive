using System;
using System.IO;
using FreeLive.Kyubey;
using FreeLive.Kyubey.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace FreeLive.Tests
{
    [TestClass]
    public class FreeLiveTest
    {

        [TestMethod]
        public void TestCubReader(string dirpath, string mocname)
        {
            var resPath = Path.Combine(Environment.CurrentDirectory, @dirpath); // 当前路径为FreeLive-master\FreeLive.Tests\bin\Debug
            var path = Path.Combine(resPath, mocname);
            using (var fs = File.OpenRead(path))
            {
                var moc = ModelData.LoadFromStream(fs);
                var h = moc.CanvasHeight;
                var w = moc.CanvasWidth;
                var json = JsonConvert.SerializeObject(moc, Formatting.Indented);
                //var json = JsonConvert.SerializeObject(new Affine(){OriginX = 123, OriginY = 456, ReflectX = true, ReflectY = false, Rotation = 7.89f}, Formatting.Indented);
                File.WriteAllText("moc.json", json);
            }
        }

        [TestMethod]
        public void TestDeserialize()
        {
            var model = JsonConvert.DeserializeObject<ModelData>(File.ReadAllText("moc.json"));
            Console.WriteLine(model);
        }

        [TestMethod]
        public void TestDecompressCmo(string dirpath, string cmoxname)
        {
            var resPath = Path.Combine(Environment.CurrentDirectory, @dirpath);
            var path = Path.Combine(resPath, cmoxname);
            CmoLoader.Decompress(path);
        }
        
    }
}