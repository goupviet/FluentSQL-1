using FluentSQL.Query;
using Xunit;

namespace FluentSQL.Tests.QueryTests
{
    public class SelectQueryTests
    {
        [Fact]
        public void TestSelectCollum()
        {
            IQuery query = FluentSQL.Select().Collum("test");

            string expected = "SELECT test;";
            string queryText = query.ToString();

            Assert.Equal(expected, queryText);
        }

        [Fact]
        public void TestSelectAll()
        {
            IQuery query = FluentSQL.Select().Collum("*");

            string expected = "SELECT *;";
            string queryText = query.ToString();

            Assert.Equal(expected, queryText);
        }

        [Fact]
        public void TestMultipleCollumsFromTable()
        {
            IQuery query = FluentSQL.Select().Collum("test").Collum("test2").Collum("test3");

            string expected = "SELECT test,test2,test3;";
            string queryText = query.ToString();

            Assert.Equal(expected, queryText);
        }

        [Fact]
        public void TestDistinctValue()
        {
            var query = FluentSQL.Select().DistinctCollum("abcd");
            string expect = "SELECT DISTINCT abcd;";

            Assert.Equal(expect, query.ToString());
        }

        [Fact]
        public void TestSelectWithFromClause()
        {
            var query = FluentSQL.Select().Collum("abcd").AddClause(
                Clauses.From("table")
                );

            string expected = "SELECT abcd FROM table;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithWhereClause()
        {
            var query = FluentSQL.Select().Collum("abcd").AddClause(
                Clauses.Where("id").Is("5")
                );

            string expected = "SELECT abcd WHERE id=5;";
            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithFromAndWhereClauses()
        {
            var query = FluentSQL.Select().Collum("abcd").AddClause(
                Clauses.From("table").InnerJoin("other").On("id1", "id2")
                ).AddClause(
                    Clauses.Where("id3").IsNot("id4")
                );

            string expected = "SELECT abcd FROM table INNER JOIN other ON id1=id2 WHERE id3<>id4;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithFromWhereAndOrderByClauses()
        {
            var query = FluentSQL.Select().Collum("abcd").AddClause(
                Clauses.From("table").InnerJoin("other").On("id1", "id2")
                ).AddClause(
                    Clauses.Where("id3").IsNot("id4")
                ).AddClause(
                    Clauses.OrderBy("param")
                );

            string expected = "SELECT abcd FROM table INNER JOIN other ON id1=id2 WHERE id3<>id4 ORDER BY param;";

            Assert.Equal(expected, query.ToString());
        }
    }
}
