using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQL.Queries
{
    public class InsertQuery : IQuery, ITranslatable
    {
        private string _table = null;
        private Dictionary<string, string> _values;

        internal InsertQuery()
        {
            _values = new Dictionary<string, string>();
        }

        public InsertQuery Table(string tableName)
        {
            _table = tableName;
            return this;
        }

        public InsertQuery Value(string columnName, string value)
        {
            _values.Add(columnName, value);
            return this;
        }

        public FluentSQLQuery Finish()
        {
            CheckValidity();
            return new FluentSQLQuery(this);
        }

        private void CheckValidity()
        {
            if (String.IsNullOrEmpty(_table))
            {
                throw new InvalidOperationException("Table name not specified in INSERT query.");
            }
        }

        string ITranslatable.Translate()
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ").Append(_table).Append(" (");
            string separator = "";
            foreach (var key in _values.Keys)
            {
                builder.Append(separator).Append(key);
                separator = ",";
            }
            builder.Append(") VALUES (");
            separator = "";
            foreach (var key in _values.Keys)
            {
                if (_values[key].StartsWith("@"))
                {
                    builder.Append(separator).Append(_values[key]);
                }
                else
                {
                    builder.Append(separator).Append("'").Append(_values[key]).Append("'");
                }
                
                separator = ",";
            }
            builder.Append(");");

            return builder.ToString();
        }
    }
}
