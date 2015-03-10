using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQL.Clause.From
{
    public class FromClause : IClause
    {
        private string _source;

        public FromClause(string source)
        {
            _source = source;
        }


    }
}
