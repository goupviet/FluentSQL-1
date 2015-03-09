using System.Text;

namespace FluentSQL.Clause.Where
{
    internal class Condition
    {
        internal string FirstOperand { get; set; }
        internal string Operator { get; set; }
        internal string SecondOperand { get; set; }
    }
}
