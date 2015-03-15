using System.Collections.Generic;
using System.Text;
using FluentSQL.Clauses.From;

namespace FluentSQL.Clauses.Where
{
    public class WhereClause : IClause
    {
        internal ICollection<IWhereSubClause> SubClauses { get; private set; }

        internal WhereClause()
        {
            SubClauses = new List<IWhereSubClause>();
        }

        /// <summary>
        /// Does AND operation on where.
        /// </summary>
        /// <param name="operand">First operand of second clause.</param>
        /// <returns></returns>
        public WhereSubClause And(string operand)
        {
            SubClauses.Add(new WhereAndClause());
            var clause = new WhereSubClause(operand, this);
           
            return clause;
        }

        /// <summary>
        /// Does OR operation on where.
        /// </summary>
        /// <param name="operand">First operand of second clause.</param>
        /// <returns></returns>
        public WhereSubClause Or(string operand)
        {
            SubClauses.Add(new WhereOrClause());
            var clause = new WhereSubClause(operand, this);

            return clause;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("WHERE");

            foreach (var s in SubClauses)
            {
                builder.Append(" ").Append(s.ToString());
            }

            return builder.ToString();
        }
    }
}
