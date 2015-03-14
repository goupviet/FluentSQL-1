using FluentSQL.Clauses.From;
using FluentSQL.Clauses.OrderBy;
using FluentSQL.Clauses.Where;

namespace FluentSQL
{
    public static class Clause
    {
        public static WhereSubClause Where(string operand)
        {
            return new WhereSubClause(operand, new WhereClause());
        }

        public static OrderByClause OrderBy(params string[] columns)
        {
            return new OrderByClause(columns);
        }

        public static FromClause From(string source)
        {
            return new FromClause(source);
        }
    }
}
