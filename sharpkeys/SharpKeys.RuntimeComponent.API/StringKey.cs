namespace SharpKeys.RuntimeComponent.API
{
    public sealed class StringKey
    {
        public StringKey(int scancode, string description)
        {
            ScanCode = scancode;
            Description = description;
            var b0 = (byte)(scancode & 0xff);
            var b1 = (byte)((scancode & 0xff00) >> 8);
            ByteScanCode = new byte[2] { b0, b1 };
        }

        public byte[] ByteScanCode { get; }
        public string Description { get; }
        public int ScanCode { get; }
        public string Text => string.Format("{0} ({1})", Description, TextScanCode);

        public string TextScanCode => string.Format("{0,2:X}_{1,2:X}", ByteScanCode[1], ByteScanCode[0]).Replace(" ", "0");
    }
}