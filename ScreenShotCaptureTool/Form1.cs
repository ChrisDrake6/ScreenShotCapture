using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Drawing.Imaging;

/* Sources
 * https://medium.com/@rabeeqiblawi/implementing-a-basic-tcp-server-in-unity-a-step-by-step-guide-449d8504d1c5
 * https://learn.microsoft.com/de-de/dotnet/fundamentals/networking/sockets/socket-services
 * https://learn.microsoft.com/de-de/dotnet/api/system.net.sockets.socket.sendfile?view=net-8.0
 * https://stackoverflow.com/questions/8403560/c-sharp-sending-screenshot-in-socket
 * https://stackoverflow.com/questions/5527670/socket-is-not-working-as-it-should-help/5575287#5575287
 * https://stackoverflow.com/questions/453161/how-can-i-save-application-settings-in-a-windows-forms-application
 */

namespace ScreenShotCaptureTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Socket server = null;
            Socket client = null;

            try
            {
                // Setup server
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, int.Parse(Input_Port.Text));
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipep);
                server.Listen(100);

                while (true)
                {
                    // Get client
                    Log("Waiting for connection...");
                    client = server.Accept();
                    Log("Connected!");

                    // Handle setting saving
                    if (Check_Save.Checked)
                    {
                        Properties.Settings.Default.Port = int.Parse(Input_Port.Text);
                        Properties.Settings.Default.Command = Input_Command.Text;
                    }
                    Properties.Settings.Default.SaveSettings = Check_Save.Checked;
                    Properties.Settings.Default.Save();

                    // Wait for command
                    var buffer = new byte[1024];
                    var received = client.Receive(buffer, SocketFlags.None);
                    var response = Encoding.UTF8.GetString(buffer, 0, received);

                    if (response == Input_Command.Text)
                    {
                        // Generate Screenshot
                        Rectangle bounds = Screen.AllScreens[0].Bounds;
                        Bitmap bmpScreenShot = new Bitmap(bounds.Width, bounds.Height);
                        Graphics gfx = Graphics.FromImage(bmpScreenShot);

                        gfx.CopyFromScreen(0, 0, 0, 0, new Size(bounds.Width, bounds.Height));
                        MemoryStream stream = new MemoryStream();
                        bmpScreenShot.Save(stream, ImageFormat.Jpeg);

                        // Send Screenshot data to cient
                        byte[] imageData = stream.ToArray();
                        await client.SendAsync(imageData);

                        stream.Close();
                    }
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
                client?.Shutdown(SocketShutdown.Both);
                client?.Close();
            }
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
            Input_Command.Text = Properties.Settings.Default.Command;
            Check_Save.Checked = Properties.Settings.Default.SaveSettings;
        }
    }
}
