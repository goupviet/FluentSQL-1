using FluentSQL.Clause;

namespace FluentSQL.Query
{
    public interface IQuery
    {
        FluentSQLQuery Finish();
        
    }
}
