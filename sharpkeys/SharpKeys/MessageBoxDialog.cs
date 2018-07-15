using SharpKeys.API;
using System.Windows.Forms;

namespace SharpKeys
{
    public class MessageBoxDialog : IUserAction
    {
        readonly MessageBoxParameters messageBoxParameters;
        DialogResult dialogResult;

        public MessageBoxDialog(string text, string caption) => messageBoxParameters = new MessageBoxParameters { Text = text, Caption = caption };

        public void Execute() => dialogResult = MessageBox.Show(messageBoxParameters.Text, messageBoxParameters.Caption);

        public bool Succees => dialogResult == DialogResult.OK;
    }
}