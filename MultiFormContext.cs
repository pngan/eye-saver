namespace eye_saver;
using System;
using System.Drawing;
using System.Windows.Forms;

public class MultiFormContext : ApplicationContext
{
    //Component declarations
    private NotifyIcon TrayIcon;
    private ContextMenuStrip TrayIconContextMenu;
    private ToolStripMenuItem CloseMenuItem;
    private MessageController _messageController = new();

    List<Form> _forms;
    public MultiFormContext(List<Form> forms)
    {
        _forms = forms;
        Application.ApplicationExit += new EventHandler((_, _) => { TrayIcon.Visible = false; });
        InitializeComponent();
        TrayIcon.Visible = true;
        TrayIcon.ShowBalloonTip(2000, "Eye Saver", "Eye Saver will prompt you to take an eye break in 20 minutes.", ToolTipIcon.Info);
    }

    public void Run()
    {
        _forms.First().VisibleChanged += async (s, args) =>
        {
            if (((Control)s).Visible == false)
            {
                await MessageController.WaitForMessageOn();
                _forms.ForEach(f => f.Show());
            }
            else
            {
                await MessageController.WaitForMessageOff();
                _forms.ForEach(f => f.Hide());
            }
        };

        _forms.ForEach(f => f.Hide());
    }


    private void InitializeComponent()
    {
        TrayIcon = new NotifyIcon();

        TrayIcon.Text = "Eye Saver";

        TrayIcon.Icon = new Icon("eye-saver.ico");


        //Optional - Add a context menu to the TrayIcon:
        TrayIconContextMenu = new ContextMenuStrip();
        CloseMenuItem = new ToolStripMenuItem();
        TrayIconContextMenu.SuspendLayout();

        // 
        // TrayIconContextMenu
        // 
        this.TrayIconContextMenu.Items.AddRange(new ToolStripItem[] { this.CloseMenuItem });
        this.TrayIconContextMenu.Name = "TrayIconContextMenu";
        this.TrayIconContextMenu.Size = new Size(153, 70);
        // 
        // CloseMenuItem
        // 
        this.CloseMenuItem.Name = "CloseMenuItem";
        this.CloseMenuItem.Size = new Size(152, 22);
        this.CloseMenuItem.Text = "Exit Eye Saver";
        this.CloseMenuItem.Click += new EventHandler((_, _) => Application.Exit());

        TrayIconContextMenu.ResumeLayout(false);
        TrayIcon.ContextMenuStrip = TrayIconContextMenu;

    }

    private void OnApplicationExit(object sender, EventArgs e)
    {
        //Cleanup so that the icon will be removed when the application is closed
        TrayIcon.Visible = false;
    }
}
