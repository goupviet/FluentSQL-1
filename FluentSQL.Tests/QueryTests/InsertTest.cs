using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentSQL.Tests.QueryTests
{
    public class InsertTest
    {
        [Fact]
        public void TestInsertSingleValue()
        {
            var query = Query.Insert().Table("abcd").Value("xyz", "xyz").Finish();
            var expected = "INSERT INTO abcd (xyz) VALUES ('xyz');";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestInsertMultipleValues()
        {
            var query = Query.Insert().Table("abcd")
                .Value("xyz", "xyz")
                .Value("qwerty", "something")
                .Value("zxc", "asdf")
                .Value("dapper", "@dapper")
                .Finish();

            var expected = "INSERT INTO abcd (xyz,qwerty,zxc,dapper) VALUES ('xyz','something','asdf',@dapper);";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestInsertNoTable()
        {
            Assert.Throws<InvalidOperationException>(() => Query.Insert().Finish());
        }
    }
}
