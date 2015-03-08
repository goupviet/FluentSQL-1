using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentSQL.Clause;

namespace FluentSQL
{
    public class Clauses
    {
        public static WhereClause Where(string operand)
        {
            return new WhereClause(operand);
        }


    }
}
