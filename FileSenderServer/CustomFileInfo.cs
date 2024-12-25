using System;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Net.Sockets;
using System.Text;

using TcpLib;

namespace FileInfoLib
{
    public class CustomFileInfo
    {

        public string Path { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        public CustomFileInfo(string path, string name, long size)
        {
            Path = path;
            Name = name;
            Size = size;

        }
        public CustomFileInfo()
        {
            Path = "";
            Name = "";
            Size = -1;
        }
        private static async Task SendFileInfo(TcpClient client, CustomFileInfo fileInfo)
        {
            await client.SendString(fileInfo.Name);
            await client.SendInt32((int)fileInfo.Size);
        }

        public static async Task CustomSendFile(TcpClient client, CustomFileInfo fileInfo)
        {
            string path = fileInfo.Path + "\\" + fileInfo.Name;
            using (FileStream fileStream = new FileStream(path,
                   FileMode.Open, FileAccess.Read))
            {
                await SendFileInfo(client, fileInfo);
                await client.SendFile(fileStream);
            }
        }
        private static async Task<CustomFileInfo> ReceiveFileInfo(TcpClient client)
        {
            string fileName = await client.ReceiveString();
            long fileSize = await client.ReceiveInt32();

            return new CustomFileInfo("", fileName, fileSize);
        }


        public static async Task <CustomFileInfo> CustomReceiveFile(TcpClient client, string destinationPath)
        {

            CustomFileInfo fileInfo = await ReceiveFileInfo(client);
            destinationPath = destinationPath + "\\" + fileInfo.Name;

            using (FileStream fileStream = new FileStream(destinationPath,
                   FileMode.Create, FileAccess.Write))
            {
                await client.ReceiveFile(fileStream);
                return fileInfo;
            }
        }
    }
}
