using Basalt.CommandParser.Attributes;
using System.Reflection;

namespace Basalt.CommandParser.Tokens;

public class Operator : Token
{
    public NewArgumentAttribute Attribute { get; }

    public PropertyInfo Property { get; }

    public Operator(NewArgumentAttribute attribute, PropertyInfo property)
    {
        Attribute = attribute;
        Property = property;
    }
}
