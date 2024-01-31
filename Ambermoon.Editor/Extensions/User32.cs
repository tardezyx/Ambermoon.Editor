using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Ambermoon.Editor.Extensions {
#pragma warning disable CA1069 // Enumerationswerte dürfen nicht dupliziert werden
#pragma warning disable CA1401 // P/Invokes dürfen nicht sichtbar sein
#pragma warning disable SYSLIB1054 // Verwenden Sie \"LibraryImportAttribute\" anstelle von \"DllImportAttribute\", um P/Invoke-Marshallingcode zur Kompilierzeit zu generieren.
  public static class User32 {
    #region === ENUMS =============================================================================
    #region --- AC:     blend function ------------------------------------------------------------
    public enum Blend : byte {
      SourceAlpha = 0x01,
      SourceOver  = 0x00
    }
    #endregion
    #region --- DCDIT:  displayconfig device info type --------------------------------------------
    public enum DisplayconfigDeviceInfoType : uint {
      ForceUint32            = 0xFFFFFFFF,
      GetAdapterName         = 4,
      GetSourceName          = 1,
      GetTargetBaseType      = 6,
      GetTargetName          = 2,
      GetTargetPreferredMode = 3,
      SetTargetPersistence   = 5,
    }
    #endregion
    #region --- DCMIT:  displayconfig mode info type ----------------------------------------------
    public enum DisplayconfigModeInfoType : uint {
      ForceUint32 = 0xFFFFFFFF,
      Source      = 1,
      Target      = 2
    }
    #endregion
    #region --- DCOT:   displayconfig output technology -------------------------------------------
    public enum DisplayconfigOutputTechnology : uint {
      ComponentVideo      = 3,
      CompositeVideo      = 2,
      DisplayportEmbedded = 11,
      DisplayportExternal = 10,
      DJpn                = 8,
      DVI                 = 4,
      ForceUint32         = 0xFFFFFFFF,
      HD15                = 0,
      HDMI                = 5,
      Internal            = 0x80000000,
      LVDS                = 6,
      Miracast            = 15,
      Other               = 0xFFFFFFFF,
      SDI                 = 9,
      SDTVDongle          = 14,
      SVideo              = 1,
      UdiEmbedded         = 13,
      UdiExternal         = 12
    }
    #endregion
    #region --- DCPF:   displayconfig pixelformat -------------------------------------------------
    public enum DisplayconfigPixelformat : uint {
      BPP8        = 1,
      BPP16       = 2,
      BPP24       = 3,
      BPP32       = 4,
      ForceUint32 = 0xffffffff,
      NonGDI      = 5
    }
    #endregion
    #region --- DCR:    displayconfig rotation ----------------------------------------------------
    public enum DisplayconfigRotation : uint {
      ForceUint32 = 0xFFFFFFFF,
      Identity    = 1,
      Rotate90    = 2,
      Rotate180   = 3,
      Rotate270   = 4
    }
    #endregion
    #region --- DCS:    displayconfig scaling -----------------------------------------------------
    public enum DisplayconfigScaling : uint {
      AspectRatioCenteredMax = 4,
      Centered               = 2,
      Custom                 = 5,
      ForceUint32            = 0xFFFFFFFF,
      Identity               = 1,
      Preferred              = 128,
      Stretched              = 3
    }
    #endregion
    #region --- DCSO:   displayconfig scanline ordering -------------------------------------------
    public enum DisplayconfigScanlineOrdering : uint {
      ForceUint32               = 0xFFFFFFFF,
      Interlaced                = 2,
      InterlacedLowerfieldFirst = 3,
      InterlacedUpperfieldFirst = Interlaced,
      Progressive               = 1,
      Unspecified               = 0
    }
    #endregion
    #region --- GA_:    get ancestor flags --------------------------------------------------------
    public enum GetAncestorFlags {
      Parent    = 1, // Retrieves the parent window. This does not include the owner, as it does with the GetParent function.
      Root      = 2, // Retrieves the root window by walking the chain of parent windows.
      RootOwner = 3
    }
    #endregion
    #region --- GW:     get window commands -------------------------------------------------------
    public enum GetWindowCommands {
      Child        = 5,
      EnabledPopup = 6,
      First        = 0,
      Last         = 1,
      Max          = 6,
      Next         = 2,
      Owner        = 4,
      Prev         = 3
    }
    #endregion
    #region --- GWL:    get window long value -----------------------------------------------------
    public enum GetWindowLongValue {
       ExStyle    = -20,
       HInstance  =  -6,
       HwndParent =  -8,
       Id         = -12,
       Style      = -16,
       Userdata   = -21,
       WndProc    =  -4
    }
    #endregion
    #region --- HWND:   window handles ------------------------------------------------------------
    public enum WindowHandles {
      Bottom    =  1,
      NoTopMost = -2,
      Top       =  0,
      Topmost   = -1
    }
    #endregion
    #region --- HSHELL: shell events --------------------------------------------------------------
    public enum ShellEvents {
      AccessibilityState  = 11,
      ActivateShellWindow =  3,
      AppCommand          = 12,
      EndTask             = 10,
      Flash               = Redraw | HighBit,
      GetMinRect          =  5,
      HighBit             = 0x8000,
      Language            =  8,
      Redraw              =  6,
      RudeAppActivated    = WindowActivated | HighBit,
      SysMenu             =  9,
      TaskMan             =  7,
      WindowActivated     =  4,
      WindowCreated       =  1,
      WindowDestroyed     =  2,
      WindowReplaced      = 13,
      WindowReplacing     = 14
    }
    #endregion
    #region --- QDC:    query device config flags -------------------------------------------------
    public enum QueryDeviceConfigFlags : uint {
      AllPaths        = 0x00000001,
      CurrentDatabase = 0x00000004,
      OnlyActivePaths = 0x00000002
    }
    #endregion
    #region --- SW:     show window commands ------------------------------------------------------
    public enum ShowWindowCommands {
      Default             = 10, // Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
      Hide                =  0, // Hides the window and activates another window.
      Maximized           =  3, // Activates the window and displays it as a maximized window.
      Minimize            =  6, // Minimizes the specified window and activates the next top-level window in the Z order.
      Minimized           =  2, // Activates the window and displays it as a minimized window.
      MinimizeForce       = 11, // Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
      MinimizedNoActivate =  7, // Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
      Normal              =  1, // Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
      NormalNoActivate    =  4, // Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated.
      Restore             =  9, // Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
      Show                =  5, // Activates the window and displays it in its current size and position.
      ShowNoActivate      =  8  // Displays the window in its current size and position. This value is similar to SW_SHOW, except that the window is not activated.
    }
    #endregion
    #region --- SWP:    set window pos flags ------------------------------------------------------
    public enum SetWindowPosFlags : uint {
       NoActivate = 0x0010,
       NoSize     = 0x0001,
       NoZOrder   = 0x0004,
       ShowWindow = 0x0040
    }
    #endregion
    #region --- ULW:    update layered window commands --------------------------------------------
    public enum UpdateLayeredWindowCommands {
      Alpha    = 0x00000002,
      ColorKey = 0x00000001,
      Opaque   = 0x00000004
    }
    #endregion
    #region --- WM:     window messages ----------------------------------------------------------- // http://pinvoke.net/default.aspx/Constants.WM
    public enum WindowMessages {
      ChildActivate = 0x0022,
      InitDialog    = 0x0110,
      KillFocus     = 0x0008, // is send shortly before mouse leaves a control
      NchitTest     = 0x0084, // Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate
      NextDlgCtl    = 0x0028,
      SetCursor     = 0x0020,
      SetFont       = 0x0030,
      SetRedraw     = 11,
      ShowWindow    = 0x0018
    }
    #endregion
    #region --- WM:     window messages mouse -----------------------------------------------------
    public enum WindowMessagesMouse {
      Activate                            = 0x0021, // mouse activates inactive window (click in inactive window)
      CaptureChanged                      = 0x0215, // mouse leaving window handle
      ExtraButtonDoubleClick              = 0x020D, // x mouse button double click
      ExtraButtonDoubleClickNoClientArea  = 0x00AD, // x mouse button double click
      ExtraButtonDown                     = 0x020B, // x mouse button down (click)
      ExtraButtonDownNoClientArea         = 0x00AB, // x mouse button down (click)
      ExtraButtonUp                       = 0x020C, // x mouse button up (click released)
      ExtraButtonUpNoClientArea           = 0x00AC, // x mouse button up (click released)
      Hover                               = 0x02A1, // mouse hovering window
      HoverNoClientArea                   = 0x02A0, // mouse hovering window
      Leave                               = 0x02A3, // mouse leaving window
      LeaveNoClientArea                   = 0x02A2, // mouse leaving window
      LeftButtonDoubleClick               = 0x0203, // left mouse button double click
      LeftButtonDoubleClickNoClientArea   = 0x00A3, // left mouse button double click out of window client area
      LeftButtonDown                      = 0x0201, // left mouse button down (click)
      LeftButtonDownNoClientArea          = 0x00A1, // left mouse button up (click)
      LeftButtonUp                        = 0x0202, // left mouse button up (click released)
      LeftButtonUpNoClientArea            = 0x00A2, // left mouse button down (click released)
      MiddleButtonDoubleClick             = 0x0209, // middle mouse double click
      MiddleButtonDoubleClickNoClientArea = 0x00A9, // middle mouse double click
      MiddleButtonDown                    = 0x0207, // middle mouse button down (click)
      MiddleButtonDownNoClientArea        = 0x00A7, // middle mouse button down (click)
      MiddleButtonUp                      = 0x0208, // middle mouse button up (click released)
      MiddleButtonUpNoClientArea          = 0x00A8, // middle mouse button up (click released)
      Move                                = 0x0200, // mouse move
      MoveNoClientArea                    = 0x00A0, // mouse move
      RightButtonDoubleClick              = 0x0206, // right mouse button double click
      RightButtonDoubleClickNoClientArea  = 0x00A6, // right mouse button double click
      RightButtonDown                     = 0x0204, // right mouse button down (click)
      RightButtonDownNoClientArea         = 0x00A4, // right mouse button down (click)
      RightButtonUp                       = 0x0205, // right mouse button up (click released)
      RightButtonUpNoClientArea           = 0x00A5, // right mouse button up (click released)
      Wheel                               = 0x020E  // mouse wheel
    }
    #endregion
    #region --- WM:     window messages mouse cursor shapes ---------------------------------------
    public enum WindowMessagesMouseCursorShapes {
      Bottom      = 15,
      BottomLeft  = 16,
      BottomRight = 17,
      Left        = 10,
      Move        = 02,
      Right       = 11,
      Top         = 12,
      TopLeft     = 13,
      TopRight    = 14
    }
    #endregion
    #region --- WS:     window styles -------------------------------------------------------------
    public enum WindowStyles : uint {
      Border           = 0x00800000, // The window has a thin-line border
      Caption          = 0x00C00000, // The window has a title bar (includes the WS_BORDER style).
      Child            = 0x40000000, // The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the WS_POPUP style.
      ChildWindow      = 0x40000000, // Same as the WS_CHILD style.
      ClipChildren     = 0x02000000, // Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.
      ClipSiblings     = 0x04000000, // Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated. If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
      Disabled         = 0x08000000, // The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use the EnableWindow function.
      DlgFrame         = 0x00400000, // The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.
      Group            = 0x00020000, // The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style. The first control in each group usually has the WS_TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys. You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
      HScroll          = 0x00100000, // The window has a horizontal scroll bar.
      Iconic           = 0x20000000, // The window is initially minimized. Same as the WS_MINIMIZE style.
      Maximize         = 0x01000000, // The window is initially maximized.
      MaximizeBox      = 0x00010000, // The window has a maximize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.
      Minimize         = 0x20000000, // The window is initially minimized. Same as the WS_ICONIC style.
      MinimizeBox      = 0x00020000, // The window has a minimize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.
      Overlapped       = 0x00000000, // The window is an overlapped window. An overlapped window has a title bar and a border. Same as the WS_TILED style.
      OverlappedWindow = (Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox), // The window is an overlapped window. Same as the WS_TILEDWINDOW style.
      Popup            = 0x80000000, // The window is a pop-up window. This style cannot be used with the WS_CHILD style.
      PopupWindow 	   = (Popup | Border | SysMenu), // The window is a pop-up window. The WS_CAPTION and WS_POPUPWINDOW styles must be combined to make the window menu visible.
      SizeBox          = 0x00040000, // The window has a sizing border. Same as the WS_THICKFRAME style.
      SysMenu          = 0x00080000, // The window has a window menu on its title bar. The WS_CAPTION style must also be specified.
      TabStop          = 0x00010000, // The window is a control that can receive the keyboard focus when the user presses the TAB key. Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style. You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function. For user-created windows and modeless dialogs to work with tab stops, alter the message loop to call the IsDialogMessage function.
      ThickFrame       = 0x00040000, // The window has a sizing border. Same as the WS_SIZEBOX style.
      Tiled            = 0x00000000, // The window is an overlapped window. An overlapped window has a title bar and a border. Same as the WS_OVERLAPPED style.
      TiledWindow      = (Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox), // The window is an overlapped window. Same as the WS_OVERLAPPEDWINDOW style.
      Visible          = 0x10000000 // The window is initially visible. This style can be turned on and off by using the ShowWindow or SetWindowPos function.
    }
    #endregion
    #region --- WS_EX:  window styles extended ----------------------------------------------------
    public enum WindowStylesExtended {
      AcceptFiles         = 0x00000010, // The window accepts drag-drop files.
      AppWindow           = 0x00040000, // Forces a top-level window onto the taskbar when the window is visible.
      ClientEdge          = 0x00000200, // The window has a border with a sunken edge.
      Composited          = 0x02000000, // Paints all descendants of a window in bottom-to-top painting order using double-buffering. Bottom-to-top painting order allows a descendent window to have translucency (alpha) and transparency (color-key) effects, but only if the descendent window also has the WS_EX_TRANSPARENT bit set. Double-buffering allows the window and its descendents to be painted without flicker. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. Windows 2000: This style is not supported.
      ContextHelp         = 0x00000400, // The title bar of the window includes a question mark. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window. WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
      ControlParent       = 0x00010000, // The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
      DlgModalFrame       = 0x00000001, // The window has a double border; the window can, optionally, be created with a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
      Layered             = 0x00080000, // The window is a layered window. This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. Windows 8: The WS_EX_LAYERED style is supported for top-level windows and child windows. Previous Windows versions support WS_EX_LAYERED only for top-level windows.
      LayoutRightToLeft   = 0x00400000, // If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the horizontal origin of the window is on the right edge. Increasing horizontal values advance to the left.
      Left                = 0x00000000, // The window has generic left-aligned properties. This is the default.
      LeftScrollbar       = 0x00004000, // If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.
      LeftToRightReading  = 0x00000000, // The window text is displayed using left-to-right reading-order properties. This is the default.
      MdiChild            = 0x00000040, // The window is a MDI child window.
      NoActivate          = 0x08000000, // A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window. The window should not be activated through programmatic access or via keyboard navigation by accessible technology, such as Narrator. To activate the window, use the SetActiveWindow or SetForegroundWindow function. The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the WS_EX_APPWINDOW style.
      NoInheritLayout     = 0x00100000, // The window does not pass its window layout to its child windows.
      NoParentNotify      = 0x00000004, // The child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
      NoRedirectionBitmap = 0x00200000, // The window does not render to a redirection surface. This is for windows that do not have visible content or that use mechanisms other than surfaces to provide their visual.
      OverlappedWindow    = (WindowEdge | ClientEdge), // The window is an overlapped window.
      PaletteWindow       = (WindowEdge | ToolWindow | TopMost), // The window is palette window, which is a modeless dialog box that presents an array of commands.
      Right               = 0x00001000, // The window has generic "right-aligned" properties. This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored. Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.
      RightScrollbar      = 0x00000000, // The vertical scroll bar (if present) is to the right of the client area. This is the default.
      RightToLeftReading  = 0x00002000, // If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.
      StaticEdge          = 0x00020000, // The window has a three-dimensional border style intended to be used for items that do not accept user input.
      ToolWindow          = 0x00000080, // The window is intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE.
      TopMost             = 0x00000008, // The window should be placed above all non-topmost windows and should stay above them, even when the window is deactivated. To add or remove this style, use the SetWindowPos function.
      Transparent         = 0x00000020, // The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted. To achieve transparency without these restrictions, use the SetWindowRgn function.
      WindowEdge          = 0x00000100  // The window has a border with a raised edge.
    }
    #endregion
    #endregion

    #region --- CONSTANTS -------------------------------------------------------------------------
    public const int EM_SETPARAFORMAT = 1095;
    public const int PFM_LINESPACING = 0x00000100;
    public const int PFM_SPACEAFTER  = 0x00000080;
    public const int PFM_SPACEBEFORE = 0x00000040;
    public const int SCF_SELECTION = 1;
    #endregion

    #region === STRUCTURES ========================================================================
    #region --- combobox info ---------------------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct COMBOBOXINFO {
      public Int32  cbSize;
      public RECT   rcItem, rcButton;
      public int    buttonState;
      public IntPtr hwndCombo, hwndEdit, hwndList;
    }
    #endregion
    #region --- cursor: icon header ---------------------------------------------------------------
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct IconHeader {
      [FieldOffset(0)] public short reserved;
      [FieldOffset(2)] public short type;
      [FieldOffset(4)] public short count;
    }
    #endregion
    #region --- cursor: icon info -----------------------------------------------------------------
    /// <summary>Union structure for icons and cursors.</summary>
    /// <remarks>For icons, field offset 4 is used for planes and field offset 6 for
    /// bits-per-pixel, while for cursors field offset 4 is used for the x coordinate
    /// of the hotspot, and field offset 6 is used for the y coordinate.</remarks>
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct IconInfo {
      [FieldOffset(0)]  public byte width;
      [FieldOffset(1)]  public byte height;
      [FieldOffset(2)]  public byte colors;
      [FieldOffset(3)]  public byte reserved;
      [FieldOffset(4)]  public short planes;
      [FieldOffset(6)]  public short bpp;
      [FieldOffset(4)]  public short hotspot_x;
      [FieldOffset(6)]  public short hotspot_y;
      [FieldOffset(8)]  public int size;
      [FieldOffset(12)] public int offset;
    }
    #endregion
    #region --- displayconfig 2d region -----------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct Displayconfig2dRegion {
      public uint cx;
      public uint cy;
    }
    #endregion
    #region --- displayconfig device info header --------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigDeviceInfoHeader {
      public DisplayconfigDeviceInfoType type;
      public uint size;
      public LUID adapterId;
      public uint id;
    }
    #endregion
    #region --- displayconfig mode info -----------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigModeInfo {
      public DisplayconfigModeInfoType infoType;
      public uint id;
      public LUID adapterId;
      public DisplayconfigModeInfoUnion modeInfo;
    }
    #endregion
    #region --- displayconfig mode info union -----------------------------------------------------
    [StructLayout(LayoutKind.Explicit)]
    public struct DisplayconfigModeInfoUnion {
      [FieldOffset(0)]
      public DisplayconfigTargetMode targetMode;

      [FieldOffset(0)]
      public DisplayconfigSourceMode sourceMode;
    }
    #endregion
    #region --- displayconfig path info -----------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigPathInfo {
      public DisplayconfigPathSourceInfo sourceInfo;
      public DisplayconfigPathTargetInfo targetInfo;
      public uint flags;
    }
    #endregion
    #region --- displayconfig path source info ----------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigPathSourceInfo {
      public LUID adapterId;
      public uint id;
      public uint modeInfoIdx;
      public uint statusFlags;
    }
    #endregion
    #region --- displayconfig path target info ----------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigPathTargetInfo {
      public LUID adapterId;
      public uint id;
      public uint modeInfoIdx;
      private readonly DisplayconfigOutputTechnology outputTechnology;
      private readonly DisplayconfigRotation rotation;
      private readonly DisplayconfigScaling scaling;
      private DisplayconfigRational refreshRate;
      private readonly DisplayconfigScanlineOrdering scanLineOrdering;
      public bool targetAvailable;
      public uint statusFlags;
    }
    #endregion
    #region --- displayconfig rational ------------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigRational {
      public uint Numerator;
      public uint Denominator;
    }
    #endregion
    #region --- displayconfig source mode ---------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigSourceMode {
      public uint width;
      public uint height;
      public DisplayconfigPixelformat pixelFormat;
      public PointL position;
    }
    #endregion
    #region --- displayconfig target device name --------------------------------------------------
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DisplayconfigTargetDeviceName {
      public DisplayconfigDeviceInfoHeader header;
      public DisplayconfigTargetDeviceNameFlags flags;
      public DisplayconfigOutputTechnology outputTechnology;
      public ushort edidManufactureId;
      public ushort edidProductCodeId;
      public uint connectorInstance;

      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
      public string monitorFriendlyDeviceName;

      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
      public string monitorDevicePath;
    }
    #endregion
    #region --- displayconfig target device name flags --------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigTargetDeviceNameFlags {
      public uint value;
    }
    #endregion
    #region --- displayconfig target mode ---------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigTargetMode {
      public DisplayconfigVideoSignalInfo targetVideoSignalInfo;
    }
    #endregion
    #region --- displayconfig video signal info ---------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayconfigVideoSignalInfo {
      public ulong pixelRate;
      public DisplayconfigRational hSyncFreq;
      public DisplayconfigRational vSyncFreq;
      public Displayconfig2dRegion activeSize;
      public Displayconfig2dRegion totalSize;
      public uint videoStandard;
      public DisplayconfigScanlineOrdering scanLineOrdering;
    }
    #endregion
    #region --- luid ------------------------------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct LUID {
      public uint LowPart;
      public int HighPart;
    }
    #endregion
    #region --- paraformat ------------------------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct PARAFORMAT {
      public int   cbSize;
      public uint  dwMask;
      public short wNumbering;
      public short wReserved;
      public int   dxStartIndent;
      public int   dxRightIndent;
      public int   dxOffset;
      public short wAlignment;
      public short cTabCount;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
      public int[] rgxTabs;
      // PARAFORMAT2 from here onwards
      public int   dySpaceBefore;
      public int   dySpaceAfter;
      public int   dyLineSpacing;
      public short sStyle;
      public byte  bLineSpacingRule;
      public byte  bOutlineLevel;
      public short wShadingWeight;
      public short wShadingStyle;
      public short wNumberingStart;
      public short wNumberingStyle;
      public short wNumberingTab;
      public short wBorderSpace;
      public short wBorderWidth;
      public short wBorders;
    }
    #endregion
    #region --- pointl ----------------------------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct PointL {
      private readonly int x;
      private readonly int y;
    }
    #endregion
    #region --- rect ------------------------------------------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT {
      public int Left;   // x position of upper-left corner
      public int Top;    // y position of upper-left corner
      public int Right;  // x position of lower-right corner
      public int Bottom; // y position of lower-right corner
    }
    #endregion
    #region --- scroll info -----------------------------------------------------------------------
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct SCROLLINFO {
      public uint cbSize;
      public uint fMask;
      public int  nMin;
      public int  nMax;
      public uint nPage;
      public int  nPos;
      public int  nTrackPos;
    }
    #endregion
    #region --- window placement ------------------------------------------------------------------
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowPlacement {
      public int                length;
      public int                flags;
      public ShowWindowCommands showCmd;
      public Point              ptMinPosition;
      public Point              ptMaxPosition;
      public Rectangle          rcNormalPosition;
    }
    #endregion
    #endregion

    #region === DELEGATES =========================================================================
    public delegate bool   EnumDesktopWindowsDelegate(IntPtr hWnd, int lParam);
    public delegate bool   EnumWindowsCallback(IntPtr hWnd, IntPtr lParam);
    public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    #endregion

    #region === METHODS: extern ===================================================================
    #region --- dll import: allow set foreground window -------------------------------------------
    [DllImport("user32.dll")]
    public static extern bool AllowSetForegroundWindow(uint dwProcessId);
    #endregion
    #region --- dll import: call next hook ex -----------------------------------------------------
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    #endregion
    #region --- dll import: create icon from resource ---------------------------------------------
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr CreateIconFromResource(IntPtr pbIconBits, int dwResSize, bool fIcon, int dwVer);
    #endregion
    #region --- dll import: destroy icon ----------------------------------------------------------
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DestroyIcon(IntPtr hIcon);
    #endregion
    #region --- dll import: display config get device info ----------------------------------------
    [DllImport("user32.dll")]
    public static extern int DisplayConfigGetDeviceInfo(ref DisplayconfigTargetDeviceName deviceName);
    #endregion
    #region --- dll import: enum child windows ----------------------------------------------------
    [DllImport("user32.Dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumChildWindows(IntPtr parentHandle, EnumWindowsCallback callback, IntPtr lParam);
    #endregion
    #region --- dll import: enum desktop windows --------------------------------------------------
    [DllImport("user32.dll")]
    public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDesktopWindowsDelegate lpfn, IntPtr lParam);
    #endregion
    #region --- dll import: enum windows ----------------------------------------------------------
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern bool EnumWindows(EnumWindowsCallback numFunc, IntPtr lParam);
    #endregion
    #region --- dll import: find window -----------------------------------------------------------
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr FindWindow(string className, string windowName);
    #endregion
    #region --- dll import: find window ex --------------------------------------------------------
    [DllImport("user32.dll", CharSet=CharSet.Unicode)]
    public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle); 
    #endregion
    #region --- dll import: get ancestor ----------------------------------------------------------
    [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
    public static extern IntPtr GetAncestor(IntPtr hWnd, uint gaFlags);
    #endregion
    #region --- dll import: get dc ----------------------------------------------------------------
    [DllImport("user32.dll", ExactSpelling=true, SetLastError=true)]
	  public static extern IntPtr GetDC(IntPtr hWnd);
    #endregion
    #region --- dll import: get desktop window ----------------------------------------------------
    [DllImport("user32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
    public static extern IntPtr GetDesktopWindow();
    #endregion
    #region --- dll import: get display config buffer sizes ---------------------------------------
    [DllImport("user32.dll")]
    public static extern int GetDisplayConfigBufferSizes(QueryDeviceConfigFlags flags, out uint numPathArrayElements, out uint numModeInfoArrayElements);
    #endregion
    #region --- dll import: get foreground window -------------------------------------------------
    [DllImport("user32.dll")]
    public static extern int GetForegroundWindow();
    #endregion
    #region --- dll import: get scroll info -------------------------------------------------------
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);
    #endregion
    #region --- dll import: get shell window ------------------------------------------------------
    [DllImport("user32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
    public static extern IntPtr GetShellWindow();
    #endregion
    #region --- dll import: get top window --------------------------------------------------------
    [DllImport("user32.dll")]
    public static extern IntPtr GetTopWindow(IntPtr hWnd);
    #endregion
    #region --- dll import: get window ------------------------------------------------------------
    [DllImport("user32.dll")]
    public static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);
    #endregion
    #region --- dll import: get window long -------------------------------------------------------
    [DllImport("user32.dll", CharSet=CharSet.Auto)]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    #endregion
    #region --- dll import: get window long ptr ---------------------------------------------------
    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetWindowLongPtr(IntPtr hWnd, int nIndex);
    #endregion
    #region --- dll import: get window placement --------------------------------------------------
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);
    #endregion
    #region --- dll import: get window rect -------------------------------------------------------
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowRect(IntPtr hWnd, [Out] out RECT lpRect);
    #endregion
    #region --- dll import: get window text -------------------------------------------------------
    [DllImport("user32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    #endregion
    #region --- dll import: get window text length ------------------------------------------------
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetWindowTextLength(IntPtr hWnd);
    #endregion
    #region --- dll import: get window thread process id ------------------------------------------
    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    #endregion
    #region --- dll import: intersect rect --------------------------------------------------------
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IntersectRect([Out] out RECT lprcDst, [In] ref RECT lprcSrc1, [In] ref RECT lprcSrc2);
    #endregion
    #region --- dll import: is window visible -----------------------------------------------------
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsWindowVisible(IntPtr hWnd);
    #endregion
    #region --- dll import: load cursor from file -------------------------------------------------
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr LoadCursorFromFile(string filename);
    #endregion
    #region --- dll import: move window -----------------------------------------------------------
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    #endregion
    #region --- dll import: query display config --------------------------------------------------
    [DllImport("user32.dll")]
    public static extern int QueryDisplayConfig(QueryDeviceConfigFlags flags, ref uint numPathArrayElements, [Out] DisplayconfigPathInfo[] PathInfoArray, ref uint numModeInfoArrayElements, [Out] DisplayconfigModeInfo[] ModeInfoArray, IntPtr currentTopologyId);
    #endregion
    #region --- dll import: register shell hook ---------------------------------------------------
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern bool RegisterShellHook(IntPtr hWnd, int flags);
    #endregion
    #region --- dll import: register shell hook window --------------------------------------------
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern bool RegisterShellHookWindow(IntPtr hWnd);
    #endregion
    #region --- dll import: register window message -----------------------------------------------
    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern uint RegisterWindowMessage(string Message);
    #endregion
    #region --- dll import: release dc ------------------------------------------------------------
    [DllImport("user32.dll", ExactSpelling=true)]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    #endregion
    #region --- dll import: send message ----------------------------------------------------------
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
    #endregion
    #region --- dll import: send message ----------------------------------------------------------
    [DllImport("user32", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT lParam);
    #endregion
    #region --- dll import: set foreground window -------------------------------------------------
    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
    #endregion
    #region --- dll import: set taskman window ----------------------------------------------------
    [DllImport("user32.dll")]
    public static extern void SetTaskmanWindow(IntPtr hwnd);
    #endregion
    #region --- dll import: set window long -------------------------------------------------------
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int nStyle);
    #endregion
    #region --- dll import: set window pos --------------------------------------------------------
    [DllImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
    #endregion
    #region --- dll import: set window pos --------------------------------------------------------
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    public static extern bool SetWindowPos(
      int  hWnd,            // Window handle
      int  hWndInsertAfter, // Placement-order handle
      int  X,               // Horizontal position
      int  Y,               // Vertical position
      int  cx,              // Width
      int  cy,              // Height
      uint uFlags           // Window positioning flags
    );
    #endregion
    #region --- dll import: set window text -------------------------------------------------------
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern bool SetWindowText(IntPtr hWnd, string text);
    #endregion
    #region --- dll import: set windows hook ex ---------------------------------------------------
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
    #endregion
    #region --- dll import: show window -----------------------------------------------------------
    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    #endregion
    #region --- dll import: unhook windows hook ex ------------------------------------------------
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool UnhookWindowsHookEx(IntPtr hhk);
    #endregion
    #region --- dll import: union rect ------------------------------------------------------------
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool UnionRect([Out] out RECT lprcDst, [In] ref RECT lprcSrc1, [In] ref RECT lprcSrc2);
    #endregion
    #region --- dll import: window from point -----------------------------------------------------
    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromPoint(Point loc);
    #endregion
    #endregion

    #region === METHODS ===========================================================================
    #region --- enum window -----------------------------------------------------------------------
    private static bool EnumWindow(IntPtr handle, IntPtr pointer) {
      GCHandle gch = GCHandle.FromIntPtr(pointer);
      if (gch.Target is not List<IntPtr> list) {
        throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
      }
      list.Add(handle);
      //  You can modify this to check to see if you want to cancel the operation, then return a null here
      return true;
    }
    #endregion
    #region --- get all monitors friendly names ---------------------------------------------------
    public static IEnumerable<string> GetAllMonitorsFriendlyNames() {
      int error = GetDisplayConfigBufferSizes(
        QueryDeviceConfigFlags.OnlyActivePaths,
        out uint pathCount,
        out uint modeCount
      );

      if (error != 0) {
        throw new Win32Exception(error);
      }

      DisplayconfigPathInfo[] displayPaths = new DisplayconfigPathInfo[pathCount];
      DisplayconfigModeInfo[] displayModes = new DisplayconfigModeInfo[modeCount];

      error = QueryDisplayConfig(
        QueryDeviceConfigFlags.OnlyActivePaths,
        ref pathCount,
        displayPaths,
        ref modeCount,
        displayModes,
        IntPtr.Zero
      );

      if (error != 0) {
        throw new Win32Exception(error);
      }

      for (int i = 0; i < modeCount; i++) {
        if (displayModes[i].infoType == DisplayconfigModeInfoType.Target) {
          yield return GetMonitorFriendlyName(displayModes[i].adapterId, displayModes[i].id);
        }
      }
    }
    #endregion
    #region --- get child windows -----------------------------------------------------------------
    public static List<IntPtr> GetChildWindows(IntPtr parent) {
      List<IntPtr> result = [];
      GCHandle listHandle = GCHandle.Alloc(result);
      try {
        EnumWindowsCallback childProc = new(EnumWindow);
        EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
      } finally {
        if (listHandle.IsAllocated)
          listHandle.Free();
      }
      return result;
    }
    #endregion
    #region --- get monitor friendly name ---------------------------------------------------------
    private static string GetMonitorFriendlyName(LUID adapterId, uint targetId) {
      DisplayconfigTargetDeviceName deviceName = new() {
        header = {
          size      = (uint)Marshal.SizeOf(typeof(DisplayconfigTargetDeviceName)),
          adapterId = adapterId,
          id        = targetId,
          type      = DisplayconfigDeviceInfoType.GetTargetName
        }
      };

      int error = DisplayConfigGetDeviceInfo(ref deviceName);
      if (error != 0) {
        throw new Win32Exception(error);
      }

      return deviceName.monitorFriendlyDeviceName;
    }
    #endregion
    #region --- get placement ---------------------------------------------------------------------
    public static WindowPlacement GetPlacement(IntPtr hwnd) {
      WindowPlacement placement = new();
      placement.length = Marshal.SizeOf(placement);
      GetWindowPlacement(hwnd, ref placement);
      return placement;
    }
    #endregion
    #region --- get root windows of process -------------------------------------------------------
    public static List<IntPtr> GetRootWindowsOfProcess(int pid) {
      List<IntPtr> rootWindows = GetChildWindows(IntPtr.Zero);
      List<IntPtr> dsProcRootWindows = [];
      foreach (IntPtr hWnd in rootWindows) {
        _ = GetWindowThreadProcessId(hWnd, out uint lpdwProcessId);
        if (lpdwProcessId == pid)
          dsProcRootWindows.Add(hWnd);
      }
      return dsProcRootWindows;
    }
    #endregion
    #region --- get window title ------------------------------------------------------------------
    public static string GetWindowTitle(IntPtr handle) {
      string result = "";

      int length = GetWindowTextLength(handle);
      if (length > 0) {
        StringBuilder outText = new(length + 1);
        _ = GetWindowText(handle, outText, outText.Capacity);
        result = outText.ToString();
      }

      return result;      
    }
    #endregion
    #endregion
  }
  #pragma warning restore CA1069 // Enumerationswerte dürfen nicht dupliziert werden
  #pragma warning restore CA1401 // P/Invokes dürfen nicht sichtbar sein
  #pragma warning restore SYSLIB1054 // Verwenden Sie \"LibraryImportAttribute\" anstelle von \"DllImportAttribute\", um P/Invoke-Marshallingcode zur Kompilierzeit zu generieren.
}