using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FreeLive
{
    //public interface IL2Object
    //{ }

    /// <summary>
    /// Indexed by string
    /// </summary>
    internal interface IStringIndexed
    {
        string ID { get; }

        //[JsonConverter(typeof(StringEnumConverter))]
        L2ObjType IdType { get; }

        string ToString();
    }

    /// <summary>
    /// Indexed by string and have a target
    /// </summary>
    internal interface ITargetStringIndexed : IStringIndexed
    {
        string TargetID { get; }
    }
}
