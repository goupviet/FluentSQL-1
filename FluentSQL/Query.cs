using FluentSQL.Queries;

namespace FluentSQL
{
    public static class Query
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
