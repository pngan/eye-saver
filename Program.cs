namespace eye_saver;
using System;
using System.Drawing;
using System.Windows.Forms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var forms = CreateForms();
        Application.EnableVisualStyles();
        var formContext = new MultiFormContext(forms);
        formContext.Run();
        Application.Run(formContext);
    }

    static List<Form> CreateForms()
    {
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
            f.Show();

            var message = CreateLabel();
            message.MouseClick += new MouseEventHandler((_, _) => forms.ForEach(f => f.Hide()));
            f.Controls.Add(message);

            forms.Add(f);
        }
        return forms;
    }

    static Control CreateLabel()
    {
        return new Label()
        {
            Text = "Look around.",
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            ForeColor = Color.White,
            Font = new Font("Arial", 24)
        };
    }
}