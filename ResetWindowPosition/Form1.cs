namespace ResetWindowPosition
{
    public partial class Form1 : Form
    {
        WindowHelper windowHelper = new WindowHelper();

        public Form1()
        {
            InitializeComponent();
        }


        private void btnRefreshWindow_Click(object sender, EventArgs e)
        {
            if (windowHelper.windows.Count > 0) windowHelper.windows.Clear();
            windowHelper.GetWindows();
            var header = new KeyValuePair<IntPtr, string>(IntPtr.Zero, "--- Select ---");
            var data = windowHelper.windows.OrderBy(v => v.Value).ToList();
            data.Insert(0, header);

            //rewire combobox datasource
            comboWindows.SelectedValueChanged -= new EventHandler(comboWindows_SelectedValueChanged);
            this.comboWindows.DataSource = data;
            this.comboWindows.DisplayMember = "Value";
            this.comboWindows.ValueMember = "Key";
            comboWindows.SelectedValueChanged += new EventHandler(comboWindows_SelectedValueChanged);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selection = this.comboWindows.SelectedValue;
            var selectedWindow = (IntPtr)selection;

            windowHelper.MoveWindow(selectedWindow, this.Location.X, this.Location.Y);

            var info = windowHelper.GetWindowInfo(selectedWindow);
            log($"New Location: {info.GetXY()}");
            log($"--------------");
        }

        private void comboWindows_SelectedValueChanged(object sender, EventArgs e)
        {
            var selection = this.comboWindows.SelectedValue;
            IntPtr selectedWindow;

            if (selection is KeyValuePair<IntPtr, string>)
            {
                selectedWindow = ((KeyValuePair<IntPtr, string>)selection).Key;
            }
            else
            {
                selectedWindow = (IntPtr)selection;
            }

            if (selectedWindow != IntPtr.Zero)
            {
                var info = windowHelper.GetWindowInfo(selectedWindow);

                log(info.ToString());
                log($"--------------");
            }
        }


        private void Form1_Move(object sender, EventArgs e)
        {
            label1.Text = $"My Position:  X={Location.X} , Y={Location.Y}";
        }

        private void log(string message)
        {
            txtLog.Text += message + Environment.NewLine;
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        
    }
}