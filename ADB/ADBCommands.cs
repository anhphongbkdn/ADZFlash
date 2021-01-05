using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADZFlash.ADB
{
    class ADBCommands
    {
        public static string DEVICES = "fastboot devices";
        public static string CONNECT_DEVICE = "adb connect {0}";
        public static string EXCUTEADBCOMMAND = "adb -s {0} {1}";
        public static string EXCUTEADBSHELLCOMMAND = "adb -s {0} shell {1}";
        public static string CHECK_BOOTED = "adb -s {0} shell getprop dev.bootcomplete";
        public static string PULL_FILE = "adb -s {0} pull \"{1}\" \"{2}\"";
        public static string PUSH_FILE = "adb -s {0} push \"{1}\" \"{2}\"";
        public static string TAP = "adb -s {0} shell input tap {1} {2}";
        public static string SWIPE = "adb -s {0} shell input swipe {1} {2} {3} {4} {5}";
        public static string INPUT_TEXT = "adb -s {0} shell input text {1}";
        public static string INPUT_KEYS = "adb -s {0} shell input keyevent {1}";
        public static string LOGGIN_CMD = "adb -s {0} shell am start -a android.settings.ADD_ACCOUNT_SETTINGS --es account_types \"com.google\"";
        public static string LOGOUT_CMD = "adb -s {0} shell am start -a android.settings.SYNC_SETTINGS --es account_types \"com.google\"";
        public static string GET_LAYOUT = "adb -s {0} shell uiautomator dump /sdcard/layout.xml";
        public static string GET_MAIN_ACTIVITY = "adb -s {0} shell \"dumpsys window windows | grep -E 'mCurrentFocus|mFocusedApp'\"";
        public static string GET_LIST_PACKAGES = "adb -s {0} shell pm list package -3";
        public static string OPEN_APP = "adb -s {0} shell monkey -p {1} -c android.intent.category.LAUNCHER 1";
        public static string CLOSE_APP = "adb -s {0} shell am force-stop {1}";
        public static string WIPE_APP = "adb -s {0} shell pm clear {1}";
        public static string INSTALL_APP = "adb -s {0} install {1}";
        public static string INSTALL_SHELL = "adb -s {0} shell pm install -r {1}";
        public static string UNINSTALL_APP = "adb -s {0} shell pm uninstall {1}";
        public static string OPEN_URL = "adb -s {0} shell \"am start -a android.intent.action.VIEW -d '{1}'\"";
        public static string CHMOD = "adb -s {0} shell chmod {1} {2}";
        public static string SCREEN_CAP = "adb -s {0} shell screencap -p {1}";
    }
}
