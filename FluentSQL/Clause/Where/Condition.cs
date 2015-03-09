using System.Text;

namespace FluentSQL.Clause.Where
{
    internal class Condition
    {
        internal string FirstOperand { get; set; }
        internal string Operator { get; set; }
        internal string SecondOperand { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(" ")
                .Append(FirstOperand)
                .Append(Operator)
                .Append(SecondOperand)
                .Append(" ");

            return builder.ToString();
        }
    }
}
