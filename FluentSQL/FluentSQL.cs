
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

        public static UpdateQuery Update()
        {
            return new UpdateQuery();
        }

        public static DeleteQuery Delete()
        {
            return new DeleteQuery();
        }

        public static InsertQuery Insert()
        {
            return new InsertQuery();
        }
    }
}
