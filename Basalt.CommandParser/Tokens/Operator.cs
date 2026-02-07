using Basalt.CommandParser.Attributes;
using System.Reflection;

namespace Basalt.CommandParser.Tokens;

public class Operator : Token
{
    public NewArgumentAttribute Attribute { get; }

    public PropertyInfo Property { get; }

    // TODO: fix token requiring text
    public Operator(NewArgumentAttribute attribute, PropertyInfo property) : base(null)
    {
        Attribute = attribute;
        Property = property;
    }
}
