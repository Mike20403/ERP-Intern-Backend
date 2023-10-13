using DotNetStarter.Common.Enums;

namespace DotNetStarter.Common.Models
{
    public sealed class DataChanged<T>
    {
        public DataChangedType Type { get; }

        public T Data { get; }

        public DataChanged(DataChangedType type, T data)
        {
            Type = type;
            Data = data;
        }
    }
}
