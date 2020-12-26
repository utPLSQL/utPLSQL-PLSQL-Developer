using System;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    //*FUNC: 11*/ BOOL (*IDE_Connected)();
    internal delegate bool IdeConnected();
    //*FUNC: 12*/ void (*IDE_GetConnectionInfo)(char **Username, char **Password, char **Database);
    internal delegate void IdeGetConnectionInfo(out IntPtr username, out IntPtr password, out IntPtr database);

    //*FUNC: 40*/ int (*SQL_Execute)(char *SQL);
    internal delegate int SqlExecute(string sql);
    //*FUNC: 42*/ BOOL (*SQL_Eof)();
    internal delegate bool SqlEof();
    //*FUNC: 43*/ int (*SQL_Next)();
    internal delegate int SqlNext();
    //*FUNC: 44*/ char *(*SQL_Field)(int Field);
    internal delegate IntPtr SqlField(int field);
    //*FUNC: 48*/ char *(*SQL_ErrorMessage)();
    internal delegate IntPtr SqlErrorMessage();

    //*FUNC: 69*/ void *(*IDE_CreatePopupItem)(int ID, int Index, char *Name, char *ObjectType);
    internal delegate void IdeCreatePopupItem(int id, int index, string name, string objectType);
    //*FUNC: 74*/ int (*IDE_GetPopupObject)(char **ObjectType, char **ObjectOwner, char **ObjectName, char **SubObject);
    internal delegate int IdeGetPopupObject(out IntPtr objectType, out IntPtr objectOwner, out IntPtr objectName, out IntPtr subObject);
    //*FUNC: 150*/ void (*IDE_CreateToolButton)(int ID, int Index, char *Name, char *BitmapFile, int BitmapHandle);
    internal delegate void IdeCreateToolButton(int id, int index, string name, string bitmapFile, long bitmapHandle);

    public class PlsqlDeveloperUtPlsqlPlugin
    {
        private const string PLUGIN_NAME = "utPLSQL Plugin";

        private const int PLUGIN_MENU_INDEX_ALLTESTS = 3;
        private const int PLUGIN_POPUP_INDEX = 1;

        private const string ABOUT_TEXT = "utPLSQL Plugin for PL/SQL Developer \r\nby Simon Martinelli, 72® Services LLC";

        private static PlsqlDeveloperUtPlsqlPlugin plugin;

        internal static IdeConnected connected;
        internal static IdeGetConnectionInfo getConnectionInfo;

        internal static SqlExecute sqlExecute;
        internal static SqlEof sqlEof;
        internal static SqlNext sqlNext;
        internal static SqlField sqlField;
        internal static SqlErrorMessage sqlErrorMessage;

        internal static IdeCreatePopupItem createPopupItem;
        internal static IdeGetPopupObject getPopupObject;
        internal static IdeCreateToolButton createToolButton;

        internal static int pluginId;

        private static TestResultWindow testResultWindow ;

        private PlsqlDeveloperUtPlsqlPlugin()
        {
            testResultWindow = new TestResultWindow();
        }

        #region DLL exported API
        [DllExport("IdentifyPlugIn", CallingConvention = CallingConvention.Cdecl)]
        public static string IdentifyPlugIn(int id)
        {
            if (plugin == null)
            {
                plugin = new PlsqlDeveloperUtPlsqlPlugin();
                pluginId = id;
            }
            return PLUGIN_NAME;
        }

        [DllExport("RegisterCallback", CallingConvention = CallingConvention.Cdecl)]
        public static void RegisterCallback(int index, IntPtr function)
        {
            switch (index)
            {
                case 11:
                    connected = (IdeConnected)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeConnected));
                    break;
                case 12:
                    getConnectionInfo = (IdeGetConnectionInfo)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeGetConnectionInfo));
                    break;
                case 40:
                    sqlExecute = (SqlExecute)Marshal.GetDelegateForFunctionPointer(function, typeof(SqlExecute));
                    break;
                case 42:
                    sqlEof = (SqlEof)Marshal.GetDelegateForFunctionPointer(function, typeof(SqlEof));
                    break;
                case 43:
                    sqlNext = (SqlNext)Marshal.GetDelegateForFunctionPointer(function, typeof(SqlNext));
                    break;
                case 44:
                    sqlField = (SqlField)Marshal.GetDelegateForFunctionPointer(function, typeof(SqlField));
                    break;
                case 48:
                    sqlErrorMessage = (SqlErrorMessage)Marshal.GetDelegateForFunctionPointer(function, typeof(SqlErrorMessage));
                    break;
                case 69:
                    createPopupItem = (IdeCreatePopupItem)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeCreatePopupItem));
                    break;
                case 74:
                    getPopupObject = (IdeGetPopupObject)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeGetPopupObject));
                    break;
                case 150:
                    createToolButton = (IdeCreateToolButton)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeCreateToolButton));
                    break;
            }
        }

        [DllExport("CreateMenuItem", CallingConvention = CallingConvention.Cdecl)]
        public static string CreateMenuItem(int index)
        {
            switch (index)
            {
                case 1:
                    return "TAB=Tools";
                case 2:
                    return "GROUP=utPLSQL";
                case PLUGIN_MENU_INDEX_ALLTESTS:
                    return "LARGEITEM=Run all tests of current user";
                default:
                    return "";
            }
        }

        [DllExport("OnActivate", CallingConvention = CallingConvention.Cdecl)]
        public static void OnActivate()
        {
            try
            {
                // Two seperate streams are needed!
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("PlsqlDeveloperUtPlsqlPlugin.utPLSQL.bmp"))
                {
                    createToolButton(pluginId, PLUGIN_MENU_INDEX_ALLTESTS, "utPLSQL", "utPLSQL.bmp", new Bitmap(stream).GetHbitmap().ToInt64());
                }
                using (Stream stream = assembly.GetManifestResourceStream("PlsqlDeveloperUtPlsqlPlugin.utPLSQL.bmp"))
                {
                    createToolButton(pluginId, PLUGIN_POPUP_INDEX, "utPLSQL", "utPLSQL.bmp", new Bitmap(stream).GetHbitmap().ToInt64());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            createPopupItem(pluginId, PLUGIN_POPUP_INDEX, "Run utPLSQL Test", "USER");
            createPopupItem(pluginId, PLUGIN_POPUP_INDEX, "Run utPLSQL Test", "PACKAGE");
        }

        [DllExport("OnMenuClick", CallingConvention = CallingConvention.Cdecl)]
        public static void OnMenuClick(int index)
        {
            if (index == PLUGIN_MENU_INDEX_ALLTESTS)
            {
                if (PlsqlDeveloperUtPlsqlPlugin.connected())
                {
                    IntPtr username;
                    IntPtr password;
                    IntPtr database;
                    getConnectionInfo(out username, out password, out database);

                    testResultWindow.RunTests("_ALL", Marshal.PtrToStringAnsi(username), null, null);
                }
            }
            else if (index == PLUGIN_POPUP_INDEX)
            {
                if (PlsqlDeveloperUtPlsqlPlugin.connected())
                {
                    IntPtr type;
                    IntPtr owner;
                    IntPtr name;
                    IntPtr subType;
                    getPopupObject(out type, out owner, out name, out subType);

                    testResultWindow.RunTests(Marshal.PtrToStringAnsi(type), Marshal.PtrToStringAnsi(owner), Marshal.PtrToStringAnsi(name), Marshal.PtrToStringAnsi(subType));
                }
            }
        }

        [DllExport("About", CallingConvention = CallingConvention.Cdecl)]
        public static string About()
        {
            MessageBox.Show(ABOUT_TEXT);
            return "";
        }
        #endregion
    }
}
