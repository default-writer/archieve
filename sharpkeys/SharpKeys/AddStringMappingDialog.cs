using SharpKeys.API;
using System.Windows.Forms;

namespace SharpKeys
{
    public class AddStringMappingDialog : IUserAction
    {
        readonly StringMapping m_stringMapping;

        DialogResult dialogResult;

        readonly KeyItemDialog keyItemDialog = new KeyItemDialog
        {
            Text = "SharpKeys: Add New Key Mapping"
        };

        public AddStringMappingDialog(StringMapping stringMapping) => m_stringMapping = stringMapping;

        public void Execute()
        {
            keyItemDialog.AddStringMapping(m_stringMapping);
            dialogResult = keyItemDialog.ShowDialog();
        }

        public bool Succees => dialogResult == DialogResult.OK;
    }
}