using SharpKeys.API;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SharpKeys
{
    public partial class KeyItemDialog : Form
    {
        StringMapping m_stringMapping;

        #region IUserDialog

        public void AddStringMapping(StringMapping stringMapping)
        {
            m_stringMapping = stringMapping;
            LoadListViewItems();
            LoadDefaultStringMapping();
        }

        public void EditStringMapping(StringMapping stringMapping)
        {
            m_stringMapping = stringMapping;
            LoadListViewItems();
            LoadSelectedStringMapping();
        }

        #endregion IUserDialog

        void AddFromStringKey()
        {
            // Pop open the "typing" form to collect keyboard input to get a valid code
            var dlg = new KeyPressDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var selectedKey = StringKeys.Instance.FindByText(dlg.StringKey.Text);
                if (selectedKey == null)
                {
                    var stringKey = StringMappings.Instance[dlg.StringKey.ScanCode];
                    StringKeys.Instance.Add(stringKey);
                    LoadFromStringMapping(stringKey.Text);
                }
                lbFrom.SelectedItem = dlg.StringKey.Text;
                m_stringMapping.SetFromKey(dlg.StringKey);
            }
        }

        void AddToStringKey()
        {
            // Pop open the "typing" form to collect keyboard input to get a valid code
            var dlg = new KeyPressDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var selectedKey = StringKeys.Instance.FindByText(dlg.StringKey.Text);
                if (selectedKey == null)
                {
                    var stringKey = StringMappings.Instance[dlg.StringKey.ScanCode];
                    StringKeys.Instance.Add(stringKey);
                    LoadToStringMapping(stringKey.Text);
                }
                lbTo.SelectedItem = dlg.StringKey.Text;
                m_stringMapping.SetToKey(dlg.StringKey);
            }
        }

        void BtnFrom_Click(object sender, EventArgs e) => AddFromStringKey();

        void BtnTo_Click(object sender, EventArgs e) => AddToStringKey();

        void KeyItemDialog_Resize(object sender, EventArgs e) => Invalidate();

        void LbFrom_SelectedIndexChanged(object sender, EventArgs e) => SetFromStringKey();

        void LbTo_SelectedIndexChanged(object sender, EventArgs e) => SetToStringKey();

        void LoadDefaultStringMapping()
        {
            lbFrom.SelectedIndex = 0;
            lbTo.SelectedIndex = 0;
        }

        void LoadListViewItems()
        {
            foreach (var item in StringKeys.Instance.KeysExcept(StringKeys.Instance[0]).Except(StringMappings.FromKeys))
            {
                lbFrom.Items.Add(item.Text);
            }

            foreach (var item in StringKeys.Instance.Keys.Except(StringMappings.ToKeys))
            {
                lbTo.Items.Add(item.Text);
            }
        }

        void LoadSelectedStringMapping()
        {
            LoadFromStringMapping(m_stringMapping.TextFrom);
            LoadToStringMapping(m_stringMapping.TextTo);
        }

        void SetFromStringKey()
        {
            var selected = (string)lbFrom.SelectedItem;
            if (selected != null)
            {
                var selectedKey = StringKeys.Instance.FindByText(selected);
                m_stringMapping.SetFromKey(selectedKey);
            }
        }

        void SetToStringKey()
        {
            var selected = (string)lbTo.SelectedItem;
            if (selected != null)
            {
                var stringKey = StringKeys.Instance.FindByText(selected);
                m_stringMapping.SetToKey(stringKey);
            }
        }

        void LoadFromStringMapping(string selectedText)
        {
            var nPos = lbFrom.FindString(selectedText);
            if (nPos == -1)
                nPos = lbFrom.Items.Add(selectedText);

            // as it's an edit, set the drop down lists to the current From value
            if (nPos > -1)
                lbFrom.SelectedIndex = nPos;
            else
                lbFrom.SelectedIndex = 0;
        }

        void LoadToStringMapping(string selectedText)
        {
            var nPos = lbTo.FindString(selectedText);
            if (nPos == -1)
                nPos = lbTo.Items.Add(selectedText);

            // as it's an edit, set the drop down lists to the current To value
            if (nPos > -1)
                lbTo.SelectedIndex = nPos;
            else
                lbTo.SelectedIndex = 0;
        }
    }
}