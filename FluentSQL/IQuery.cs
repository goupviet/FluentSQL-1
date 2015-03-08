using FluentSQL.Clause;

namespace FluentSQL
{
    public interface IQuery
    {
        IQuery From(string table);
        IQuery AddClause(IClause clause);
    }
}
