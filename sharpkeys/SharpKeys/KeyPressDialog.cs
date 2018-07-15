using SharpKeys.API;
using System;
using System.Windows.Forms;

namespace SharpKeys
{
    /// <summary>
    /// Summary description for KeyPressDialog.
    /// </summary>
    public partial class KeyPressDialog : Form, IMessageFilter
    {
        public StringKey StringKey;

        const string DISABLED_KEY = "Key is disabled\n(00_00)";

        public bool PreFilterMessage(ref Message m)
        {
            //0x100 == WM_KEYDOWN
            if (m.Msg == 0x100)
                ShowKeyCode((int)m.LParam);
            return false;
        }

        void BtnCancel_Click(object sender, EventArgs e) => CancelButton = btnCancel;

        void BtnOK_Click(object sender, EventArgs e) => AcceptButton = btnOK;

        void KeyPressDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e) => Application.RemoveMessageFilter(this);

        void KeyPressDialog_Load(object sender, EventArgs e) => Application.AddMessageFilter(this);

        void KeyPressDialog_Resize(object sender, EventArgs e) => Invalidate();

        void ShowKeyCode(int nCode)
        {
            // set up UI label
            if (lblPressed.Text.Length == 0)
                lblPressed.Text = "You pressed: ";

            nCode = nCode >> 16;

            // zeroed bit 30 from documentation
            // https://msdn.microsoft.com/en-us/library/windows/desktop/ms646280%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396
            nCode = nCode & 0xBFFF;

            if (nCode == 0)
            {
                lblKey.Text = DISABLED_KEY;
                btnOK.Enabled = false;
                return;
            }

            // get the code from LPARAM
            // if it's more than 256 then it's an extended key and mapped to 0xE0nn
            // Look up the scan code in the hashtable
            string strShow = "";

            var stringKey = StringMappings.Instance[nCode];
            if (StringKeys.Instance[nCode] != null)
            {
                strShow = string.Format("{0}", StringKeys.Instance[nCode].Text);
            }
            else
            {
                strShow = "Scan code: " + stringKey.TextScanCode;
            }
            lblKey.Text = strShow;

            StringKey = stringKey;

            // UI to collect only valid scancodes
            btnOK.Enabled = true;
        }
    }
}