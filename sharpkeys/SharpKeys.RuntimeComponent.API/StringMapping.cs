namespace SharpKeys.RuntimeComponent.API
{
    /// <summary>
    /// ListViewItemModel
    /// </summary>
    public sealed class StringMapping
    {
        readonly byte[] m_registryScanCode;
        readonly StringMappings m_stringMappings;

        public StringMapping(StringMappings stringMappings, byte b0, byte b1, byte b2, byte b3)
        {
            m_stringMappings = stringMappings;
            m_registryScanCode = new byte[4] { b0, b1, b2, b3 };
        }

        public StringMapping(StringMappings stringMappings, int scanCodeFrom, int scanCodeTo)
        {
            var b0 = (byte)((scanCodeFrom & 0xff00) >> 8);
            var b1 = (byte)(scanCodeFrom & 0xff);
            var b2 = (byte)((scanCodeTo & 0xff00) >> 8);
            var b3 = (byte)(scanCodeTo & 0xff);

            m_stringMappings = stringMappings;
            m_registryScanCode = new byte[4] { b3, b2, b1, b0 };
        }

        public StringKey From => m_stringMappings.GetStringKey(FromScanCode);
        public int FromScanCode => (m_registryScanCode[3] << 8) | m_registryScanCode[2];
        public string TextFrom => From.Text;
        public string TextTo => To.Text;
        public StringKey To => m_stringMappings.GetStringKey(ToScanCode);
        public int ToScanCode => (m_registryScanCode[1] << 8) | m_registryScanCode[0];

        public byte[] GetRegistryScanCode() => m_registryScanCode;

        public void SetFromKey(StringKey key)
        {
            m_registryScanCode[3] = key.ByteScanCode[1];
            m_registryScanCode[2] = key.ByteScanCode[0];
        }

        public void SetToKey(StringKey key)
        {
            m_registryScanCode[1] = key.ByteScanCode[1];
            m_registryScanCode[0] = key.ByteScanCode[0];
        }
    }
}