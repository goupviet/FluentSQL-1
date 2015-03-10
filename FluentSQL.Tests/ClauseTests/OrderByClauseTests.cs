using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentSQL.Tests.ClauseTests
{
    public class OrderByClauseTests
    {
        [Fact]
        public void SingleParamOrderByTest()
        {
            var clause = Clauses.OrderBy("abcd");
            var expected = "ORDER BY abcd";

            Assert.Equal(clause.ToString(), expected);
        }

        [Fact]
        public void MultipleParamOrderByTest()
        {
            var clause = Clauses.OrderBy("abcd","test","qwer");
            var expected = "ORDER BY abcd,test,qwer";

            Assert.Equal(expected, clause.ToString());    
        }
    }
}
