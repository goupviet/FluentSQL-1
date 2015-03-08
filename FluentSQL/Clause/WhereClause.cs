using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQL.Clause
{
    public class WhereClause : IClause
    {
        private Condition _currentCondition;
        private ICollection<Condition> _conditions = new List<Condition>(); 
        
        internal WhereClause(string operand)
        {
            _currentCondition = new Condition {FirstOperand = operand};
        }

        public WhereClause Is(string operand)
        {
            _currentCondition.Operator = "=";
            _currentCondition.SecondOperand = operand;
            _conditions.Add(_currentCondition);

            return this;
        }

        public WhereClause IsNot(string operand)
        {
            _currentCondition.Operator = "!=";
            _currentCondition.SecondOperand = operand;
            _conditions.Add(_currentCondition);
            

            return this;
        }

        public WhereClause GreaterThan(string operand)
        {
            _currentCondition.Operator = ">";
            _currentCondition.SecondOperand = operand;
            _conditions.Add(_currentCondition);


            return this;
        }

        public WhereClause GreaterEqualThan(string operand)
        {
            _currentCondition.Operator = ">=";
            _currentCondition.SecondOperand = operand;
            _conditions.Add(_currentCondition);


            return this;
        }

        public WhereClause LessThan(string operand)
        {
            _currentCondition.Operator = "<";
            _currentCondition.SecondOperand = operand;
            _conditions.Add(_currentCondition);


            return this;
        }

        public WhereClause LessEqualThan(string operand)
        {
            _currentCondition.Operator = "<=";
            _currentCondition.SecondOperand = operand;
            _conditions.Add(_currentCondition);


            return this;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(" WHERE");
            foreach (var condition in _conditions)
            {
                builder.Append(condition.ToString());
            }

            return builder.ToString();
        }
    }
}
