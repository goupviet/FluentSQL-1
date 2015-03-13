using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentSQL.Clause.Where;

namespace FluentSQL.Clause.From
{
    public class FromClause : IClause
    {
        private string _source;
        private FromJoinClause _joinClause = null;

        internal FromClause(string source)
        {
            _source = source;
        }

        public FromJoinClause InnerJoin(string tableName)
        {
            _joinClause = new FromJoinClause(tableName, "INNER JOIN", this);
            return _joinClause;
        }

        public FromJoinClause LeftJoin(string tableName)
        {
            _joinClause = new FromJoinClause(tableName, "LEFT JOIN", this);
            return _joinClause;
        }

        public FromJoinClause RightJoin(string tableName)
        {
            _joinClause = new FromJoinClause(tableName, "RIGHT JOIN", this);
            return _joinClause;
        }

        public FromJoinClause FullOuterJoin(string tableName)
        {
            _joinClause = new FromJoinClause(tableName, "FULL OUTER JOIN", this);
            return _joinClause;
        }

        public int CompareTo(IClause other)
        {
            int clauseNum = 0; // FROM is first
            int otherNum = other is FromClause ? 0 : other is WhereClause ? 1 : 2;

            return clauseNum.CompareTo(otherNum);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("FROM ").Append(_source);
            if (_joinClause != null)
            {
                builder.Append(_joinClause.ToString());
            }

            return builder.ToString();
        }
    }
}
