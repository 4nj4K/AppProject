using System.Reflection;

namespace Domain.Extensions;

public static class MappExtensions
{
    public static TDestionation MapTo<TDestionation>(this object source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        TDestionation destination = Activator.CreateInstance<TDestionation>()!;

        var sourceProperties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var destinationProperties = destination.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var destinationProperty in destinationProperties)
        {
            var sourceProperty = sourceProperties.FirstOrDefault(x => x.Name == destinationProperty.Name && x.PropertyType == destinationProperty.PropertyType);
            if (sourceProperty != null && destinationProperty.CanWrite)
            {
                var value = sourceProperty.GetValue(source);
                destinationProperty.SetValue(destination, value);
            }
        }

        return destination;
        
    }
}
