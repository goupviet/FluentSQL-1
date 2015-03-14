namespace FluentSQL.Clauses.Where
{
    internal class WhereOrClause : IWhereSubClause
    {
        public override string ToString()
        {
            return "OR";
        }
    }
}
