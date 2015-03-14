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


        public WhereSubClause And(string operand)
        {
            SubClauses.Add(new WhereAndClause());
            var clause = new WhereSubClause(operand, this);
           
            return clause;
        }

        public WhereSubClause Or(string operand)
        {
            SubClauses.Add(new WhereOrClause());
            var clause = new WhereSubClause(operand, this);

            return clause;
        }

        public int CompareTo(IClause other)
        {
            int clauseNum = 1; // FROM is first
            int otherNum = other is FromClause ? 0 : other is WhereClause ? 1 : 2;

            return clauseNum.CompareTo(otherNum);
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
