using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Interfacer
{
    public partial class Form1 : Form
    {

        int X_Axis_Movement;
        int Y_Axis_Movement;
        int Z_Axis_Movement;
        static string Controller_IP_Address = "127.0.0.1";


        public Form1()
        {
            InitializeComponent();

            X_Axis_Movement = trackBar1.Value - (trackBar1.Maximum / 2);
            Y_Axis_Movement = trackBar2.Value - (trackBar2.Maximum / 2);
            Z_Axis_Movement = trackBar3.Value - (trackBar3.Maximum / 2);

        }

        
        










        

        

      


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Update_Movement();
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Update_Movement();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Update_Movement();
        }


        


        private void button1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 50;
            Update_Movement();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 50;
            Update_Movement();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trackBar3.Value = 50;
            Update_Movement();
        }






        void Update_Movement()
        {
            X_Axis_Movement = trackBar1.Value - (trackBar1.Maximum / 2);
            Y_Axis_Movement = trackBar2.Value - (trackBar2.Maximum / 2);
            Z_Axis_Movement = trackBar3.Value - (trackBar3.Maximum / 2);

            Send_UDP("X-AXIS_MOV:" + X_Axis_Movement + ";Y-AXIS_MOV:" + Y_Axis_Movement + ";Z-AXIS_MOV:" + Z_Axis_Movement + ";");


        }



        void Send_UDP(string Data_To_Send)
        {
            var data = new byte[7000];
            IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Parse(Controller_IP_Address), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            data = Encoding.ASCII.GetBytes(Data_To_Send);
            server.SendTo(data, data.Length, SocketFlags.None, RemoteEndPoint);
            //Console.WriteLine("Data Sent..." + DateTime.Now + " [" + counter + "]");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Send_UDP("S090:50;");
            }
            else
            {
                Send_UDP("S090:0;");
            }

        }
    }
}
