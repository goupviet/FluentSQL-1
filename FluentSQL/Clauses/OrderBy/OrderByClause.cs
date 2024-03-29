﻿using System.Collections.Generic;
using System.Text;

namespace FluentSQL.Clauses.OrderBy
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
    }
}
