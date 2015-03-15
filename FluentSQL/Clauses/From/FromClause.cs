using System.Text;
using FluentSQL.Clauses.Where;

namespace FluentSQL.Clauses.From
{
    public class FromClause : IClause
    {
        private string _source;
        private FromJoinClause _joinClause = null;

        internal FromClause(string source)
        {
            _source = source;
        }

        /// <summary>
        /// Does a INNER JOIN on other table.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <returns></returns>
        public FromJoinClause InnerJoin(string tableName)
        {
            _joinClause = new FromJoinClause(tableName, "INNER JOIN", this);
            return _joinClause;
        }

        /// <summary>
        /// Does a LEFT JOIN on other table.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <returns></returns>
        public FromJoinClause LeftJoin(string tableName)
        {
            _joinClause = new FromJoinClause(tableName, "LEFT JOIN", this);
            return _joinClause;
        }
        
        /// <summary>
        /// Does a RIGHT JOIN on other table.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <returns></returns>
        public FromJoinClause RightJoin(string tableName)
        {
            _joinClause = new FromJoinClause(tableName, "RIGHT JOIN", this);
            return _joinClause;
        }

        /// <summary>
        /// Does a FULL OUTER JOIN on other table.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <returns></returns>
        public FromJoinClause FullOuterJoin(string tableName)
        {
            _joinClause = new FromJoinClause(tableName, "FULL OUTER JOIN", this);
            return _joinClause;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("FROM ").Append(_source);
            if (_joinClause != null)
            {
                builder.Append(_joinClause.ToString());
            }

            return builder.ToString();
        }
    }
}
