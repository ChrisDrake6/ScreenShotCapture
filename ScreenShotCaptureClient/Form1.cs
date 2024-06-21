using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ScreenShotCaptureClient
{
    public partial class Form1 : Form
    {
        List<byte> fullData = new List<byte>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            Socket server = null;
            try
            {
                // Setup connection
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[1];

                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(Input_IP.Text), int.Parse(Input_Port.Text));
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect to server
                Log("Waiting for connection...");
                server.Connect(ipep);
                Log("Connected!");

                // Handle setting saving
                if (Check_Save.Checked)
                {
                    Properties.Settings.Default.Port = int.Parse(Input_Port.Text);
                    Properties.Settings.Default.ServerIP = Input_IP.Text;
                    Properties.Settings.Default.Command = Input_Command.Text;
                }
                Properties.Settings.Default.SaveSettings = Check_Save.Checked;
                Properties.Settings.Default.Save();

                // Send Command
                server.Send(Encoding.UTF8.GetBytes(Input_Command.Text));


                while (true)
                {
                    // Wait for file data
                    byte[] buffer = new byte[1024 * 5000];
                    int received = await server.ReceiveAsync(buffer, SocketFlags.None);

                    fullData.AddRange(buffer);
                    
                    saveFileDialog1.ShowDialog();
                    Log("File Recieved");
                    Log("Connection Closed");
                }

            }
            catch (Exception ex)
            {
                Log("Exception: " + ex.Message);
            }
            finally
            {
                server?.Shutdown(SocketShutdown.Both);
                server?.Close();
            }
        }

        /// <summary>
        /// Save screenshot and open it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BinaryWriter bWrite = new BinaryWriter(File.Create(saveFileDialog1.FileName));
            bWrite.Write(fullData.ToArray());
            bWrite.Close();
            Process.Start("explorer.exe", saveFileDialog1.FileName);
        }

        /// <summary>
        /// Display Message with new line
        /// </summary>
        /// <param name="message"></param>
        private void Log(string message)
        {
            Logger.AppendText(message);
            Logger.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Load user settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Input_Port.Text = Properties.Settings.Default.Port.ToString();
            Input_IP.Text = Properties.Settings.Default.ServerIP;
            Input_Command.Text = Properties.Settings.Default.Command;
            Check_Save.Checked = Properties.Settings.Default.SaveSettings;
        }
    }
}
