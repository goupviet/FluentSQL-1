using System;
using System.Collections.Generic;
using System.Text;
using FluentSQL.Clauses.From;
using FluentSQL.Clauses.OrderBy;
using FluentSQL.Clauses.Where;


namespace FluentSQL.Queries
{
    public class SelectQuery : IQuery, ITranslatable
    {
        private readonly ICollection<string> _columns = new SortedSet<string>();
        private FromClause _from = null;
        private WhereClause _where = null;
        private OrderByClause _orderBy = null;
        
        internal SelectQuery()
        {
        }

        /// <summary>
        /// Adds column to SELECT query.
        /// </summary>
        /// <param name="name">Column name.</param>
        /// <returns></returns>
        public SelectQuery Column(string name)
        {
            _columns.Add(name);
            return this;
        }

        /// <summary>
        /// Adds distinct column to SELECT query.
        /// </summary>
        /// <param name="name">Column name.</param>
        /// <returns></returns>
        public SelectQuery DistinctColumn(string name)
        {
            _columns.Add("DISTINCT " + name);
            return this;
        }

        /// <summary>
        /// Adds from clause to SELECT query.
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public SelectQuery From(FromClause from)
        {
            _from = from;
            return this;
        }

        /// <summary>
        /// Adds where clause to SELECT query.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public SelectQuery Where(WhereClause where)
        {
            _where = where;
            return this;
        }

        string ITranslatable.Translate()
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

            builder.Append(" ").Append(_from);
            if (_where != null)
            {
                builder.Append(" ").Append(_where);
            }
            if (_orderBy != null)
            {
                builder.Append(" ").Append(_orderBy);
            }

            builder.Append(";");

            return builder.ToString();
        }

        public FluentSQLQuery Finish()
        {
            if (_from == null)
            {
                throw new InvalidOperationException("Must include FROM clause in SELECT statement.");
            }
            
            return new FluentSQLQuery(this);
        }

        private void CheckValidity()
        {
            if (_from == null)
            {
                throw new InvalidOperationException("Must include FROM clause in SELECT statement.");
            }
        }

        public SelectQuery OrderBy(OrderByClause orderBy)
        {
            _orderBy = orderBy;
            return this;
        }
    }
}
