using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        public string WINDOW_TITLE = "Free Address Book";
        public Window MainWindow { get; private set; }

        public GroupHelper GroupHelper { get; }

        public ApplicationManager()
        {
            Application application = Application.Launch(@"c:\ab\AddressBook.exe");

            MainWindow = application.GetWindow(WINDOW_TITLE);

            GroupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }
    }
}
