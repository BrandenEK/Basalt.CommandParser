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
            throw new ImproperSetupException(property.Name, "property type");

        Attribute = attribute;
        Property = property;

        Console.WriteLine($"Loaded argument '{attribute.LongName}'");
    }
}
