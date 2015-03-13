using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQL.Clause.Where
{
    internal class WhereOrClause : IWhereSubClause
    {
        public override string ToString()
        {
            return "OR";
        }
    }
}
