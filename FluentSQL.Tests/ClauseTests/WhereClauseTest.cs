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
        public void WhereClauseIsOperatorTest()
        {
            var clause = Clauses.Where("test").Is("test");
            var expected = " WHERE test=test ";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseIsNotOperatorTest()
        {
            var clause = Clauses.Where("test").IsNot("test");
            var expected = " WHERE test<>test ";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseGreaterThanOperatorTest()
        {
            var clause = Clauses.Where("test").GreaterThan("test");
            var expected = " WHERE test>test ";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseLessThanOperatorTest()
        {
            var clause = Clauses.Where("test").LessThan("test");
            var expected = " WHERE test<test ";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseLessEqualOperatorTest()
        {
            var clause = Clauses.Where("test").LessEqualThan("test");
            var expected = " WHERE test<=test ";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseGreaterEqualOperatorTest()
        {
            var clause = Clauses.Where("test").GreaterEqualThan("test");
            var expected = " WHERE test>=test ";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseIsNullOperatorTest()
        {
            var clause = Clauses.Where("test").IsNull();
            var expected = " WHERE test IS NULL ";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseIsNotNullOperatorTest()
        {
            var clause = Clauses.Where("test").IsNotNull();
            var expected = " WHERE test IS NOT NULL ";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseInOperatorTest()
        {
            var clause = Clauses.Where("test").In("one", "two", "three");
            var expected = " WHERE test IN (one,two,three)";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseBetweenOperatorTest()
        {
            var clause = Clauses.Where("test").Between("first", "second");
            var expected = " WHERE test BETWEEN first AND second ";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseAndTest()
        {
            var clause = Clauses.Where("test").Is("test").And("abcd").Is("abcd");
            var expected = " WHERE test=test AND abcd=abcd";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }

        [Fact]
        public void WhereClauseOrTest()
        {
            var clause = Clauses.Where("test").Is("test").Or("abcd").Is("abcd");
            var expected = " WHERE test=test OR abcd=abcd";

            Assert.Equal(expected.Trim(), clause.ToString().Trim());
        }
    }
}
