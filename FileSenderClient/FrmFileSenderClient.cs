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
            hint = @"Порядок действий для отправки и приёма файла:
                     0. Запустить сервер
                     1. Ввести Ip сервера и нажать кнопку Подключиться к серверу
                     2. Выбрать путь для сохранения файла через диалоговое окно Выбрать путь сохранения
                     3. Нажать Включить приём
                     4. Выбрать файл для отправки файла через диалоговое окно Выбрать файл для отправки
                     5. Нажать отправить для отправки файла на сервер. Файл вернется в директорию для сохранения, выбранного в П.2";
            MessageBox.Show(hint);
        }
        private async Task ListenToServer()
        {
            while (true)
            {
                if (cancel.IsCancellationRequested)
                    return;

                CustomFileInfo fileInfo = await CustomFileInfo.CustomReceiveFile(server, tbDir.Text);

                lblMessage.Text = $"Файл {fileInfo.Name} загружен";

                tbFileName.Text = fileInfo.Name;
                tbFileSize.Text = fileInfo.Size + " байт";

                if (cancel.IsCancellationRequested)
                    return;


            }
        }

        private async void btnReceive_Click(object sender, EventArgs e)
        {
            if (tbDir.Text == "")
            {
                lblMessage.Text = "Не выбрана директория сохранения файла";
                return;
            }
            if (!isConnected)
            {
                lblMessage.Text = "Соедниение не установлено";
                return;
            }
            await ListenToServer();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(tbIpAddress.Text, out var ipAddress))
            {
                lblMessage.Text = "Не удалось подключиться по указанному адресу";
            }
            await server.ConnectAsync(ipAddress, 2024);
            lblMessage.Text = "Подключение установлено по адресу" + ipAddress.ToString();
            isConnected = true;
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tbDir.Text = folderBrowserDialog.SelectedPath;
                    lblMessage.Text = "Выбрана папка для сохранения файла";
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
                    tbFileSize.Text = fileInfo.Length.ToString() + " байт";
                    //tbDir.Text = fileInfo.DirectoryName;

                    sendfileInfo.Name = fileInfo.Name;
                    sendfileInfo.Path = fileInfo.FullName;
                    sendfileInfo.Size = (int)fileInfo.Length;

                    lblMessage.Text = "Выбран файл для отправки";
                }


            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                lblMessage.Text = "Соедниение не установлено";
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
