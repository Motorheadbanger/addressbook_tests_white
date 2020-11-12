using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPS_WINDOW_TITLE = "Group editor";

        public GroupHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groupList = new List<GroupData>();
            Window dialogWindow = OpenGroupsDialogue();
            Tree groupTree = dialogWindow.Get<Tree>("uxAddressTreeView");
            TreeNode root = groupTree.Nodes[0];

            foreach (TreeNode item in root.Nodes)
                groupList.Add(new GroupData
                {
                    Name = item.Text
                });

            CloseGroupsDialogue(dialogWindow);

            return groupList;
        }

        public void Add(GroupData group)
        {
            Window dialogWindow = OpenGroupsDialogue();

            dialogWindow.Get<Button>("uxNewAddressButton").Click();

            TextBox textBox = (TextBox) dialogWindow.Get(SearchCriteria.ByControlType(ControlType.Edit));

            textBox.Enter(group.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            CloseGroupsDialogue(dialogWindow);
        }

        public void Delete(GroupData group)
        {
            Window dialogWindow = OpenGroupsDialogue();
            Tree groupTree = dialogWindow.Get<Tree>("uxAddressTreeView");

            foreach (TreeNode node in groupTree.Nodes[0].Nodes)
            {
                if (group.Name == node.Text)
                {
                    node.Click();
                    break;
                }
            }

            dialogWindow.Get<Button>("uxDeleteAddressButton").Click();
            Window confirmDeleteWindow = dialogWindow.ModalWindow("Delete group");
            confirmDeleteWindow.Get<RadioButton>("uxDeleteAllRadioButton").Click();
            confirmDeleteWindow.Get<Button>("uxOKAddressButton").Click();

            CloseGroupsDialogue(dialogWindow);
        }

        private Window OpenGroupsDialogue()
        {
            applicationManager.MainWindow.Get<Button>("groupButton").Click();

            return applicationManager.MainWindow.ModalWindow(GROUPS_WINDOW_TITLE);
        }

        private void CloseGroupsDialogue(Window window)
        {
            window.Get<Button>("uxCloseAddressButton").Click();
        }
    }
}