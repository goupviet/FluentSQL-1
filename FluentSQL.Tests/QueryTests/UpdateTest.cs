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
            var query = Query.Update().Table("abcd")
                .Set("Name", "peter")
                .Finish();

            var expected = "UPDATE abcd SET Name=peter;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestUpdateWithMultipleSets()
        {
            var query = Query.Update().Table("abcd")
                .Set("Name", "peter")
                .Set("Age", "30")
                .Finish();

            var expected = "UPDATE abcd SET Name=peter,Age=30;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestUpdateWithWhere()
        {
            var query = Query.Update().Table("abcd")
                .Set("Name", "peter")
                .Where(Clause.Where("Age").Is("30"))
                .Finish();

            var expected = "UPDATE abcd SET Name=peter WHERE Age=30;";

            Assert.Equal(expected, query.ToString());
        }

        [Fact]
        public void TestUpdateMultipleSetsWithWhere()
        {
            var query = Query.Update().Table("abcd")
                .Set("Name", "peter")
                .Set("Age", "30")
                .Where(Clause.Where("Age").LessThan("25"))
                .Finish();

            var expected = "UPDATE abcd SET Name=peter,Age=30 WHERE Age<25;";

            Assert.Equal(expected, query.ToString());     
        }

        [Fact]
        public void TestUpdateWithoutTable()
        {
            Assert.Throws<InvalidOperationException>(() => Query.Update().Finish());
        }

        [Fact]
        public void TestUpdateWithDapper()
        {
            var query = Query.Update().Table("abcd")
                .Set("Name", "@name")
                .Set("Age", "@age")
                .Where(Clause.Where("Age").LessThan("25"))
                .Finish();

            var expected = "UPDATE abcd SET Name=@name,Age=@age WHERE Age<25;";

            Assert.Equal(expected, query.ToString()); 
        }
    }
}
