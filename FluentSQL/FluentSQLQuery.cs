
using FluentSQL.Queries;

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
