using SharpKeys.API;
using System.Windows.Forms;

namespace SharpKeys
{
    public class EditStringMappingDialog : IUserAction
    {
        readonly StringMapping m_stringMapping;
        DialogResult dialogResult;

        readonly KeyItemDialog keyItemDialog = new KeyItemDialog
        {
            Text = "SharpKeys: Edit Key Mapping"
        };

        public EditStringMappingDialog(StringMapping stringMapping) => m_stringMapping = stringMapping;

        public void Execute()
        {
            keyItemDialog.EditStringMapping(m_stringMapping);
            dialogResult = keyItemDialog.ShowDialog();
        }

        public bool Succees => dialogResult == DialogResult.OK;
    }
}