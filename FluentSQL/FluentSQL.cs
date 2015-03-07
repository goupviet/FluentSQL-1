using FluentSQL.Query;

namespace FluentSQL
{
    public static class FluentSQL
    {
        public static SelectQuery Select()
        {
            return new SelectQuery();
        }
    }
}
