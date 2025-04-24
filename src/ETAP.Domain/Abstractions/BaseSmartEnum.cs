using Ardalis.SmartEnum;

namespace ETAP.Domain.Abstractions
{
    public abstract class BaseSmartEnum<T> : SmartEnum<T> where T : SmartEnum<T>
    {
        public string DisplayName { get; }

        protected BaseSmartEnum(string name, int value, string displayName)
            : base(name, value)
        {
            DisplayName = displayName;
        }
    }
}