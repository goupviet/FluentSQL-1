using System.Text;

namespace FluentSQL.Clauses.Where
{
    public class WhereSubClause : IWhereSubClause
    {
        private Condition _condition;
        private WhereClause _returnClause;

        public WhereSubClause(string operand, WhereClause whereClause)
        {
            _condition = new Condition {FirstOperand = operand};

            _returnClause = whereClause;
            _returnClause.SubClauses.Add(this);
        }

        /// <summary>
        /// Equals relation.
        /// </summary>
        /// <param name="operand">Second operand.</param>
        /// <returns></returns>
        public WhereClause Is(string operand)
        {
            _condition.Operator = "=";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        /// <summary>
        /// Not equals relation.
        /// </summary>
        /// <param name="operand">Second operand.</param>
        /// <returns></returns>
        public WhereClause IsNot(string operand)
        {
            _condition.Operator = "<>";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        /// <summary>
        /// Greater than relation.
        /// </summary>
        /// <param name="operand">Second operand.</param>
        /// <returns></returns>
        public WhereClause GreaterThan(string operand)
        {
            _condition.Operator = ">";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        /// <summary>
        /// Greater equal relation.
        /// </summary>
        /// <param name="operand">Second operand.</param>
        /// <returns></returns>
        public WhereClause GreaterEqualThan(string operand)
        {
            _condition.Operator = ">=";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        /// <summary>
        /// Less than relation.
        /// </summary>
        /// <param name="operand">Second operand.</param>
        /// <returns></returns>
        public WhereClause LessThan(string operand)
        {
            _condition.Operator = "<";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        /// <summary>
        /// Less equal relation.
        /// </summary>
        /// <param name="operand">Second operand.</param>
        /// <returns></returns>
        public WhereClause LessEqualThan(string operand)
        {
            _condition.Operator = "<=";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        /// <summary>
        /// Between relation.
        /// </summary>
        /// <param name="first">FIrst bound.</param>
        /// <param name="second">Second bound.</param>
        /// <returns></returns>
        public WhereClause Between(string first, string second)
        {
            _condition.Operator = " BETWEEN ";
            _condition.SecondOperand = first + " AND " + second;

            return _returnClause;
        }

        /// <summary>
        /// In relation.
        /// </summary>
        /// <param name="values">Values.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Like relation.
        /// </summary>
        /// <param name="operand">Second operand.</param>
        /// <returns></returns>
        public WhereClause Like(string operand)
        {
            _condition.Operator = " LIKE ";
            _condition.SecondOperand = operand;

            return _returnClause;
        }

        /// <summary>
        /// IsNotNull constraint.
        /// </summary>
        /// <returns></returns>
        public WhereClause IsNotNull()
        {
            _condition.Operator = " IS NOT NULL";
            _condition.SecondOperand = "";

            return _returnClause;
        }

        /// <summary>
        /// IsNull constraint.
        /// </summary>
        /// <returns></returns>
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
