using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentSQL.Tests.QueryTests
{
    public class DeleteTest
    {
        [Fact]
        public void TestDeleteAll()
        {
            var query = FluentSQL.Delete().From(Clauses.From("table")).Finish();

            string expected = "DELETE FROM table;";

            Assert.Equal(expected, query.Query);
        }

        [Fact]
        public void TestDeleteWithWhere()
        {
            var query = FluentSQL.Delete().From(Clauses.From("table")).Where(Clauses.Where("xyz").GreaterEqualThan("3")).Finish();

            string expected = "DELETE FROM table WHERE xyz>=3;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestDeleteWithoutFrom()
        {
            Assert.Throws<InvalidOperationException>(() => FluentSQL.Delete().Finish());
        }

        [Fact]
        public void TestDeleteDapper()
        {
            var query = FluentSQL.Delete().From(Clauses.From("table")).Where(Clauses.Where("id").Is("@id")).Finish();

            string expected = "DELETE FROM table WHERE id=@id;";

            Assert.Equal(expected, query.ToString()); 
        }
    }
}
