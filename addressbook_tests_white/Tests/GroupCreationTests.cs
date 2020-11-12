using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> initialGroupList = applicationManager.GroupHelper.GetGroupList();
            GroupData group = new GroupData()
            {
                Name = "test"
            };

            applicationManager.GroupHelper.Add(group);

            List<GroupData> modifiedGroupList = applicationManager.GroupHelper.GetGroupList();

            initialGroupList.Add(group);
            initialGroupList.Sort();
            modifiedGroupList.Sort();

            Assert.AreEqual(initialGroupList, modifiedGroupList);
        }
    }
}
