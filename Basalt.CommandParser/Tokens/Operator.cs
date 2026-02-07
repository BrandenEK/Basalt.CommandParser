using System.Reflection;

namespace Basalt.CommandParser.Tokens;

public class Operator : Token
{
    private readonly ArgumentAttribute _attribute;
    private readonly PropertyInfo _property;

    // TODO: fix token requiring text
    public Operator(ArgumentAttribute attribute, PropertyInfo property) : base(null)
    {
        _attribute = attribute;
        _property = property;
    }
}
