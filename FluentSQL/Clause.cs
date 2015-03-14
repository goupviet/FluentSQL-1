using FluentSQL.Clauses.From;
using FluentSQL.Clauses.OrderBy;
using FluentSQL.Clauses.Where;

namespace FluentSQL
{
    /// <summary>
    /// Static class used to create clauses in FluentSQL.
    /// </summary>
    public static class Clause
    {
        /// <summary>
        /// Creates WHERE clause
        /// </summary>
        /// <param name="operand">First operand of WHERE clause.</param>
        /// <returns></returns>
        public static WhereSubClause Where(string operand)
        {
            return new WhereSubClause(operand, new WhereClause());
        }

        /// <summary>
        /// Creates ORDERBY clause.
        /// </summary>
        /// <param name="columns">Column name by which to order.</param>
        /// <returns></returns>
        public static OrderByClause OrderBy(params string[] columns)
        {
            return new OrderByClause(columns);
        }

        /// <summary>
        /// Creates FROM clause.
        /// </summary>
        /// <param name="source">Table name.</param>
        /// <returns></returns>
        public static FromClause From(string source)
        {
            return new FromClause(source);
        }
    }
}
