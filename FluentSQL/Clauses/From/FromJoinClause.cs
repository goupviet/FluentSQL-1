using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQL.Clauses.From
{
    public class FromJoinClause
    {
        private string _tableName;
        private FromClause _returnClause;
        private string _joinType;

        private string _firstId;
        private string _secondId;

        internal FromJoinClause(string tableName, string joinType, FromClause returnClause)
        {
            _tableName = tableName;
            _returnClause = returnClause;
            _joinType = joinType;
        }

        public FromClause On(string first, string second)
        {
            _firstId = first;
            _secondId = second;

            return _returnClause;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append(" ").Append(_joinType).Append(" ");
            builder.Append(_tableName).Append(" ON ").Append(_firstId).Append("=").Append(_secondId);

            return builder.ToString();
        }
    }
}
