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
        private readonly ICollection<string> _columns = new List<string>();
        private readonly ICollection<IClause> _clauses = new List<IClause>(); 
        private string _tableName;       

        public SelectQuery Collum(string name)
        {
            _columns.Add(name);
            return this;
        }

        public IQuery From(string table)
        {
            _tableName = table;
            return this;
        }

        public IQuery AddClause(IClause clause)
        {
            _clauses.Add(clause);
            return this;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT ");
            string separator = "";
            foreach (var collum in _columns)
            {
                builder.Append(separator);
                builder.Append(collum);
                separator = ",";
            }
            builder.Append(" FROM ");
            builder.Append(_tableName);
            foreach (var clause in _clauses)
            {
                builder.Append(clause.ToString());
            }
            builder.Append(";");

            return builder.ToString();
        }
    }
}
