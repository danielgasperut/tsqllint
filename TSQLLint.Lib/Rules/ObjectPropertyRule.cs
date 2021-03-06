using System;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using TSQLLint.Lib.Rules.Interface;

namespace TSQLLint.Lib.Rules
{
    public class ObjectPropertyRule : TSqlFragmentVisitor, ISqlRule
    {
        private readonly Action<string, string, int, int> errorCallback;

        public ObjectPropertyRule(Action<string, string, int, int> errorCallback)
        {
            this.errorCallback = errorCallback;
        }

        public string RULE_NAME => "object-property";

        public string RULE_TEXT => "Expected use of SYS.COLUMNS rather than ObjectProperty function";

        public override void Visit(FunctionCall node)
        {
            if (node.FunctionName.Value.Equals("OBJECTPROPERTY", StringComparison.OrdinalIgnoreCase))
            {
                errorCallback(RULE_NAME, RULE_TEXT, node.StartLine, node.StartColumn);
            }
        }
    }
}
