using System;
using Irony.Parsing;
using NetTopologySuite.Features;
using SharpMap.Data;
using SharpMap.Data.Providers;

namespace SharpMap.Forms.Controls.Provider
{
    public interface IDefinitionQueryParser
    {
        FilterProvider.FilterMethod Parse(string definitionQuery);
    }
    
    internal class IronyDefinitionQueryParser : IDefinitionQueryParser
    {
        private static readonly Parser Parser = new Parser(new SqlWhereGrammar());

        public FilterProvider.FilterMethod Parse(string definitionQuery)
        {
            var pt = Parser.Parse(definitionQuery);
            if (pt.HasErrors())
                return null;

            return new IronyFilterMethod(pt.Root.AstNode).Filter;
        }

        internal class SqlWhereGrammar : Grammar
        {
            public SqlWhereGrammar() :base(false)
            {}
        }

        internal class IronyFilterMethod
        {
            private readonly object _astNode;

            internal IronyFilterMethod(object astNode)
            {
                _astNode = astNode;
            }

            public bool Filter(FeatureDataRow row)
            {
                if (_astNode == null)
                    return true;

                return Filter(_astNode, row);
            }

            private static bool Filter(object astNode, FeatureDataRow row)
            {
                return false;
            }
        }
    }

}