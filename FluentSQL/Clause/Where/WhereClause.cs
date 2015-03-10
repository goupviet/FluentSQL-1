using System.Collections.Generic;
using System.Text;

namespace FluentSQL.Clause.Where
{
    public class WhereClause : IClause
    {
        internal ICollection<IClause> SubClauses { get; private set; }

        public WhereClause()
        {
            SubClauses = new List<IClause>();
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
