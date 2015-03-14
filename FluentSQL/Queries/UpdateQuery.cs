using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentSQL.Clauses.Where;


namespace FluentSQL.Queries
{
    public class UpdateQuery : IQuery, ITranslatable
    {
        private string _tableName = null;
        private Dictionary<string, string> _updatedValues = new Dictionary<string, string>();
        private WhereClause _where = null;

        internal UpdateQuery()
        {
           
        }

        /// <summary>
        /// Sets table which should be updated.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <returns></returns>
        public UpdateQuery Table(string tableName)
        {
            _tableName = tableName;
            return this;
        }

        /// <summary>
        /// Set column name and its value.
        /// </summary>
        /// <param name="column">Column name.</param>
        /// <param name="value">New value.</param>
        /// <returns></returns>
        public UpdateQuery Set(string column, string value)
        {
            _updatedValues.Add(column, value);

            return this;
        }

        /// <summary>
        /// Adds where clause to UPDATE query.
        /// </summary>
        /// <param name="clause"></param>
        /// <returns></returns>
        public UpdateQuery Where(WhereClause clause)
        {
            _where = clause;
            return this;
        }

        string ITranslatable.Translate()
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ").Append(_tableName).Append(" SET ");
            string separator = "";
            foreach (var key in _updatedValues.Keys)
            {
                string value = _updatedValues[key];
                builder.Append(separator).Append(key).Append("=").Append(value);
                separator = ",";
            }

            if (_where != null)
            {
                builder.Append(" ").Append(_where.ToString());

            }

            builder.Append(";");

            return builder.ToString();
        }

        public FluentSQLQuery Finish()
        {
            CheckValidity();
            return new FluentSQLQuery(this);
        }

        private void CheckValidity()
        {
            if (String.IsNullOrEmpty(_tableName))
            {
                throw new InvalidOperationException("Table name not specified in UPDATE query.");
            }
        }
    }
}
