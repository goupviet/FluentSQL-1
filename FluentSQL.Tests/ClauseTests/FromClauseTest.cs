using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentSQL.Tests.ClauseTests
{
    public class FromClauseTest
    {
        [Fact]
        public void FromTableTest()
        {
            var clause = Clauses.From("test");
            var expected = "FROM test";

            Assert.Equal(expected, clause.ToString());
        }

        [Fact]
        public void FromTableInnerJoinTest()
        {
            var clause = Clauses.From("test").InnerJoin("other").On("id1", "id2");
            var expected = "FROM test INNER JOIN other ON id1=id2";

            Assert.Equal(expected, clause.ToString());
        }

        [Fact]
        public void FromTableFullOuterJoinTest()
        {
            var clause = Clauses.From("test").FullOuterJoin("other").On("id1", "id2");
            var expected = "FROM test FULL OUTER JOIN other ON id1=id2";

            Assert.Equal(expected, clause.ToString());
        }

        [Fact]
        public void FromTableLeftJoinTest()
        {
            var clause = Clauses.From("test").LeftJoin("other").On("id1", "id2");
            var expected = "FROM test LEFT JOIN other ON id1=id2";

            Assert.Equal(expected, clause.ToString());
        }
        [Fact]
        public void FromTableRightJoinTest()
        {
            var clause = Clauses.From("test").RightJoin("other").On("id1", "id2");
            var expected = "FROM test RIGHT JOIN other ON id1=id2";

            Assert.Equal(expected, clause.ToString());
        }

    }
}
