namespace SharpKeys
{
    static class ArrayHelpers
    {
        public static bool IsEquals(byte[] src, byte[] dst)
        {
            if (src == null || dst == null || src.Length != dst.Length)
                return false;

            for (int i = 0; i < dst.Length; i++)
                if (src[i] != dst[i])
                    return false;

            return true;
        }
    }
}