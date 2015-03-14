using System;

using Xunit;

namespace FluentSQL.Tests.QueryTests
{
    public class SelectQueryTests
    {
        [Fact]
        public void TestSelectCollum()
        {
            Assert.Throws<InvalidOperationException>(() => Query.Select().Collum("test").Finish());
        }

        [Fact]
        public void TestDistinctValue()
        {
            var query = Query.Select().
                DistinctCollum("abcd")
                .From(Clause.From("table"))
                .Finish();

            string expected = "SELECT DISTINCT abcd FROM table;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithFromClause()
        {
            var query = Query.Select().Collum("abcd")
                .From(Clause.From("table"))
                .Finish();

            string expected = "SELECT abcd FROM table;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithWhereClause()
        {
            var query = Query.Select().Collum("abcd")
                .From(Clause.From("table"))
                .Where(Clause.Where("id").Is("5"))
                .Finish();

            string expected = "SELECT abcd FROM table WHERE id=5;";
            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithFromAndWhereClauses()
        {
            var query = Query.Select().Collum("abcd")
                .From(Clause.From("table").InnerJoin("other").On("id1", "id2"))
                .Where(Clause.Where("id3").IsNot("id4"))
                .Finish();

            string expected = "SELECT abcd FROM table INNER JOIN other ON id1=id2 WHERE id3<>id4;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithFromWhereAndOrderByClauses()
        {
            var query = Query.Select().Collum("abcd")
                .From(Clause.From("table").InnerJoin("other").On("id1", "id2"))
                .Where(Clause.Where("id3").IsNot("id4"))
                .OrderBy(Clause.OrderBy("param"))
                .Finish();

            string expected = "SELECT abcd FROM table INNER JOIN other ON id1=id2 WHERE id3<>id4 ORDER BY param;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSelectWithUnorderedClauseInsert()
        {
            var query = Query.Select().Collum("abcd")
                .OrderBy(Clause.OrderBy("param"))
                .From(Clause.From("table").InnerJoin("other").On("id1", "id2"))
                .Where(Clause.Where("id3").IsNot("id4"))
                .Finish();

            string expected = "SELECT abcd FROM table INNER JOIN other ON id1=id2 WHERE id3<>id4 ORDER BY param;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestSettingClausesMultipleTimes()
        {
            var query = Query.Select()
                    .Collum("abcd")
                    .Collum("abcd")
                    .From(Clause.From("table"))
                    .From(Clause.From("table"))
                    .Finish();

            string expected = "SELECT abcd FROM table;";

            Assert.Equal(expected, query.ToString());
        }
    }
}
