
using FluentSQL.Queries;
using FluentSQL.Query;

namespace FluentSQL
{
    public static class FluentSQL
    {
        public static SelectQuery Select()
        {
            return new SelectQuery();
        }

        public static UpdateQuery Update(string tableName)
        {
            return new UpdateQuery(tableName);
        }
    }
}
