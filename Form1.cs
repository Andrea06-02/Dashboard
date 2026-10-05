using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public partial class Form1 : Form
{
    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
        int nWidthEllipse, int nHeightEllipse);

    [DllImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool DeleteObject(IntPtr hObject);

    public Form1()
    {
        InitializeComponent();

        IntPtr hrgn = CreateRoundRectRgn(0, 0, Width, Height, 25, 25);
        Region = Region.FromHrgn(hrgn);
        DeleteObject(hrgn); // liberar el HRGN nativo

        Panel_navegation.Height = Btn_dashboard.Height;
        Panel_navegation.Top = Btn_dashboard.Top;
        Panel_navegation.Left = Btn_dashboard.Left;
        Btn_dashboard.BackColor = Color.FromArgb(46, 51, 73);
    }
}