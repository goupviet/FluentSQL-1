using FluentSQL.Queries;

namespace FluentSQL
{
    /// <summary>
    /// Static class used to create queries in FluentSQL.
    /// </summary>
    public static class Query
    {
        /// <summary>
        /// Creates SELECT query.
        /// </summary>
        /// <returns></returns>
        public static SelectQuery Select()
        {
            return new SelectQuery();
        }

        /// <summary>
        /// Creates UPDATE query.
        /// </summary>
        /// <returns></returns>
        public static UpdateQuery Update()
        {
            return new UpdateQuery();
        }

        /// <summary>
        /// Creates DELETE query.
        /// </summary>
        /// <returns></returns>
        public static DeleteQuery Delete()
        {
            return new DeleteQuery();
        }

        /// <summary>
        /// Creates INSERT query.
        /// </summary>
        /// <returns></returns>
        public static InsertQuery Insert()
        {
            return new InsertQuery();
        }
    }
}
