using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentSQL.Clause;
using FluentSQL.Clause.Where;

namespace FluentSQL
{
    public class Clauses
    {
        public static WhereSubClause Where(string operand)
        {
            return new WhereSubClause(operand, new WhereClause());
        }


    }
}
