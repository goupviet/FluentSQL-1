using System;

namespace FluentSQL.Queries
{
    public interface IQuery
    {
        /// <summary>
        /// Finishes construction of query.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when query is missing some parts.</exception>
        /// <returns></returns>
        FluentSQLQuery Finish();      
    }
}
