namespace FreeLive.Kyubey.Models
{
    /// <summary>
    /// Deformer Type
    /// </summary>
    public enum DeformerType
    {
        Dummy = 0,
        Rotation = 1,
        CurvedSurface = 2,
    }

    /// <summary>
    /// Deformer (IBaseData)
    /// </summary>
    internal abstract class DeformerData : ICubSerializable, ITargetStringIndexed
    {
        public string ID { get; private set; }
        public string TargetID { get; private set; }
        public L2ObjType IdType => L2ObjType.BaseDataID;
        public virtual DeformerType DeformerType { get; } = DeformerType.Dummy;
        public float[] PivotOpacities { get; private set; }

        public bool NeedTransform => TargetID != null && TargetID != L2Constants.DST_BASE_ID;

        public virtual void Read(CubReader br)
        {
            ID = br.ReadIdString();
            TargetID = br.ReadIdString();
        }

        /// <summary>
        /// Post Read 
        /// </summary>
        /// <param name="br"></param>
        protected void ReadOpacity(CubReader br)
        {
            if (br.FormatVersion >= 10)
            {
                PivotOpacities = br.ReadFloatArray();
            }
        }
    }
}
