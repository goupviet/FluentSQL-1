using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentSQL.Clause.From;
using FluentSQL.Clause.Where;

namespace FluentSQL.Query
{
    public class DeleteQuery : IQuery, ITranslatable
    {
        private FromClause _from;
        private WhereClause _where;

        public DeleteQuery From(FromClause from)
        {
            _from = from;
            return this;
        }

        public DeleteQuery Where(WhereClause where)
        {
            _where = where;
            return this;
        }

        public FluentSQLQuery Finish()
        {
            CheckValidity();
            return new FluentSQLQuery(this);
        }

        private void CheckValidity()
        {
            if (_from == null)
            {
                throw new InvalidOperationException("FROM can't be null in DELETE query.");
            }
        }

        string ITranslatable.Translate()
        {
            var builder = new StringBuilder();
            builder.Append("DELETE ");
            builder.Append(_from.ToString());
            if (_where != null)
            {
                builder.Append(" ").Append(_where.ToString());
            }
            builder.Append(";");

            return builder.ToString();
        }
    }
}
