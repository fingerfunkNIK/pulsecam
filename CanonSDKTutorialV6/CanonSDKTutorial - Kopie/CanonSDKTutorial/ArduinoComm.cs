using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace CanonPulse
{
    class ArduinoComm
    {
        private int AbaudRate = 9600;
        private SerialPort currentPort;
        private bool portFound;
        private bool ArduinoFound;
        private INITSTATE initstate;
        private System.Windows.Forms.Timer readTimer;
        public enum LEDCOLOR
        {
            RED=1,
            GREEN=2,
            YELLOW=3,
            BUTTONS=4
        }
        private enum INITSTATE
        {
            NOTHING,
            ARDUINOHANDSHAKE,
            ARDUINOERR,
            ARDUINOCONNECTED
        }
        public enum OUTSIGNAL
        {
            LAMPON=2,
            LAMPOFF=3,
            OK_BTN_ON=12,
            OK_BTN_OFF=13,
            TRIG_BTN_ON=22,
            TRIG_BTN_OFF=23,
            CANCEL_BTN_ON=32,
            CANCEL_BTN_OFF=33
        }

        public delegate void ChangedEventHandler(object sender, EventArgs e,string msg,bool always);
        public event ChangedEventHandler arduinoChanged;

        public delegate void HeartbeatEventHandler(object sender, EventArgs e, int hb);
        public event HeartbeatEventHandler arduinoHeartBeat;

        public delegate void A_ButtonEventHandler(object sender, EventArgs e, string btnName);
        public event A_ButtonEventHandler arduinoBtnPress;

        public void startArduino()
        {
            initstate = INITSTATE.ARDUINOHANDSHAKE;
            SetComPort();
        }

        public void stopArduino ()
        {
            if (currentPort != null)
            {
                currentPort.Close();
                currentPort = null;
            }
        }


        public void sendSignal(OUTSIGNAL s)
        {
            try
            {
                writeLog("Arduino out: " + s.ToString());
            }
            catch
            {
                writeLog("Arduino out: ERR" + s.ToString());
            }
        }

        private void writeLog(string s,bool always=false)
        {
            if (arduinoChanged != null)
                arduinoChanged(this,EventArgs.Empty, s,always);  
        }

        private void SetComPort()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                if (ports.Length == 0)
                {
                    writeLog("ERROR no com port found, check Arduino connection",true);
                    ArduinoFound = false;
                    return;
                }
                foreach (string port in ports)
                {
                    writeLog("checking port " + port,always:true);
                    currentPort = new SerialPort(port, AbaudRate);
                    if (DetectArduino())
                    {
                        portFound = true;
                        ArduinoFound = true;
                        writeLog("port found " + port,true);
                        readTimer = new System.Windows.Forms.Timer();
                        readTimer.Interval = 100; // specify interval time as you want
                        readTimer.Tick += new EventHandler(readtimer_Tick);
                        readTimer.Start();
                        break;
                    }
                    else
                    {
                        writeLog("ERROR port NOT found " + port,true);
                        writeLog("CHECK CONNECTION AND RESTART", true);
                        ArduinoFound = false;
                        portFound = false;
                    }
                }
            }
            catch (Exception e)
            {
                writeLog(" arduino error " + e.ToString(),true);
            }
        }
        public void setLedLampOn(LEDCOLOR lc)
        {
            byte[] buffer = new byte[2];
            buffer[0] = Convert.ToByte(16);
            switch (lc)
            {
                case LEDCOLOR.RED:
                    buffer[1] = Convert.ToByte(1);
                    if (!currentPort.IsOpen)
                        currentPort.Open();
                    currentPort.Write(buffer, 0, 2);
                break;
                case LEDCOLOR.GREEN:
                         buffer[1] = Convert.ToByte(2);
                    if (!currentPort.IsOpen)
                        currentPort.Open();
                    currentPort.Write(buffer, 0, 2);
                break;

                case LEDCOLOR.YELLOW:
                    buffer[1] = Convert.ToByte(3);
                    if (!currentPort.IsOpen)
                        currentPort.Open();
                    currentPort.Write(buffer, 0, 2);
                    break;
                case LEDCOLOR.BUTTONS:
                    buffer[1] = Convert.ToByte(4);
                    if (!currentPort.IsOpen)
                        currentPort.Open();
                    currentPort.Write(buffer, 0, 2);
                    break;
                         
            }
        }
        private void readtimer_Tick(object sender, EventArgs e)
        {
            //writeLog("read timer");
            int count = currentPort.BytesToRead;
            string returnMessage = "";
            int intReturnASCII = 0;
            while (count > 0)
            {
                intReturnASCII = currentPort.ReadByte();
                returnMessage+= Convert.ToChar(intReturnASCII);
                count--;
            }
            if (returnMessage.StartsWith("BXq") )
            {
                int BPM;
                bool result = Int32.TryParse(returnMessage.Remove(0,3), out BPM);
                if (result)
                {
                    writeLog("BPM " + BPM.ToString(),false);
                    if (arduinoHeartBeat != null)
                        arduinoHeartBeat(this, EventArgs.Empty, BPM);  
                }
                return;
            }
  
            if (returnMessage.StartsWith("X_"))
            {
            string bname=returnMessage.Remove(0,2);
            writeLog("BTN " + bname);
            if (arduinoBtnPress != null)
                arduinoBtnPress(this, EventArgs.Empty, bname);
            }
            
                
        }

        private bool DetectArduino()
        {
            try
            {
                //The below setting are for the Hello handshake
                byte[] buffer = new byte[2];
                buffer[0] = Convert.ToByte(16);
                buffer[1] = Convert.ToByte(128);
               
                int intReturnASCII = 0;
                char charReturnValue = (Char)intReturnASCII;
                currentPort.Open();
                currentPort.Write(buffer, 0, 2);
                writeLog("sending data to port ",true);
                Thread.Sleep(1000);

                int count = currentPort.BytesToRead;
                string returnMessage = "";
                while (count > 0)
                {
                    intReturnASCII = currentPort.ReadByte();
                    returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                    count--;
                }

           
                if (returnMessage.Contains("HELLO FROM ARDUINO"))
                {
                    writeLog("received " + returnMessage,true);
                    return true;
                }
                else
                {
                    writeLog("received ERR " + returnMessage,true);
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
