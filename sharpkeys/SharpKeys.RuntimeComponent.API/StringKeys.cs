using System.Collections.Generic;
using System.Linq;

namespace SharpKeys.RuntimeComponent.API
{
    public sealed class StringKeys
    {
        internal static readonly StringKeys Instance = new StringKeys();

        readonly (int ScanCode, string Description)[] keys =
        {
            (0x00_00, "-- Turn Key Off"),
            (0x00_01, "Special: Escape"),
            (0x00_02, "Key: 1 !"),
            (0x00_03, "Key: 2 @"),
            (0x00_04, "Key: 3 #"),
            (0x00_05, "Key: 4 $"),
            (0x00_06, "Key: 5 %"),
            (0x00_07, "Key: 6 ^"),
            (0x00_08, "Key: 7 &"),
            (0x00_09, "Key: 8 *"),
            (0x00_0A, "Key: 9 ("),
            (0x00_0B, "Key: 0 )"),
            (0x00_0C, "Key: - _"),
            (0x00_0D, "Key: = +"),
            (0x00_0E, "Special: Backspace"),
            (0x00_0F, "Special: Tab"),

            (0x00_10, "Key: Q"),
            (0x00_11, "Key: W"),
            (0x00_12, "Key: E"),
            (0x00_13, "Key: R"),
            (0x00_14, "Key: T"),
            (0x00_15, "Key: Y"),
            (0x00_16, "Key: U"),
            (0x00_17, "Key: I"),
            (0x00_18, "Key: O"),
            (0x00_19, "Key: P"),
            (0x00_1A, "Key: [ {"),
            (0x00_1B, "Key: ] }"),
            (0x00_1C, "Special: Enter"),
            (0x00_1D, "Special: Left Ctrl"),
            (0x00_1E, "Key: A"),
            (0x00_1F, "Key: S"),

            (0x00_20, "Key: D"),
            (0x00_21, "Key: F"),
            (0x00_22, "Key: G"),
            (0x00_23, "Key: H"),
            (0x00_24, "Key: J"),
            (0x00_25, "Key: K"),
            (0x00_26, "Key: L"),
            (0x00_27, "Key: , :"),
            (0x00_28, "Key: ' \""),
            (0x00_29, "Key: ` ~"),
            (0x00_2A, "Special: Left Shift"),
            (0x00_2B, "Key: \\ |"),
            (0x00_2C, "Key: Z"),
            (0x00_2D, "Key: X"),
            (0x00_2E, "Key: C"),
            (0x00_2F, "Key: V"),

            (0x00_30, "Key: B"),
            (0x00_31, "Key: N"),
            (0x00_32, "Key: M"),
            (0x00_33, "Key: , <"),
            (0x00_34, "Key: . >"),
            (0x00_35, "Key: / ?"),
            (0x00_36, "Special: Right Shift"),
            (0x00_37, "Num: *"),
            (0x00_38, "Special: Left Alt"),
            (0x00_39, "Special: Space"),
            (0x00_3A, "Special: Caps Lock"),
            (0x00_3B, "Function: F1"),
            (0x00_3C, "Function: F2"),
            (0x00_3D, "Function: F3"),
            (0x00_3E, "Function: F4"),
            (0x00_3F, "Function: F5"),

            (0x00_40, "Function: F6"),
            (0x00_41, "Function: F7"),
            (0x00_42, "Function: F8"),
            (0x00_43, "Function: F9"),
            (0x00_44, "Function: F10"),
            (0x00_45, "Special: Num Lock"),
            (0x00_46, "Special: Scroll Lock"),
            (0x00_47, "Num: 7"),
            (0x00_48, "Num: 8"),
            (0x00_49, "Num: 9"),
            (0x00_4A, "Num: -"),
            (0x00_4B, "Num: 4"),
            (0x00_4C, "Num: 5"),
            (0x00_4D, "Num: 6"),
            (0x00_4E, "Num: +"),
            (0x00_4F, "Num: 1"),

            (0x00_50, "Num: 2"),
            (0x00_51, "Num: 3"),
            (0x00_52, "Num: 0"),
            (0x00_53, "Num: ."),
            (0x00_56, "Special: ISO extra key"),
            (0x00_57, "Function: F11"),
            (0x00_58, "Function: F12"),

            (0x00_64, "Function: F13"),
            (0x00_65, "Function: F14"),
            (0x00_66, "Function: F15"),
            (0x00_67, "Function: F16"), // Mac keyboard
            (0x00_68, "Function: F17"), // Mac keyboard
            (0x00_69, "Function: F18"), // Mac keyboard
            (0x00_6A, "Function: F19"), // Mac keyboard
            (0x00_6B, "Function: F20"), // IBM Model F 122-keys
            (0x00_6C, "Function: F21"), // IBM Model F 122-keys
            (0x00_6D, "Function: F22"), // IBM Model F 122-keys
            (0x00_6E, "Function: F23"), // IBM Model F 122-keys
            (0x00_6F, "Function: F24"), // IBM Model F 122-keys

            (0x00_7D, "Special: ¥ -"),

            (0xE0_07, "F-Lock: Redo"), //   F3 - Redo
            (0xE0_08, "F-Lock: Undo"), //   F2 - Undo

            (0xE0_10, "Media: Prev Track"),
            (0xE0_11, "App: Messenger"),
            (0xE0_12, "Logitech: Webcam"),
            (0xE0_13, "Logitech: iTouch"),
            (0xE0_14, "Logitech: Shopping"),
            (0xE0_19, "Media: Next Track"),
            (0xE0_1C, "Num: Enter"),
            (0xE0_1D, "Special: Right Ctrl"),

            (0xE0_20, "Media: Mute"),
            (0xE0_21, "App: Calculator"),
            (0xE0_22, "Media: Play/Pause"),
            (0xE0_23, "F-Lock: Spell"), //   F10
            (0xE0_24, "Media: Stop"),
            (0xE0_2E, "Media: Volume Down"),

            (0xE0_30, "Media: Volume Up"),
            (0xE0_32, "Web: Home"),
            (0xE0_35, "Num: /"),
            (0xE0_37, "Special: PrtSc"),
            (0xE0_38, "Special: Right Alt"),
            (0xE0_3B, "F-Lock: Help"),        //   F1
            (0xE0_3C, "F-Lock: Office Home"), //   F2 - Office Home
            (0xE0_3D, "F-Lock: Task Pane"),   //   F3 - Task pane
            (0xE0_3E, "F-Lock: New"),         //   F4
            (0xE0_3F, "F-Lock: Open"),        //   F5

            (0xE0_40, "F-Lock: Close"),       //   F6
            (0xE0_41, "F-Lock: Reply"),       //   F7
            (0xE0_42, "F-Lock: Fwd"),         //   F8
            (0xE0_43, "F-Lock: Send"),        //   F9
            (0xE0_45, "Special: €"),        //   Euro
            (0xE0_47, "Special: Home"),
            (0xE0_48, "Arrow: Up"),
            (0xE0_49, "Special: Page Up"),
            (0xE0_4B, "Arrow: Left"),
            (0xE0_4D, "Arrow: Right"),
            (0xE0_4F, "Special: End"),

            (0xE0_50, "Arrow: Down"),
            (0xE0_51, "Special: Page Down"),
            (0xE0_52, "Special: Insert"),
            (0xE0_53, "Special: Delete"),
            (0xE0_56, "Special: < > |"),
            (0xE0_57, "F-Lock: Save"),        //   F11
            (0xE0_58, "F-Lock: Print"),       //   F12
            (0xE0_5B, "Special: Left Windows"),
            (0xE0_5C, "Special: Right Windows"),
            (0xE0_5D, "Special: Application"),
            (0xE0_5E, "Special: Power"),
            (0xE0_5F, "Special: Sleep"),

            (0xE0_63, "Special: Wake (or Fn)"),
            (0xE0_65, "Web: Search"),
            (0xE0_66, "Web: Favorites"),
            (0xE0_67, "Web: Refresh"),
            (0xE0_68, "Web: Stop"),
            (0xE0_69, "Web: Forward"),
            (0xE0_6A, "Web: Back"),
            (0xE0_6B, "App: My Computer"),
            (0xE0_6C, "App: E-Mail"),
            (0xE0_6D, "App: Media Select")
        };

        // Dictionary for tracking text to scan codes
        readonly Dictionary<int, StringKey> m_hashKeys = new Dictionary<int, StringKey>();

        StringKeys()
        {
            // the hash table uses a string in the form of Hi_Lo scan code (in Hex values)
            // that most sources say are scan codes.  The 00_00 will disable a key - everything else
            // is pretty obvious.  There is a bit of a reverse lookup however, so labels changed here
            // need to be changed in a couple of other places
            foreach (var (ScanCode, Description) in keys)
            {
                Add(ScanCode, Description);
            }
        }

        public IEnumerable<StringKey> Keys => m_hashKeys.Values;

        public StringKey GetStringKey(int scancode) => m_hashKeys.ContainsKey(scancode) ? m_hashKeys[scancode] : null;

        public void Add(int scancode, string description) => Add(new StringKey(scancode, description));

        public void Add(StringKey stringKey)
        {
            if (!m_hashKeys.ContainsKey(stringKey.ScanCode))
                m_hashKeys.Add(stringKey.ScanCode, stringKey);
            else
                m_hashKeys[stringKey.ScanCode] = stringKey;
        }

        public StringKey FindByDecription(string selectedItem) => m_hashKeys.Values.FirstOrDefault((p) => p.Description == selectedItem);

        public StringKey FindByText(string selectedItem) => m_hashKeys.Values.FirstOrDefault((p) => p.Text == selectedItem);

        public StringKey Get(int scancode, string description)
        {
            if (!m_hashKeys.ContainsKey(scancode))
                return new StringKey(scancode, description);
            return m_hashKeys[scancode];
        }

        public IEnumerable<StringKey> KeysExcept(StringKey stringKey) => m_hashKeys.Values.Where((p) => p.ScanCode != stringKey.ScanCode);
    }
}