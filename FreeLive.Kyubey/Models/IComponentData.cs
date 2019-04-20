namespace FreeLive.Kyubey.Models
{
    /// <summary>
    /// Component
    /// </summary>
    public enum ComponentType
    {
        Mesh = 2,
    }

    /// <summary>
    /// Component (IDrawData)
    /// </summary>
    interface IComponentData : ICubSerializable, ITargetStringIndexed
    {
        ComponentType ComponentType { get; }
    }
}
