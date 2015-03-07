using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQL.Clause
{
    public class WhereClause
    {
        private ICollection<Clause> _clauses = new List<Clause>();
        private Clause _currentClause;
        
        internal WhereClause(string operand)
        {
            _currentClause = new Clause();
            _currentClause._firstOperand = operand;
        }



        public string ToQuery()
        {
            return "";
        }
    }
}
