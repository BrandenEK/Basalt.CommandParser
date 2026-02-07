using Basalt.CommandParser.Attributes;
using Basalt.CommandParser.Exceptions;
using System;
using System.Reflection;

namespace Basalt.CommandParser.Tokens;

public class Operator : Token
{
    public NewArgumentAttribute Attribute { get; }

    public PropertyInfo Property { get; }

    public Operator(NewArgumentAttribute attribute, PropertyInfo property)
    {
        if (attribute.DataType != property.PropertyType)
            throw new ArgumentLoadingException("property with different type than its attribute", property.Name);

        Attribute = attribute;
        Property = property;

        Console.WriteLine($"Loaded argument '{attribute.LongName}'");
    }
}
