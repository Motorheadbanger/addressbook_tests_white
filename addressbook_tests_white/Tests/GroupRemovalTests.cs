using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            if (applicationManager.GroupHelper.GetGroupList().Count == 1)
                applicationManager.GroupHelper.Add(new GroupData
                {
                    Name = "emergency group"
                });

            List<GroupData> initialGroupList = applicationManager.GroupHelper.GetGroupList();

            GroupData group = initialGroupList[0];

            applicationManager.GroupHelper.Delete(group);

            List<GroupData> modifiedGroupList = applicationManager.GroupHelper.GetGroupList();

            initialGroupList.Remove(group);
            initialGroupList.Sort();
            modifiedGroupList.Sort();

            Assert.AreEqual(initialGroupList, modifiedGroupList);
        }
    }
}
