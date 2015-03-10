using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentSQL.Clause;
using FluentSQL.Clause.From;
using FluentSQL.Clause.OrderBy;
using FluentSQL.Clause.Where;
using Microsoft.SqlServer.Server;

namespace FluentSQL
{
    public class Clauses
    {
        public static WhereSubClause Where(string operand)
        {
            return new WhereSubClause(operand, new WhereClause());
        }

        public static OrderByClause OrderBy(params string[] collums)
        {
            return new OrderByClause(collums);
        }

        public static FromClause From(string source)
        {
            return new FromClause(source);
        }
    }
}
