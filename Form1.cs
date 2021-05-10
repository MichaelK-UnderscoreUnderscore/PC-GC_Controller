using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XInputNET.Abstraction;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace PC_GC_Controller
{
    public partial class Form1 : Form
    {
        Gamepad Pad1;
        bool sync1 = false;
        Thread s1;
        public Form1()
        {
            InitializeComponent();
            checkControllers();
            
            s1 = new Thread(() => sync(ref Pad1, ref serialPort1, ref sync1, ref checkBoxNoAnalog));
            
            s1.Start();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            checkControllers();
        }

        private void checkControllers()
        {
            comboBox1Controller.Items.Clear();

            comboBox1Serial.Items.Clear();

            List<Gamepad> gPad;
            gPad = Gamepad.GetConnectedDevices();
            foreach (Gamepad g in gPad)
            {
                comboBox1Controller.Items.Add("Controller " + g.UserIndex);
            }

            string[] ports = SerialPort.GetPortNames();
            comboBox1Serial.Items.AddRange(ports);
        }

        private void button1Connect_Click(object sender, EventArgs e)
        {
            sync1 = false;
            Thread.Sleep(5);
            serialPort1.Close();
            if (button1Connect.Text == "Connect")
            {
                try
                {
                    int controller = (int)char.GetNumericValue(comboBox1Controller.Text.ElementAt(11));

                    Pad1 = Gamepad.GetConnectedDevices()[controller];

                    serialPort1.PortName = comboBox1Serial.Text;

                    serialPort1.Open();
                    sync1 = true;
                    button1Connect.Text = "Disconnect";
                }
                catch
                {
                    serialPort1.Close();
                    Pad1 = null;
                    sync1 = false;
                    button1Connect.Text = "Connect";
                }
            }
            else
            {
                serialPort1.Close();
                Pad1 = null;
                sync1 = false;
                button1Connect.Text = "Connect";
            }
        }

        public static void sync(ref Gamepad Pad, ref SerialPort SP, ref bool sync, ref CheckBox noAnalog)
        {
            double threshhold = 0.4;
            while (true)
            {
                if (sync)
                {
                    if (SP.ReadExisting().Contains("a"))
                    {
                        int t1 = 0;
                        t1 = t1 + Convert.ToInt32(Pad.A) * 1;
                        t1 = t1 + Convert.ToInt32(Pad.B) * 2;
                        t1 = t1 + Convert.ToInt32(Pad.X) * 4;
                        t1 = t1 + Convert.ToInt32(Pad.Y) * 8;
                        t1 = t1 + Convert.ToInt32(Pad.Back) * 16;
                        t1 = t1 + Convert.ToInt32(Pad.Start) * 32;
                        t1 = t1 + Convert.ToInt32(Pad.R || (noAnalog.Checked && Pad.RightTrigger == 1)) * 64;
                        t1 = t1 + Convert.ToInt32(Pad.L || (noAnalog.Checked && Pad.LeftTrigger == 1)) * 128;

                        int t2 = 0;
                        
                        t2 = t2 + Convert.ToInt32(Pad.DPadLeft || (noAnalog.Checked && Pad.LeftThumbX < -threshhold)) * 1;
                        t2 = t2 + Convert.ToInt32(Pad.DPadRight || (noAnalog.Checked && Pad.LeftThumbX > threshhold)) * 2;
                        t2 = t2 + Convert.ToInt32(Pad.DPadUp || (noAnalog.Checked && Pad.LeftThumbY > threshhold)) * 4;
                        t2 = t2 + Convert.ToInt32(Pad.DPadDown || (noAnalog.Checked && Pad.LeftThumbY < -threshhold)) * 8;
                        t2 = t2 + Convert.ToByte(noAnalog.Checked) * 16; // If set, Arduino will skip the Analog Bytes

                        if (noAnalog.Checked)
                        {
                            SP.Write(new byte[2]{
                                    (byte)t1,
                                    (byte)t2,
                                }, 0, 2);
                        }
                        else
                        {
                            SP.Write(new byte[8]{
                                    (byte)t1,
                                    (byte)t2,
                                    Convert.ToByte(GetScaling(Pad.LeftThumbX)),
                                    Convert.ToByte(GetScaling(Pad.LeftThumbY)),
                                    Convert.ToByte(GetScaling(Pad.RightThumbX)),
                                    Convert.ToByte(GetScaling(Pad.RightThumbY)),
                                    Convert.ToByte(GetScaling(Pad.LeftTrigger)),
                                    Convert.ToByte(GetScaling(Pad.RightTrigger))
                                }, 0, 8);
                        }
                        Debug.WriteLine(t1.ToString());
                        Debug.WriteLine(t2.ToString());

                        SP.DiscardInBuffer();
                    }
                }
            }
        }

        public static double GetScaling(double input, double minIn = -1, double maxIn = 1, double minOut = 0, double maxOut = 255)
        {
            double m = (maxOut - minOut) / (maxIn - minIn);
            double c = minOut - minIn * m;

            return m * input + c;
        }

        private void Form1_Close(object sender, EventArgs e)
        {
            s1.Abort();
            //s2.Abort();
            //s3.Abort();
            //s4.Abort();
        }
    }
}
