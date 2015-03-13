using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentSQL.Tests.QueryTests
{
    public class UpdateTest
    {
        [Fact]
        public void TestUpdateWithoutWhere()
        {
            var query = FluentSQL.Update("abcd")
                .Set("Name", "peter")
                .Finish();

            var expected = "UPDATE abcd SET Name=peter;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestUpdateWithMultipleSets()
        {
            var query = FluentSQL.Update("abcd")
                .Set("Name", "peter")
                .Set("Age", "30")
                .Finish();

            var expected = "UPDATE abcd SET Name=peter,Age=30;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestUpdateWithWhere()
        {
            var query = FluentSQL.Update("abcd")
                .Set("Name", "peter")
                .Where(Clauses.Where("Age").Is("30"))
                .Finish();

            var expected = "UPDATE abcd SET Name=peter WHERE Age=30;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestUpdateMultipleSetsWithWhere()
        {
            var query = FluentSQL.Update("abcd")
                .Set("Name", "peter")
                .Set("Age", "30")
                .Where(Clauses.Where("Age").LessThan("25"))
                .Finish();

            var expected = "UPDATE abcd SET Name=peter,Age=30 WHERE Age<25;";

            Assert.Equal(expected, query.ToString());     
        }
    }
}
