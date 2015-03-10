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
        
        public SelectQuery Collum(string name)
        {
            _columns.Add(name);
            return this;
        }

        public SelectQuery DistinctCollum(string name)
        {
            _columns.Add("DISTINCT " + name);
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
           
            foreach (var clause in _clauses)
            {
                builder.Append(" ").Append(clause.ToString());
            }
            builder.Append(";");

            return builder.ToString();
        }
    }
}
