using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace FreeLive.Kyubey.Models
{
    /// <summary>
    /// ParameterSamples
    /// </summary>
    class ParamList : List<Param>, ICubSerializable
    {
        [JsonProperty] public const L2ObjType Type = L2ObjType.ParamDefList;

        public ParamList()
        { }

        internal ParamList(CubReader br)
        {
            Read(br);
        }

        public void Read(CubReader br)
        {
            Clear();
            if (br.ReadObject() is List<object> list)
            {
                AddRange(list.Cast<Param>());
            }
        }
    }
}
