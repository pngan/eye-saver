namespace eye_saver;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

static class Program
{

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        List<Form> forms = [];

        foreach (var screen in Screen.AllScreens)
        {
            Form f = new Form();
            f.BackColor = Color.Black;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Bounds = screen.Bounds;
            f.TopMost = true;
            f.Opacity = 0.9;
            f.StartPosition = FormStartPosition.Manual;

            Label message = new()
            {
                Text = "Look around.",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Arial", 24)
            };
            message.MouseClick += new MouseEventHandler((_, _) => forms.ForEach(f => f.Hide()));
            f.Controls.Add(message);

            forms.Add(f);
        }

        Application.EnableVisualStyles();
        var formContext = new MultiFormContext(forms);
        formContext.Run();
        Application.Run(formContext);
    }

    public class MultiFormContext : ApplicationContext
    {
        //Component declarations
        private NotifyIcon TrayIcon;
        private ContextMenuStrip TrayIconContextMenu;
        private ToolStripMenuItem CloseMenuItem;

        List<Form> _forms;
        public MultiFormContext(List<Form> forms)
        {
            _forms = forms;
            Application.ApplicationExit += new EventHandler((_,_)=>{TrayIcon.Visible = false;});
            InitializeComponent();
            TrayIcon.Visible = true;
        }

        public void Run()
        {
            _forms.First().VisibleChanged += async (s, args) =>
            {
                if (((Control)s).Visible == false)
                {
                    await Task.Delay(1200000).ConfigureAwait(ConfigureAwaitOptions.ContinueOnCapturedContext);
                    _forms.ForEach(f => f.Show());
                }
                else
                {
                    await Task.Delay(20000).ConfigureAwait(ConfigureAwaitOptions.ContinueOnCapturedContext);
                    _forms.ForEach(f => f.Hide());
                }
            };

            _forms.ForEach(f => f.Show());
        }


        private void InitializeComponent()
        {
            TrayIcon = new NotifyIcon();

            TrayIcon.Text = "Eye Saver";

            TrayIcon.Icon =  new Icon("eye-saver.ico");

            //Optional - Add a context menu to the TrayIcon:
            TrayIconContextMenu = new ContextMenuStrip();
            CloseMenuItem = new ToolStripMenuItem();
            TrayIconContextMenu.SuspendLayout();

            // 
            // TrayIconContextMenu
            // 
            this.TrayIconContextMenu.Items.AddRange(new ToolStripItem[] {this.CloseMenuItem});
            this.TrayIconContextMenu.Name = "TrayIconContextMenu";
            this.TrayIconContextMenu.Size = new Size(153, 70);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new Size(152, 22);
            this.CloseMenuItem.Text = "Exit Eye Saver";
            this.CloseMenuItem.Click += new EventHandler((_,_)=>Application.Exit());

            TrayIconContextMenu.ResumeLayout(false);
            TrayIcon.ContextMenuStrip = TrayIconContextMenu;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup so that the icon will be removed when the application is closed
            TrayIcon.Visible = false;
        }
    }
}