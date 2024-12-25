namespace FileSenderClient
{
    partial class FrmFileSenderClient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlSend = new Panel();
            btnShowHint = new Button();
            btnConnect = new Button();
            btnReceive = new Button();
            lblMessage = new Label();
            btnSend = new Button();
            label4 = new Label();
            tbIpAddress = new TextBox();
            btnFile = new Button();
            btnDir = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tbFileSize = new TextBox();
            tbFileName = new TextBox();
            tbDir = new TextBox();
            ttBtnReceive = new ToolTip(components);
            pnlSend.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSend
            // 
            pnlSend.Controls.Add(btnShowHint);
            pnlSend.Controls.Add(btnConnect);
            pnlSend.Controls.Add(btnReceive);
            pnlSend.Controls.Add(lblMessage);
            pnlSend.Controls.Add(btnSend);
            pnlSend.Controls.Add(label4);
            pnlSend.Controls.Add(tbIpAddress);
            pnlSend.Controls.Add(btnFile);
            pnlSend.Controls.Add(btnDir);
            pnlSend.Controls.Add(label3);
            pnlSend.Controls.Add(label2);
            pnlSend.Controls.Add(label1);
            pnlSend.Controls.Add(tbFileSize);
            pnlSend.Controls.Add(tbFileName);
            pnlSend.Controls.Add(tbDir);
            pnlSend.Dock = DockStyle.Fill;
            pnlSend.Location = new Point(0, 0);
            pnlSend.Name = "pnlSend";
            pnlSend.Size = new Size(814, 186);
            pnlSend.TabIndex = 0;
            // 
            // btnShowHint
            // 
            btnShowHint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnShowHint.Location = new Point(643, 144);
            btnShowHint.Name = "btnShowHint";
            btnShowHint.Size = new Size(157, 27);
            btnShowHint.TabIndex = 15;
            btnShowHint.Text = "Показать подсказку";
            btnShowHint.UseVisualStyleBackColor = true;
            btnShowHint.Click += btnShowHint_Click;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConnect.Location = new Point(562, 111);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(238, 27);
            btnConnect.TabIndex = 14;
            btnConnect.Text = "Подключиться к серверу";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnReceive
            // 
            btnReceive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReceive.Location = new Point(661, 78);
            btnReceive.Name = "btnReceive";
            btnReceive.Size = new Size(139, 27);
            btnReceive.TabIndex = 13;
            btnReceive.Text = "Включить приём";
            btnReceive.UseVisualStyleBackColor = true;
            btnReceive.Click += btnReceive_Click;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(12, 157);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(91, 20);
            lblMessage.TabIndex = 12;
            lblMessage.Text = "Сообщение";
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.Location = new Point(562, 78);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(93, 27);
            btnSend.TabIndex = 10;
            btnSend.Text = "Отправить";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 114);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 9;
            label4.Text = "Ip Адрес:";
            // 
            // tbIpAddress
            // 
            tbIpAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbIpAddress.Location = new Point(128, 111);
            tbIpAddress.Name = "tbIpAddress";
            tbIpAddress.Size = new Size(428, 27);
            tbIpAddress.TabIndex = 8;
            // 
            // btnFile
            // 
            btnFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFile.Location = new Point(562, 45);
            btnFile.Name = "btnFile";
            btnFile.Size = new Size(238, 27);
            btnFile.TabIndex = 7;
            btnFile.Text = "Выбрать файл для отправки";
            btnFile.UseVisualStyleBackColor = true;
            btnFile.Click += btnFile_Click;
            // 
            // btnDir
            // 
            btnDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDir.Location = new Point(562, 12);
            btnDir.Name = "btnDir";
            btnDir.Size = new Size(238, 27);
            btnDir.TabIndex = 6;
            btnDir.Text = "Выбрать путь сохранения";
            btnDir.UseVisualStyleBackColor = true;
            btnDir.Click += btnDir_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 81);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 5;
            label3.Text = "Размер файла:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 4;
            label2.Text = "Файл:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 3;
            label1.Text = "Путь к файлу:";
            // 
            // tbFileSize
            // 
            tbFileSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFileSize.Location = new Point(128, 78);
            tbFileSize.Name = "tbFileSize";
            tbFileSize.Size = new Size(428, 27);
            tbFileSize.TabIndex = 2;
            // 
            // tbFileName
            // 
            tbFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFileName.Location = new Point(128, 45);
            tbFileName.Name = "tbFileName";
            tbFileName.Size = new Size(428, 27);
            tbFileName.TabIndex = 1;
            // 
            // tbDir
            // 
            tbDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDir.Location = new Point(128, 12);
            tbDir.Name = "tbDir";
            tbDir.Size = new Size(428, 27);
            tbDir.TabIndex = 0;
            // 
            // FrmFileSenderClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 186);
            Controls.Add(pnlSend);
            Name = "FrmFileSenderClient";
            Text = "Файловый менеджер";
            Load += FrmFileSenderClient_Load;
            pnlSend.ResumeLayout(false);
            pnlSend.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSend;
        private Label label4;
        private TextBox tbIpAddress;
        private Button btnFile;
        private Button btnDir;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbFileSize;
        private TextBox tbFileName;
        private TextBox tbDir;
        private Button btnSend;
        private Label lblMessage;
        private ToolTip ttBtnReceive;
        private Button btnReceive;
        private Button btnConnect;
        private Button btnShowHint;
    }
}
