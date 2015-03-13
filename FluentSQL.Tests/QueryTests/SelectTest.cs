using System;
using FluentSQL.Query;
using Xunit;

namespace FluentSQL.Tests.QueryTests
{
    public class SelectQueryTests
    {
        [Fact]
        public void TestSelectCollum()
        {
            Assert.Throws<InvalidOperationException>(() => FluentSQL.Select().Collum("test").Finish());
        }

        [Fact]
        public void TestDistinctValue()
        {
            var query = FluentSQL.Select().
                DistinctCollum("abcd")
                .From(Clauses.From("table"))
                .Finish();

            string expected = "SELECT DISTINCT abcd FROM table;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithFromClause()
        {
            var query = FluentSQL.Select().Collum("abcd")
                .From(Clauses.From("table"))
                .Finish();

            string expected = "SELECT abcd FROM table;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithWhereClause()
        {
            var query = FluentSQL.Select().Collum("abcd")
                .From(Clauses.From("table"))
                .Where(Clauses.Where("id").Is("5"))
                .Finish();

            string expected = "SELECT abcd FROM table WHERE id=5;";
            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithFromAndWhereClauses()
        {
            var query = FluentSQL.Select().Collum("abcd")
                .From(Clauses.From("table").InnerJoin("other").On("id1", "id2"))
                .Where(Clauses.Where("id3").IsNot("id4"))
                .Finish();

            string expected = "SELECT abcd FROM table INNER JOIN other ON id1=id2 WHERE id3<>id4;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithFromWhereAndOrderByClauses()
        {
            var query = FluentSQL.Select().Collum("abcd")
                .From(Clauses.From("table").InnerJoin("other").On("id1", "id2"))
                .Where(Clauses.Where("id3").IsNot("id4"))
                .OrderBy(Clauses.OrderBy("param"))
                .Finish();

            string expected = "SELECT abcd FROM table INNER JOIN other ON id1=id2 WHERE id3<>id4 ORDER BY param;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithUnorderedClauseInsert()
        {
            var query = FluentSQL.Select().Collum("abcd")
                .OrderBy(Clauses.OrderBy("param"))
                .From(Clauses.From("table").InnerJoin("other").On("id1", "id2"))
                .Where(Clauses.Where("id3").IsNot("id4"))
                .Finish();

            string expected = "SELECT abcd FROM table INNER JOIN other ON id1=id2 WHERE id3<>id4 ORDER BY param;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSettingClausesMultipleTimes()
        {
            var query =
                FluentSQL.Select()
                    .Collum("abcd")
                    .Collum("abcd")
                    .From(Clauses.From("table"))
                    .From(Clauses.From("table"))
                    .Finish();

            string expected = "SELECT abcd FROM table;";

            Assert.Equal(expected, query.ToString());
        }
    }
}
