using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentSQL.Queries;
using FluentSQL.Query;

namespace FluentSQL
{
    public class FluentSQLQuery
    {
        private ITranslatable _query;

        public string Query { get; private set; }

        internal FluentSQLQuery(ITranslatable query)
        {
            _query = query;
            Query = query.Translate();
        }

        public override string ToString()
        {
            return Query;
        }
    }
}
