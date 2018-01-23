using System.Collections.Generic;
using System.IO;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using TSQLLint.Lib.Parser.Interfaces;

namespace TSQLLint.Lib.Parser
{
    public class FragmentBuilder : IFragmentBuilder
    {
        private readonly TSql120Parser parser;

        public FragmentBuilder()
        {
            parser = new TSql120Parser(true);
        }

        public TSqlFragment GetFragment(TextReader txtRdr, out IList<ParseError> errors)
        {
            var parsedFragment = parser.Parse(txtRdr, out errors);
            if (parsedFragment != null && parsedFragment.FirstTokenIndex != -1)
            {
                return parsedFragment;
            }

            return null;
        }
    }
}
