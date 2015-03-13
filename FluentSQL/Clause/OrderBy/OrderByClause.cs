using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentSQL.Clause.From;
using FluentSQL.Clause.Where;

namespace FluentSQL.Clause.OrderBy
{
    public class OrderByClause : IClause
    {
        private ICollection<string> _collums;

        internal OrderByClause(params string[] collums)
        {
            _collums = new List<string>(collums);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("ORDER BY ");
            string separator = "";
            foreach (var collum in _collums)
            {
                builder.Append(separator).Append(collum);
                separator = ",";
            }

            return builder.ToString();
        }
        public int CompareTo(IClause other)
        {
            int clauseNum = 2; // FROM is first
            int otherNum = other is FromClause ? 0 : other is WhereClause ? 1 : 2;

            return clauseNum.CompareTo(otherNum);
        }
    }
}
