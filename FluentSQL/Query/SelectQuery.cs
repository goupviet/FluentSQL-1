using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentSQL.Clause;

namespace FluentSQL.Query
{
    public class SelectQuery : IQuery
    {
        private readonly ICollection<string> _collums = new List<string>();
        private string _table;
        private WhereClause _whereClause = new WhereClause("");

        public SelectQuery Collum(string name)
        {
            _collums.Add(name);
            return this;
        }

        public SelectQuery From(string table)
        {
            _table = table;
            return this;
        }

        public WhereClause Where(string operand)
        {
            _whereClause = new WhereClause(operand);
            return _whereClause;
        }

        public string ToQuery()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT ");
            string separator = "";
            foreach (var collum in _collums)
            {
                builder.Append(separator);
                builder.Append(collum);
                separator = ",";
            }
            builder.Append(" FROM ");
            builder.Append(_table);
            builder.Append(_whereClause.ToQuery());
            builder.Append(";");

            return builder.ToString();
        }
    }
}
