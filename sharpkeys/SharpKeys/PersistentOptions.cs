using Microsoft.Win32;
using System.Drawing;
using System.Windows.Forms;

namespace SharpKeys
{
    public class PersistentOptions
    {
        public Rectangle DesktopBounds = new Rectangle(10, 10, 750, 750);
        public int ShowWarning;
        public FormWindowState WindowState = FormWindowState.Normal;


        // Field for registy storage
        const string m_strRegKey = "Software\\SharpKeys";

        public static PersistentOptions GetWindowState()
        {
            var windowOptions = new PersistentOptions();
            var regKey = Registry.CurrentUser.OpenSubKey(m_strRegKey);
            if (regKey != null)
            {
                // Load Window Pos
                windowOptions.WindowState = (FormWindowState)regKey.GetValue("MainWinState", windowOptions.WindowState);
                windowOptions.DesktopBounds.X = (int)regKey.GetValue("MainX", windowOptions.DesktopBounds.X);
                windowOptions.DesktopBounds.Y = (int)regKey.GetValue("MainY", windowOptions.DesktopBounds.Y);
                windowOptions.DesktopBounds.Width = (int)regKey.GetValue("MainCX", windowOptions.DesktopBounds.Width);
                windowOptions.DesktopBounds.Height = (int)regKey.GetValue("MainCY", windowOptions.DesktopBounds.Height);
                windowOptions.ShowWarning = (int)regKey.GetValue("ShowWarning", windowOptions.ShowWarning);
                regKey.Close();
            }
            return windowOptions;
        }

        public static void SetWindowState(PersistentOptions windowOpitons)
        {
            var regKey = Registry.CurrentUser.CreateSubKey(m_strRegKey);
            if (regKey != null)
            {
                // Save Window Pos
                regKey.SetValue("MainWinState", (int)windowOpitons.WindowState);
                regKey.SetValue("MainX", windowOpitons.DesktopBounds.X);
                regKey.SetValue("MainY", windowOpitons.DesktopBounds.Y);
                regKey.SetValue("MainCX", windowOpitons.DesktopBounds.Width);
                regKey.SetValue("MainCY", windowOpitons.DesktopBounds.Height);
                regKey.SetValue("ShowWarning", 1);
                regKey.Close();
            }
        }
    }
}