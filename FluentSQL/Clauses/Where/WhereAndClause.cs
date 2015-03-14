using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQL.Clauses.Where
{
    internal class WhereAndClause : IWhereSubClause
    {
        public override string ToString()
        {
            return "AND";
        }
    }
}
