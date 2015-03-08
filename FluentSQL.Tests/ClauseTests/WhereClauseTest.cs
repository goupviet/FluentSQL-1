using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentSQL.Tests.ClauseTests
{
    public class WhereClauseTest
    {
        [Fact]
        public void WhereClauseOperatorTest()
        {
            var clause = Clauses.Where("test").Is("test");
            var expected = " WHERE test=test ";

            Assert.Equal(expected, clause.ToString());
        }
    }
}
