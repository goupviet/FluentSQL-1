using FluentSQL.Query;
using Xunit;

namespace FluentSQL.Tests.QueryTests
{
    public class SelectQueryTests
    {
        [Fact]
        public void SelectCollumFromTable()
        {
            IQuery query = FluentSQL.Select().Collum("test").From("tablename");

            string expected = "SELECT test FROM tablename;";
            string queryText = query.ToString();

            Assert.Equal(expected, queryText);
        }

        [Fact]
        public void SelectAllFromTable()
        {
            IQuery query = FluentSQL.Select().Collum("*").From("tablename");

            string expected = "SELECT * FROM tablename;";
            string queryText = query.ToString();

            Assert.Equal(expected, queryText);
        }

        [Fact]
        public void TestMultipleCollumsFromTable()
        {
            IQuery query = FluentSQL.Select().Collum("test").Collum("test2").Collum("test3")
                .From("tablename");

            string expected = "SELECT test,test2,test3 FROM tablename;";
            string queryText = query.ToString();

            Assert.Equal(expected, queryText);
        }
    }
}
