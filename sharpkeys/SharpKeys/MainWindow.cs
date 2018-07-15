using SharpKeys.API;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SharpKeys
{
    /// <summary>
    /// Summary description for Dialog_Main.
    /// </summary>
    public partial class MainWindow : Form, IApplicationState
    {
        byte[] m_currentRegistryBytes = new byte[0];
        byte[] m_savedRegistryBytes = new byte[0];

        StringMapping m_stringMapping;
        PersistentOptions m_windowOptions;

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if (WindowState == FormWindowState.Normal && m_windowOptions != null)
                m_windowOptions.DesktopBounds = DesktopBounds;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // resize the listview columns whenever sizeds
            lvcFrom.Width = lvKeys.Width / 2 - 2;
            lvcTo.Width = lvcFrom.Width - 2;
            if (WindowState == FormWindowState.Normal && m_windowOptions != null)
                m_windowOptions.DesktopBounds = DesktopBounds;
        }

        void LvKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            // UI stuff (to prevent editing or deleting a non-item
            if (lvKeys.SelectedItems.Count <= 0)
            {
                m_stringMapping = null;
                btnEdit.Enabled = mniEdit.Enabled = false;
                btnDelete.Enabled = mniDelete.Enabled = false;
            }
            else
            {
                m_stringMapping = (StringMapping)lvKeys.SelectedItems[0].Tag;
                btnEdit.Enabled = mniEdit.Enabled = true;
                btnDelete.Enabled = mniDelete.Enabled = true;
            }
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            // if anything has been added, edit'd or delete'd, ask if a save to the registry should be performed
            if (!ArrayHelpers.IsEquals(m_savedRegistryBytes, m_currentRegistryBytes))
            {
                var dlgRes = ShowDialog("You have made changes to the list of key mappings.\n\nDo you want to update the registry now?", "SharpKeys", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button3);
                switch (dlgRes)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;

                    case DialogResult.Yes:
                        SetWaitState();
                        MainWindowController.Save(this);
                        SetReadyState();
                        UserMessage("Key Mappings have been successfully stored to the registry.\n\nPlease logout or reboot for these changes to take effect!", "SharpKeys");
                        break;
                }
            }

            // Only save the window position info on close; user is prompted to save mappings elsewhere
            PersistentOptions.SetWindowState(new PersistentOptions() { WindowState = WindowState, DesktopBounds = DesktopBounds, ShowWarning = m_windowOptions.ShowWarning });
        }

        void UrlMain_CodeLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start(((LinkLabel)sender).Text);

        void UrlMain_MainLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start(((LinkLabel)sender).Text);

        DialogResult ShowDialog(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton) => MessageBox.Show(this, text, caption, buttons, icon, defaultButton);

        void LoadWindowDesktopBounds()
        {
            // First load the window positions from registry
            m_windowOptions = PersistentOptions.GetWindowState();
            if (m_windowOptions.ShowWarning == 0)
            {
                UserMessage("Welcome to SharpKeys!\n\nThis application will add one key to your registry that allows you\nto change how certain keys on your keyboard will work.\n\nYou must be running Windows 7/8/10 for this to be supported and\nyou'll be using SharpKeys at your own risk!\n\nEnjoy!\nexperimentalcommunity.org", "SharpKeys");
            }
        }

        void BtnAdd_Click(object sender, EventArgs e) => MainWindowController.AddStringMapping(this);

        void BtnClose_Click(object sender, EventArgs e) => Close();

        void BtnDelete_Click(object sender, EventArgs e) => MainWindowController.DeleteStringMapping(this);

        void BtnDeleteAll_Click(object sender, EventArgs e) => MainWindowController.DeleteAllStringMapping(this);

        void BtnEdit_Click(object sender, EventArgs e) => MainWindowController.EditStringMapping(this);

        void BtnSave_Click(object sender, EventArgs e) => MainWindowController.Save(this);

        void LvKeys_DoubleClick(object sender, EventArgs e) => MainWindowController.EditStringMapping(this);

        void MainWindow_Load(object sender, EventArgs e)
        {
            LoadWindowDesktopBounds();
            SetWaitState();
            SetWindowDesktopBounds();

            MainWindowController.Load(this);

            SelectFirstListViewItem();
            SetReadyState();
        }

        void MainWindow_Resize(object sender, EventArgs e) => Invalidate();

        void MniAdd_Click(object sender, EventArgs e) => MainWindowController.AddStringMapping(this);

        void MniDelete_Click(object sender, EventArgs e) => MainWindowController.DeleteStringMapping(this);

        void MniDeleteAll_Click(object sender, EventArgs e) => MainWindowController.DeleteAllStringMapping(this);

        void MniEdit_Click(object sender, EventArgs e) => MainWindowController.EditStringMapping(this);

        static void UserMessage(string text, string caption) => MessageBox.Show(text, caption);

        void SelectFirstListViewItem()
        {
            // UI tweaking
            if (lvKeys.Items.Count > 0)
                lvKeys.Items[0].Selected = true;
        }

        void SetWindowDesktopBounds()
        {
            WindowState = m_windowOptions.WindowState;
            DesktopBounds = m_windowOptions.DesktopBounds;
        }

        #region IApplicationState

        public StringMapping StringMapping => m_stringMapping;

        public void AddStringMapping(StringMapping stringMapping)
        {
            // Add the list, as it's past inspection.
            var lvI = lvKeys.Items.Add(stringMapping.TextFrom);
            lvI.SubItems.Add(stringMapping.TextTo);
            lvI.Tag = stringMapping;
            lvI.Selected = true;

            lvKeys.Focus();
        }

        public void DeleteAllStringMappings()
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
            lvKeys.Items.Clear();
        }

        public void DeleteStringMapping() => lvKeys.Items.Remove(lvKeys.SelectedItems[0]);

        public void UpdateStringMapping(StringMapping stringMapping)
        {
            lvKeys.SelectedItems[0].Text = stringMapping.TextFrom;
            lvKeys.SelectedItems[0].SubItems[1].Text = stringMapping.TextTo;
        }

        public void LoadRegistryBytes() => m_currentRegistryBytes = m_savedRegistryBytes = RegistryHelper.LoadMappingsFromRegistry();

        public void SaveRegistryBytes() => RegistryHelper.SaveMappingsToRegistry(m_savedRegistryBytes = m_currentRegistryBytes);

        public void SetReadyState() => Cursor = Cursors.Default;

        public void SetWaitState() => Cursor = Cursors.WaitCursor;

        public void UpdateCurentRegistryBytes() => m_currentRegistryBytes = StringMappings.GetRegistryBytes();

        public bool UserAcceptsWarningOnDeleteAllMappings() => ShowDialog("Deleting all will clear this list of key mapping but your registry will not be updated until you click \"Write to Registry\".\n\nDo you want to clear this list of key mappings?", "SharpKeys", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes;

        public IUserAction CreateAddStringMappingDialog(StringMapping stringMapping) => new AddStringMappingDialog(stringMapping);

        public IUserAction CreateEditStringMappingDialog(StringMapping stringMapping) => new EditStringMappingDialog(stringMapping);

        public IUserAction CreateMessageBoxDialog(string text, string caption) => new MessageBoxDialog(text, caption);

        #endregion IApplicationState
    }
}