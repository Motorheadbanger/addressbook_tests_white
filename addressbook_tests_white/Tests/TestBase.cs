using NUnit.Framework;

namespace addressbook_tests_white
{
    public class TestBase
    {
        public ApplicationManager applicationManager;

        [TestFixtureSetUp]
        public void InitApplication()
        {
            applicationManager = new ApplicationManager();
        }

        [TestFixtureTearDown]
        public void StopApplication()
        {
            applicationManager.Stop();
        }
    }
}
