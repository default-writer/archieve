using Microsoft.Win32;

namespace SharpKeys.API
{
    public static class RegistryHelper
    {
        const string registryHive = "System\\CurrentControlSet\\Control\\Keyboard Layout";

        public static byte[] LoadMappingsFromRegistry()
        {
            // now load the scan code map
            var regScanMapKey = Registry.LocalMachine.OpenSubKey(registryHive);
            if (regScanMapKey != null)
            {
                var bytes = (byte[])regScanMapKey.GetValue("Scancode Map");
                if (bytes == null)
                {
                    regScanMapKey.Close();
                    return new byte[0];
                }
                StringMappings.ReadRegistryBytes(bytes);
                regScanMapKey.Close();
                return bytes;
            }
            return new byte[0];
        }

        public static void SaveMappingsToRegistry(byte[] registryBytes)
        {
            // Open the key to save the scancodes
            var regScanMapKey = Registry.LocalMachine.CreateSubKey(registryHive);
            if (regScanMapKey != null)
            {
                var registryScanCodes = registryBytes;
                if (registryScanCodes.Length == 0)
                {
                    // the second param is required; this will throw an exception if the value isn't found,
                    // and it might not always be there (which is valid), so it's ok to ignore it
                    regScanMapKey.DeleteValue("Scancode Map", false);
                }
                else
                {
                    // dump to the registry
                    regScanMapKey.SetValue("Scancode Map", registryScanCodes);
                }
                regScanMapKey.Close();
            }
        }
    }
}