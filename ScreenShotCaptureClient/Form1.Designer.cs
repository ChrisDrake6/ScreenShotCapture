namespace ScreenShotCaptureClient
{
    partial class Form1
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
            button1 = new Button();
            Logger = new TextBox();
            saveFileDialog1 = new SaveFileDialog();
            Input_Port = new TextBox();
            Input_IP = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Input_Command = new TextBox();
            Check_Save = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(401, 341);
            button1.Name = "button1";
            button1.Size = new Size(361, 88);
            button1.TabIndex = 0;
            button1.Text = "Request Screenshot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Logger
            // 
            Logger.Location = new Point(401, 12);
            Logger.Multiline = true;
            Logger.Name = "Logger";
            Logger.ReadOnly = true;
            Logger.Size = new Size(361, 323);
            Logger.TabIndex = 1;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "jpeg";
            saveFileDialog1.FileName = "Screenshot.jpeg";
            saveFileDialog1.Filter = "Image Files (*.jpeg)|*.jpeg";
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // Input_Port
            // 
            Input_Port.Location = new Point(33, 76);
            Input_Port.Name = "Input_Port";
            Input_Port.Size = new Size(345, 27);
            Input_Port.TabIndex = 2;
            // 
            // Input_IP
            // 
            Input_IP.Location = new Point(33, 171);
            Input_IP.Name = "Input_IP";
            Input_IP.Size = new Size(345, 27);
            Input_IP.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 53);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 4;
            label1.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 148);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 5;
            label2.Text = "Server IP Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 249);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 7;
            label3.Text = "Command";
            // 
            // Input_Command
            // 
            Input_Command.Location = new Point(33, 272);
            Input_Command.Name = "Input_Command";
            Input_Command.Size = new Size(345, 27);
            Input_Command.TabIndex = 6;
            // 
            // Check_Save
            // 
            Check_Save.AutoSize = true;
            Check_Save.Location = new Point(33, 341);
            Check_Save.Name = "Check_Save";
            Check_Save.Size = new Size(119, 24);
            Check_Save.TabIndex = 8;
            Check_Save.Text = "Save Settings";
            Check_Save.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Check_Save);
            Controls.Add(label3);
            Controls.Add(Input_Command);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Input_IP);
            Controls.Add(Input_Port);
            Controls.Add(Logger);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Client";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox Logger;
        private SaveFileDialog saveFileDialog1;
        private TextBox Input_Port;
        private TextBox Input_IP;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox Input_Command;
        private CheckBox Check_Save;
    }
}
