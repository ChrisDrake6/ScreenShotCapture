namespace ScreenShotCaptureTool
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
            label2 = new Label();
            label1 = new Label();
            Input_Command = new TextBox();
            Input_Port = new TextBox();
            Check_Save = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(399, 346);
            button1.Name = "button1";
            button1.Size = new Size(360, 92);
            button1.TabIndex = 0;
            button1.Text = "Start Tool";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Logger
            // 
            Logger.Location = new Point(399, 20);
            Logger.Multiline = true;
            Logger.Name = "Logger";
            Logger.ReadOnly = true;
            Logger.Size = new Size(360, 320);
            Logger.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 240);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 9;
            label2.Text = "Command";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 111);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 8;
            label1.Text = "Port";
            // 
            // Input_Command
            // 
            Input_Command.Location = new Point(25, 263);
            Input_Command.Name = "Input_Command";
            Input_Command.Size = new Size(345, 27);
            Input_Command.TabIndex = 7;
            // 
            // Input_Port
            // 
            Input_Port.Location = new Point(25, 134);
            Input_Port.Name = "Input_Port";
            Input_Port.Size = new Size(345, 27);
            Input_Port.TabIndex = 6;
            // 
            // Check_Save
            // 
            Check_Save.AutoSize = true;
            Check_Save.Location = new Point(25, 346);
            Check_Save.Name = "Check_Save";
            Check_Save.Size = new Size(119, 24);
            Check_Save.TabIndex = 10;
            Check_Save.Text = "Save Settings";
            Check_Save.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Check_Save);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Input_Command);
            Controls.Add(Input_Port);
            Controls.Add(Logger);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Server";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox Logger;
        private Label label2;
        private Label label1;
        private TextBox Input_Command;
        private TextBox Input_Port;
        private CheckBox Check_Save;
    }
}
