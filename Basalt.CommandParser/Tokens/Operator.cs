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
        Console.WriteLine(attribute.DataType.Name.ToString());
        Console.WriteLine(property.PropertyType.Name.ToString());

        Type attributeType = attribute.DataType;
        Type propertyType = property.PropertyType;

        if (attributeType != propertyType)
            throw new ImproperSetupException($"The argument type for {attribute.LongName} does not match its property type");

        Attribute = attribute;
        Property = property;
    }
}
