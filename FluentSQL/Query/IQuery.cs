using FluentSQL.Clause;

namespace FluentSQL.Query
{
    public interface IQuery
    {
        IQuery AddClause(IClause clause);
    }
}
