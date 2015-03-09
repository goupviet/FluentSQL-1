using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQL.Clause.Where
{
    public class WhereSubClause : IClause
    {
        private Condition _condition;
        private WhereClause _returnClause;

        public WhereSubClause(string operand, WhereClause whereClause)
        {
            _condition = new Condition {FirstOperand = operand};

            _returnClause = whereClause;
            _returnClause.SubClauses.Add(this);
        }

        public WhereClause Is(string operand)
        {
            _condition.Operator = "=";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        public WhereClause IsNot(string operand)
        {
            _condition.Operator = "<>";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        public WhereClause GreaterThan(string operand)
        {
            _condition.Operator = ">";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        public WhereClause GreaterEqualThan(string operand)
        {
            _condition.Operator = ">=";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        public WhereClause LessThan(string operand)
        {
            _condition.Operator = "<";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        public WhereClause LessEqualThan(string operand)
        {
            _condition.Operator = "<=";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        public WhereClause Between(string first, string second)
        {
            _condition.Operator = " BETWEEN ";
            _condition.SecondOperand = first + " AND " + second;

            return _returnClause;
        }

        public WhereClause In(params string[] values)
        {
            _condition.Operator = " IN ";

            var builder = new StringBuilder();
            builder.Append("(");
            string separator = "";
            foreach (var value in values)
            {
                builder.Append(separator);
                builder.Append(value);
                separator = ",";
            }
            builder.Append(")");
            _condition.SecondOperand = builder.ToString();

            return _returnClause;
        }

        public WhereClause Like(string operand)
        {
            _condition.Operator = "LIKE ";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        public WhereClause IsNotNull()
        {
            _condition.Operator = " IS NOT NULL";
            _condition.SecondOperand = "";

            return _returnClause;
        }

        public WhereClause IsNull()
        {
            _condition.Operator = " IS NULL";
            _condition.SecondOperand = "";

            return _returnClause;
        }

        public override string ToString()
        {
            return _condition.FirstOperand + _condition.Operator + _condition.SecondOperand;
        }
    }
}
