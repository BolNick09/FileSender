using FileInfoLib;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FileSenderClient
{
    public partial class FrmFileSenderClient : Form
    {
        private TcpClient server = new();
        private CancellationTokenSource cancel = new();
        private CustomFileInfo sendfileInfo = new();
        private CustomFileInfo receivefileInfo = new();
        private bool isConnected = false;
        private string hint;

        public FrmFileSenderClient()
        {
            InitializeComponent();
        }

        private void FrmFileSenderClient_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            hint = @"������� �������� ��� �������� � ����� �����:
                     0. ��������� ������
                     1. ������ Ip ������� � ������ ������ ������������ � �������
                     2. ������� ���� ��� ���������� ����� ����� ���������� ���� ������� ���� ����������
                     3. ������ �������� ����
                     4. ������� ���� ��� �������� ����� ����� ���������� ���� ������� ���� ��� ��������
                     5. ������ ��������� ��� �������� ����� �� ������. ���� �������� � ���������� ��� ����������, ���������� � �.2";
            MessageBox.Show(hint);
        }
        private async Task ListenToServer()
        {
            while (true)
            {
                if (cancel.IsCancellationRequested)
                    return;

                CustomFileInfo fileInfo = await CustomFileInfo.CustomReceiveFile(server, tbDir.Text);

                lblMessage.Text = $"���� {fileInfo.Name} ��������";

                tbFileName.Text = fileInfo.Name;
                tbFileSize.Text = fileInfo.Size + " ����";

                if (cancel.IsCancellationRequested)
                    return;


            }
        }

        private async void btnReceive_Click(object sender, EventArgs e)
        {
            if (tbDir.Text == "")
            {
                lblMessage.Text = "�� ������� ���������� ���������� �����";
                return;
            }
            if (!isConnected)
            {
                lblMessage.Text = "���������� �� �����������";
                return;
            }
            await ListenToServer();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(tbIpAddress.Text, out var ipAddress))
            {
                lblMessage.Text = "�� ������� ������������ �� ���������� ������";
            }
            await server.ConnectAsync(ipAddress, 2024);
            lblMessage.Text = "����������� ����������� �� ������" + ipAddress.ToString();
            isConnected = true;
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tbDir.Text = folderBrowserDialog.SelectedPath;
                    lblMessage.Text = "������� ����� ��� ���������� �����";
                }
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    tbFileName.Text = fileInfo.Name;
                    tbFileSize.Text = fileInfo.Length.ToString() + " ����";
                    //tbDir.Text = fileInfo.DirectoryName;

                    sendfileInfo.Name = fileInfo.Name;
                    sendfileInfo.Path = fileInfo.FullName;
                    sendfileInfo.Size = (int)fileInfo.Length;

                    lblMessage.Text = "������ ���� ��� ��������";
                }


            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                lblMessage.Text = "���������� �� �����������";
                return;
            }
            await CustomFileInfo.CustomSendFile(server, sendfileInfo);

        }

        private void btnShowHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(hint);
        }
    }
}
