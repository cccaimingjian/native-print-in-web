namespace native_print_in_web
{
    public partial class ControlForm : Form
    {
        private bool _isStart = false;

        public ControlForm()
        {
            InitializeComponent();
            label.Text = "not started. δ����";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (_isStart)
            {
                label.Text = "already started. �Ѿ�����";
                return;
            }
            WebSocketLib webSocketLib = new WebSocketLib();
            webSocketLib.StartSocketListen();
            _isStart = true;
            label.Text = "running. ��������";
        }
    }
}