using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;
using EDSDKLib;

namespace CanonPulse
{
    public partial class MainForm :Form
    {
        SDKHandler CameraHandler;
        List<int> AvList;
        List<int> TvList;
        List<int> ISOList;
        List<Camera> CamList;
        Bitmap Evf_Bmp;
        int LVBw, LVBh, w, h;
        float LVBratio, LVration;
        private VideoForm2 vf2 = null;
        private ArduinoComm ArduinoLink;
        private printerHandler printerhandler;

        private Bitmap printCapture;
        public string lastSavedImageFileName;


       private  const string    instaImageDirectory = @"D:\PepsiPulse\\pulse_camera\";
       private const string  printImageDirectory = @"D:\PepsiPulse\PRINT\";
       private const string   tempImageDirectory = @"D:\PepsiPulse\TMP\";

        private Bitmap instaCapture;
        private string instaFileNameWithPath;

        private System.Windows.Forms.Timer countdowntimer;
        private System.Windows.Forms.Timer printtimer;
        private System.Windows.Forms.Timer waitForCamToDownloadTimer;
        private System.Windows.Forms.Timer BPMtimer;//random variance
        private System.Windows.Forms.Timer BPMMaintimer;

        private int countdownNumberOfHits = 0;
        private int numHitsBeforeTrig = 8;//todo make this dynamic!
        private int numPicsToTake;
        private int numcopiestoprint = 1;
        private int requiredPulse;

        private bool isVerbose;
        private audioHandler audiohandler;
        public CAMTYPE currentCamType { get; private set; }
        public static float currentAvgBPM { get; private set; }
        public static bool isBPMMeasuring { get; private set; }
        private int bpmTestLength = 10000;

        private Bitmap bitmap;
        public enum CAMTYPE
        {
            PULSETRIGGERED,
            SELFTIMER
        }
        private PULSECAMSTATE currentPulseCamState;
        public enum PULSECAMSTATE
        {
            NOTHING,
            MEASURING,
            TARGETREACHED,
            SHUTTERACTION,
            WAITFOROK,
            PRINTING
        }

        private SELFCAMSTATE currentSelfCamState;
        public enum SELFCAMSTATE
        {
            NOTHING,
            TIMERRUNNING,
            SHUTTERACTION,
            WAITFOROK,
            PRINTING
        }
 
        public  MainForm()
        {
            InitializeComponent();
            CameraHandler = new SDKHandler();
            CameraHandler.CameraAdded += new SDKHandler.CameraAddedHandler(SDK_CameraAdded);
            CameraHandler.LiveViewUpdated += new SDKHandler.StreamUpdate(SDK_LiveViewUpdated);
            CameraHandler.ProgressChanged += new SDKHandler.ProgressHandler(SDK_ProgressChanged);
            CameraHandler.CameraHasShutdown += CameraHandler_CameraHasShutdown;
           // SavePathTextBox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "RemotePhoto");
            LVBw = LiveViewPicBox.Width;
            LVBh = LiveViewPicBox.Height;
            RefreshCamera();
            // from old app
            audiohandler = new audioHandler();
            audiohandler.playsound(audioHandler.SOUNDTYPE.HEARTBEAT);

            countdowntimer = new System.Windows.Forms.Timer();
            countdowntimer.Tick += new EventHandler(timer_Tick);

            printtimer = new System.Windows.Forms.Timer();
            printtimer.Tick += new EventHandler(printTimer_Tick);

            BPMtimer = new System.Windows.Forms.Timer();
            BPMtimer.Tick += new EventHandler(BPMtimer_Tick);

            BPMMaintimer = new System.Windows.Forms.Timer();
            BPMMaintimer.Tick += new EventHandler(BPMMaintimer_Tick);

            ArduinoLink = new ArduinoComm();
            ArduinoLink.arduinoChanged += ArduinoLink_arduinoChanged;
            ArduinoLink.arduinoHeartBeat += ArduinoLink_arduinoHeartBeat;
            ArduinoLink.arduinoBtnPress += ArduinoLink_arduinoBtnPress;
            ArduinoLink.startArduino();
            printerhandler = new printerHandler();
            printerhandler.printLogMsg += printerhandler_printErrMsg;
            printerhandler.CheckPrinter();
       
            currentCamType = CAMTYPE.SELFTIMER;
         
            numHitsBeforeTrig = Properties.Settings.Default.selfTimerLen;

            numcopiestoprint = Properties.Settings.Default.numcopiestoprint;
            switch (numcopiestoprint)
            {
                case 0:
                    print0_rb.Checked = true;
                    break;
                case 1:
                    print1_rb.Checked = true;
                    break;
                case 2:
                    print2_rb.Checked = true;
                    break;
            }

            print0_rb.CheckedChanged += new EventHandler(printcopies_CheckedChanged);
            print1_rb.CheckedChanged += new EventHandler(printcopies_CheckedChanged);
            print2_rb.CheckedChanged += new EventHandler(printcopies_CheckedChanged);

            numHitsBeforeTrig = Properties.Settings.Default.selfTimerLen;
            timeUpDown.Value = numHitsBeforeTrig;

            numPicsToTake = 1;
            isVerbose = Properties.Settings.Default.verbose;
            cb_verbose.Checked = isVerbose;
            cb_verbose.CheckedChanged += cb_verbose_CheckedChanged;
    
        }


        private void SDK_ProgressChanged(int Progress)
        {
            MainProgressBar.Value = Progress;
        }


        private void SDK_LiveViewUpdated(Stream img)
        {
            Evf_Bmp = new Bitmap(img);
            using (Graphics g = LiveViewPicBox.CreateGraphics())
            {
                LVBratio = LVBw / (float)LVBh;
                LVration = Evf_Bmp.Width / (float)Evf_Bmp.Height;
                if (LVBratio < LVration)
                {
                    w = LVBw;
                    h = (int)(LVBw / LVration);
                }
                else
                {
                    w = (int)(LVBh * LVration);
                    h = LVBh;
                }
                g.DrawImage(Evf_Bmp, 0, 0, w, h);
            }
            vf2.setBackGroundImage(Evf_Bmp);
        }

        private void SDK_CameraAdded()
        {
            RefreshCamera();
        }

        private void CameraHandler_CameraHasShutdown(object sender, EventArgs e)
        {
            CloseSession();
        }
        

        private void SessionButton_Click(object sender, EventArgs e)
        {            
            if (CameraHandler.CameraSessionOpen) CloseSession();
            else OpenSession();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshCamera();
        }

        private void LiveViewButton_Click(object sender, EventArgs e)
        {
            if (!CameraHandler.IsLiveViewOn) 
            { CameraHandler.StartLiveView();
                LiveViewButton.Text = "Stop LV";
                vf2 = new VideoForm2();
                vf2.Show();
            }
            else { 
                CameraHandler.StopLiveView(); 
                LiveViewButton.Text = "Start LV"; }
        }

        private void LiveViewPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            //if (CameraHandler.IsLiveViewOn && CameraHandler.IsCoordSystemSet)
            //{
            //    ushort x = (ushort)((e.X / LiveViewPicBox.Width) * CameraHandler.Evf_CoordinateSystem.width);
            //    ushort y =(ushort)((e.Y / LiveViewPicBox.Height) * CameraHandler.Evf_CoordinateSystem.height);
            //    CameraHandler.SetManualWBEvf(x, y);
            //}
        }
        
        private void LiveViewPicBox_SizeChanged(object sender, EventArgs e)
        {
            //LVBw = LiveViewPicBox.Width;
            //LVBh = LiveViewPicBox.Height;
        }

        private void FocusNear3Button_Click(object sender, EventArgs e)
        {
            CameraHandler.SetFocus(EDSDK.EvfDriveLens_Near3);
        }

        private void FocusNear2Button_Click(object sender, EventArgs e)
        {
            CameraHandler.SetFocus(EDSDK.EvfDriveLens_Near2);
        }

        private void FocusNear1Button_Click(object sender, EventArgs e)
        {
            CameraHandler.SetFocus(EDSDK.EvfDriveLens_Near1);
        }

        private void FocusFar1Button_Click(object sender, EventArgs e)
        {
            CameraHandler.SetFocus(EDSDK.EvfDriveLens_Far1);
        }

        private void FocusFar2Button_Click(object sender, EventArgs e)
        {
            CameraHandler.SetFocus(EDSDK.EvfDriveLens_Far2);
        }

        private void FocusFar3Button_Click(object sender, EventArgs e)
        {
            CameraHandler.SetFocus(EDSDK.EvfDriveLens_Far3);
        }
        

        //private void BrowseButton_Click(object sender, EventArgs e)
        //{
        //    if (Directory.Exists(SavePathTextBox.Text)) SaveFolderBrowser.SelectedPath = SavePathTextBox.Text;
        //    if (SaveFolderBrowser.ShowDialog() == DialogResult.OK) SavePathTextBox.Text = SaveFolderBrowser.SelectedPath;
        //}

        private void AvCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CameraHandler.SetSetting(EDSDK.PropID_Av, CameraValues.AV((string)AvCoBox.SelectedItem));
        }

        private void TvCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CameraHandler.SetSetting(EDSDK.PropID_Tv, CameraValues.TV((string)TvCoBox.SelectedItem));
            //if ((string)TvCoBox.SelectedItem == "Bulb") BulbUpDo.Enabled = true;
            //else  BulbUpDo.Enabled = false;
        }

        private void ISOCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CameraHandler.SetSetting(EDSDK.PropID_ISOSpeed, CameraValues.ISO((string)ISOCoBox.SelectedItem));
        }

        private void WBCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (WBCoBox.SelectedIndex)
            {
                case 0: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Auto); break;
                case 1: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Daylight); break;
                case 2: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Cloudy); break;
                case 3: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Tangsten); break;
                case 4: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Fluorescent); break;
                case 5: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Strobe); break;
                case 6: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_WhitePaper); break;
                case 7: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Shade); break;
            }
        }
        
        private void SaveToButton_CheckedChanged(object sender, EventArgs e)
        {
            //if (STCameraButton.Checked)
            //{
            //    CameraHandler.SetSetting(EDSDK.PropID_SaveTo, (uint)EDSDK.EdsSaveTo.Camera);
            //    BrowseButton.Enabled = false;
            //    SavePathTextBox.Enabled = false;
            //}
            //else if (STComputerButton.Checked)
            //{
            //    CameraHandler.SetSetting(EDSDK.PropID_SaveTo, (uint)EDSDK.EdsSaveTo.Host);
            //    CameraHandler.SetCapacity();
            //    BrowseButton.Enabled = true;
            //    SavePathTextBox.Enabled = true;
            //}
            //else if (STBothButton.Checked)
            //{
            //    CameraHandler.SetSetting(EDSDK.PropID_SaveTo, (uint)EDSDK.EdsSaveTo.Both);
            //    CameraHandler.SetCapacity();
            //    BrowseButton.Enabled = true;
            //    SavePathTextBox.Enabled = true;
            //}
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CameraHandler.Dispose();
        }



        private void CloseSession()
        {
            CameraHandler.CloseSession();
            AvCoBox.Items.Clear();
            TvCoBox.Items.Clear();
            ISOCoBox.Items.Clear();
            SettingsGroupBox.Enabled = false;
            LiveViewGroupBox.Enabled = false;
            SessionButton.Text = "Open Session";
            SessionLabel.Text = "No open session";
        }

        private void RefreshCamera()
        {
            CloseSession();
            CameraListBox.Items.Clear();
            CamList = CameraHandler.GetCameraList();
            foreach (Camera cam in CamList) 
                CameraListBox.Items.Add(cam.Info.szDeviceDescription);
            if (CamList.Count > 0)
                CameraListBox.SelectedIndex = 0;
            else
                msgBox.AppendText("ERROR no camera connected" + "\r\n");
            
        }

        public  void logMsg(string msg)
        {
            msgBox.AppendText(msg + "\r\n");
        }

        private void OpenSession()
        {
            if (CameraListBox.SelectedIndex >= 0)
            {
                CameraHandler.OpenSession(CamList[CameraListBox.SelectedIndex]);
                SessionButton.Text = "Close Session";
                string cameraname = CameraHandler.MainCamera.Info.szDeviceDescription;
                SessionLabel.Text = cameraname;
                //if (CameraHandler.GetSetting(EDSDK.PropID_AEMode) != EDSDK.AEMode_Manual) 
                //    MessageBox.Show("Camera is not in manual mode. Some features might not work!");

                AvList = CameraHandler.GetSettingsList((uint)EDSDK.PropID_Av);
                TvList = CameraHandler.GetSettingsList((uint)EDSDK.PropID_Tv);
                ISOList = CameraHandler.GetSettingsList((uint)EDSDK.PropID_ISOSpeed);
                foreach (int Av in AvList) AvCoBox.Items.Add(CameraValues.AV((uint)Av));
                foreach (int Tv in TvList) TvCoBox.Items.Add(CameraValues.TV((uint)Tv));
                foreach (int ISO in ISOList) ISOCoBox.Items.Add(CameraValues.ISO((uint)ISO));
                AvCoBox.SelectedIndex = AvCoBox.Items.IndexOf(CameraValues.AV((uint)CameraHandler.GetSetting((uint)EDSDK.PropID_Av)));
                TvCoBox.SelectedIndex = TvCoBox.Items.IndexOf(CameraValues.TV((uint)CameraHandler.GetSetting((uint)EDSDK.PropID_Tv)));
                ISOCoBox.SelectedIndex = ISOCoBox.Items.IndexOf(CameraValues.ISO((uint)CameraHandler.GetSetting((uint)EDSDK.PropID_ISOSpeed)));
                int wbidx = (int)CameraHandler.GetSetting((uint)EDSDK.PropID_WhiteBalance);
                switch (wbidx)
                {
                    case EDSDK.WhiteBalance_Auto: WBCoBox.SelectedIndex = 0; break;
                    case EDSDK.WhiteBalance_Daylight: WBCoBox.SelectedIndex = 1; break;
                    case EDSDK.WhiteBalance_Cloudy: WBCoBox.SelectedIndex = 2; break;
                    case EDSDK.WhiteBalance_Tangsten: WBCoBox.SelectedIndex = 3; break;
                    case EDSDK.WhiteBalance_Fluorescent: WBCoBox.SelectedIndex = 4; break;
                    case EDSDK.WhiteBalance_Strobe: WBCoBox.SelectedIndex = 5; break;
                    case EDSDK.WhiteBalance_WhitePaper: WBCoBox.SelectedIndex = 6; break;
                    case EDSDK.WhiteBalance_Shade: WBCoBox.SelectedIndex = 7; break;
                    default: WBCoBox.SelectedIndex = -1; break;
                }
                SettingsGroupBox.Enabled = true;
                LiveViewGroupBox.Enabled = true;
                CameraHandler.SetSetting(EDSDK.PropID_SaveTo, (uint)EDSDK.EdsSaveTo.Host);
                CameraHandler.SetCapacity();
                CameraHandler.ImageSaveDirectory = tempImageDirectory;
            }
        }
        //old stuff
        #region timers
        private void BPMMaintimer_Tick(object sender, EventArgs e)
        {
            takeSnapShot();
            BPMtimer.Stop();
            BPMMaintimer.Stop();
        }
        private void BPMtimer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int val = BPMtimer.Interval + rnd.Next(-30, 30); // creates a number between 1 and 12
            BPMtimer.Interval = val;
            currentAvgBPM = 60000f / val;
            audiohandler.playsound(audioHandler.SOUNDTYPE.HEARTBEAT);
            msgBox.AppendText("val " + currentAvgBPM.ToString()  );
        }

        private void printTimer_Tick(object sender, EventArgs e)
        {
            currentSelfCamState = SELFCAMSTATE.NOTHING;
            vf2.changeSelfCamState(currentSelfCamState);
  
            printtimer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            countdownNumberOfHits++;
            if (countdownNumberOfHits >= (numHitsBeforeTrig + numPicsToTake))
            {
                countdowntimer.Stop();
                return;
                //mode is waiting for OK...
            }
            if (countdownNumberOfHits >= numHitsBeforeTrig)
            {
                // audiohandler.playsound(audioHandler.SOUNDTYPE.BUZZER);
                countdowntimer.Interval = 250;
                takeSnapShot();
            }
            else
            {
                audiohandler.playsound(audioHandler.SOUNDTYPE.BUZZER);
                ArduinoLink.sendSignal(ArduinoComm.OUTSIGNAL.LAMPON);

            }
        }
        #endregion
        #region arduinoEvents

        void ArduinoLink_arduinoHeartBeat(object sender, EventArgs e, int hb)
        {
            //figure out the current average heartrate here
            //if it has been more than 10 secs since last time
           
            if (currentCamType == CAMTYPE.PULSETRIGGERED)
                if (currentPulseCamState == PULSECAMSTATE.MEASURING || currentPulseCamState == PULSECAMSTATE.NOTHING)
                {
                    {
                        if (hb > 40 && hb < 190)
                        {
                            currentAvgBPM = 0.9f * currentAvgBPM + hb * 0.1f;
                            currentAvgBPM = Math.Min(currentAvgBPM, 190);
                            currentAvgBPM = Math.Max(currentAvgBPM, 40);
                            string dispBPM = currentAvgBPM.ToString("0");
                            msgBox.AppendText("AVG " + dispBPM + " diff: " + (requiredPulse - currentAvgBPM).ToString("0") + "\r\n");
                        }

                        if (currentAvgBPM < requiredPulse - 30)
                        {
                            ArduinoLink.setLedLampOn(ArduinoComm.LEDCOLOR.RED);
                            return;
                        }
                        if (currentAvgBPM < requiredPulse - 10)
                        {
                            ArduinoLink.setLedLampOn(ArduinoComm.LEDCOLOR.YELLOW);
                            return;
                        }

                        if (currentAvgBPM > requiredPulse)
                        {
                            currentPulseCamState = PULSECAMSTATE.TARGETREACHED;
                            msgBox.AppendText("target reached " + "\r\n");
                            ArduinoLink.setLedLampOn(ArduinoComm.LEDCOLOR.GREEN);
                            audiohandler.playsound(audioHandler.SOUNDTYPE.YES);
                        }
                    }
                }
        }

        void ArduinoLink_arduinoChanged(object sender, EventArgs e, string msg, bool always = false)
        {
            if (isVerbose || always)
                msgBox.AppendText(msg + "\r\n");
        }

        public void logMessage(string msg)
        {
            msgBox.AppendText(msg + "\r\n");
        }
        void ArduinoLink_arduinoBtnPress(object sender, EventArgs e, string msg)
        {
            if (isVerbose)
                msgBox.AppendText("XXXX " + msg + "\r\n");

            if (msg.StartsWith("PT"))
            {
                if (currentCamType == CAMTYPE.PULSETRIGGERED)
                {
                    if (currentAvgBPM >= requiredPulse)
                    {
                        audiohandler.playsound(audioHandler.SOUNDTYPE.YES);
                        //trig the damn thing now
                    }
                    else
                    {
                        int diff = requiredPulse - (int)currentAvgBPM;
                        audiohandler.playsound(diff);
                    }
                }
                else
                    audiohandler.playsound(audioHandler.SOUNDTYPE.ERROR);

                return;
            }

            //cancel
            if (msg.StartsWith("CL"))
            {
                if (currentPulseCamState == PULSECAMSTATE.WAITFOROK || currentSelfCamState == SELFCAMSTATE.WAITFOROK)
                {
                    audiohandler.playsound(audioHandler.SOUNDTYPE.BUTTON);
                    cancel_btn_Click(this, EventArgs.Empty);
                    //TODO ADD CODE TO CANCEL OPERATION
                    return;
                }
                else
                {
                    audiohandler.playsound(audioHandler.SOUNDTYPE.ERROR);
                }
                return;
            }
            if (msg.StartsWith("OK"))
            {
                if (currentPulseCamState == PULSECAMSTATE.WAITFOROK || currentSelfCamState == SELFCAMSTATE.WAITFOROK)
                {
                    audiohandler.playsound(audioHandler.SOUNDTYPE.BUTTON);
                    OK_btn_Click(this, EventArgs.Empty);
                    return;
                }
                else
                {
                    audiohandler.playsound(audioHandler.SOUNDTYPE.ERROR);
                }
                return;
            }

            if (msg.StartsWith("TT"))
            {
                if (currentCamType == CAMTYPE.SELFTIMER)
                {
                    //TIMED TRIGGER
                    if (currentSelfCamState == SELFCAMSTATE.NOTHING)
                    {
                        snapshotBtn_Click(this, EventArgs.Empty);
                    }
                    else
                        audiohandler.playsound(audioHandler.SOUNDTYPE.ERROR);
                }
                else
                {
                    audiohandler.playsound(audioHandler.SOUNDTYPE.ERROR);
                }
                return;
            }
            //fake button pulse trigger start
            if (msg.StartsWith("99"))
            {
                if (currentCamType == CAMTYPE.SELFTIMER)
                {
                    //TIMED TRIGGER
                    if (currentSelfCamState == SELFCAMSTATE.NOTHING)
                    {
                        pulseMeasureStart();
                    }
                    else
                        audiohandler.playsound(audioHandler.SOUNDTYPE.ERROR);
                }
                else
                {
                    audiohandler.playsound(audioHandler.SOUNDTYPE.ERROR);
                }
                return;
            }
            if (msg.StartsWith("00"))
            {
                if (currentCamType == CAMTYPE.SELFTIMER)
                {
                    //TIMED TRIGGER
                    if (currentSelfCamState == SELFCAMSTATE.TIMERRUNNING && isBPMMeasuring)
                    {
                        msgBox.AppendText("stop pulse " + currentAvgBPM.ToString() + "\r\n");
                        pulseMeasureStop();
                    }
                    else
                        audiohandler.playsound(audioHandler.SOUNDTYPE.ERROR);
                }
                else
                {
                    audiohandler.playsound(audioHandler.SOUNDTYPE.ERROR);
                }
                return;
            }

        }
        #endregion
        //TODO remove this redundant code
        private void pulseMeasureStop()
        {

        }
        private void pulseMeasureStart()
        {
            //msgBox.AppendText("pulse start ");
            //BPMMaintimer.Interval = bpmTestLength;
            //BPMtimer.Interval = 600; // specify interval time as you want
            //BPMtimer.Start();
            //BPMMaintimer.Start();
            //currentSelfCamState = SELFCAMSTATE.TIMERRUNNING;
            //isBPMMeasuring = true;
        }

        void printerhandler_printErrMsg(object sender, EventArgs e, string msg)
        {
            logMessage(msg);
        }

        #region settings
        private void cb_verbose_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_verbose.Checked)
            {
                isVerbose = true;
            }
            else
                isVerbose = false;

            Properties.Settings.Default.verbose = isVerbose;
            Properties.Settings.Default.Save();
        }

     

        //private void camtype_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool useP = false;
        //    if (use_NO_P_RB.Checked)
        //    {
        //        useP = false;
        //        currentCamType = CAMTYPE.SELFTIMER;
        //    }
        //    else
        //    {
        //        useP = true;
        //        currentCamType = CAMTYPE.PULSETRIGGERED;
        //    }
        //    Properties.Settings.Default.usepulse = useP;
        //    Properties.Settings.Default.Save();
        //}

        private void printcopies_CheckedChanged(object sender, EventArgs e)
        {
            if (print0_rb.Checked)
            {
                numcopiestoprint = 0;
            }
            if (print1_rb.Checked)
            {
                numcopiestoprint = 1;
            }
            if (print2_rb.Checked)
            {
                numcopiestoprint = 2;
            }
            Properties.Settings.Default.numcopiestoprint = numcopiestoprint;
            Properties.Settings.Default.Save();
        }
        #endregion
        #region buttons
        private void snapshotBtn_Click(object sender, EventArgs e)
        {
            countdownNumberOfHits = 0;
            countdowntimer.Interval = 1000; // specify interval time as you want
            countdowntimer.Start();
            currentSelfCamState = SELFCAMSTATE.TIMERRUNNING;
            isBPMMeasuring = false;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (currentCamType == CAMTYPE.SELFTIMER)
            {
                if (currentSelfCamState == SELFCAMSTATE.WAITFOROK)
                {
                    currentSelfCamState = SELFCAMSTATE.PRINTING;
                    printtimer.Interval = 3000;
                    printtimer.Start();
                    vf2.showCancel();
                    isBPMMeasuring = false;
                }
            }
            else
            {
                MessageBox.Show("err " + currentSelfCamState);
            }

        }
        private  FileInfo GetLatestWritenFileFileInDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null || !directoryInfo.Exists)
                return null;

            FileInfo[] files = directoryInfo.GetFiles();
            DateTime lastWrite = DateTime.MinValue;
            FileInfo lastWritenFile = null;

            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastWrite)
                {
                    lastWrite = file.LastWriteTime;
                    lastWritenFile = file;
                }
            }
            return lastWritenFile;
        }

        private void createPrintImg()
        {
           //this sometimes gets the next last image
            printCapture = new System.Drawing.Bitmap(1200, 1800);
            DirectoryInfo Directory = new DirectoryInfo(tempImageDirectory);
            FileInfo fi = GetLatestWritenFileFileInDirectory(Directory);

            Bitmap image1 = (Bitmap)Image.FromFile(fi.FullName, true);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(printCapture))
            {
                g.Clear(Color.Black);
                g.DrawImage(vf2.printOverLay, new System.Drawing.Rectangle(0, 0, vf2.printOverLay.Width, vf2.printOverLay.Height));
                g.DrawImage(image1, new System.Drawing.Rectangle(0, 70, vf2.printOverLay.Width, vf2.printOverLay.Width), new System.Drawing.Rectangle((image1.Width-vf2.printOverLay.Width)/2, 0, vf2.printOverLay.Width, vf2.printOverLay.Width), GraphicsUnit.Pixel);
            }

            instaCapture = new System.Drawing.Bitmap(640, 640);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(instaCapture))
            {
                //g.Clear(System.Drawing.Color.Black); // Change this to whatever you want the background color to be, you may set this to Color.Transparent as well
                //g.DrawImage(vf2.bild, new System.Drawing.Rectangle(-319, -44, 1280, 720));//just guessing here
                //if (!isBPMMeasuring)
                //{
                //    g.DrawImage(vf2.instaOver, new System.Drawing.Rectangle(0, 0, 640, 640));
                //}
                //else
                //{
                //    g.DrawImage(vf2.instaOverBPM, new System.Drawing.Rectangle(0, 0, 640, 640));
                //    RectangleF rectf = new RectangleF(415, 543, 140, 50);
                //    g.DrawString(MainForm.currentAvgBPM.ToString("0") + " BPM", new Font("Sofia Pro Bold", 18), Brushes.White, rectf);

                //}
            }
        }
        private void OK_btn_Click(object sender, EventArgs e)
        {
            if (currentCamType == CAMTYPE.PULSETRIGGERED)
            {
                if (currentPulseCamState == PULSECAMSTATE.WAITFOROK)
                {
                    currentPulseCamState = PULSECAMSTATE.PRINTING;
                }
            }
            if (currentCamType == CAMTYPE.SELFTIMER)
            {
                if (currentSelfCamState == SELFCAMSTATE.WAITFOROK)
                {
                    currentSelfCamState = SELFCAMSTATE.PRINTING;
                    createPrintImg();
                    printCapture.Save(lastSavedImageFileName, ImageFormat.Png);
                    //instaCapture.Save(instaFileNameWithPath, ImageFormat.Png);
                    printerhandler.printIt(lastSavedImageFileName, numcopiestoprint);
                    if (numcopiestoprint > 0)
                    {
                        printtimer.Interval = 10000;
                        printtimer.Start();
                        isBPMMeasuring = false;
                        vf2.showThanks();
                    }
                    else
                    {
                        printtimer.Interval = 4000;
                        printtimer.Start();
                        vf2.showThanks();
                        isBPMMeasuring = false;
                    }
                }
                else
                {
                    MessageBox.Show("err " + currentSelfCamState);
                }
            }


        }

       
        #endregion
        private void print0_rb_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void takeSnapShot()
        {
            //save it first..
            vf2.savePreview(Evf_Bmp);
            CameraHandler.TakePhoto();
            currentSelfCamState = SELFCAMSTATE.WAITFOROK;
            vf2.changeSelfCamState(currentSelfCamState);

            DateTime d = DateTime.Now;
            string todayDate = d.Year + "_" + d.Month.ToString("D2") + "_" + d.Day.ToString("D2");
            string todayPrintDirectory = printImageDirectory + @"\" + todayDate;
            string todayInstaDirectory = instaImageDirectory + @"\" + todayDate;
            try
            {
                if (!Directory.Exists(todayPrintDirectory))
                    Directory.CreateDirectory(todayPrintDirectory);
            }
            catch (Exception x)
            {
                string ertype = x.GetType().ToString();
                MessageBox.Show("create directory failed: " + ertype + "   " + todayPrintDirectory);
            }
            try
            {
                if (!Directory.Exists(todayInstaDirectory))
                    Directory.CreateDirectory(todayInstaDirectory);
            }
            catch (Exception x)
            {
                string ertype = x.GetType().ToString();
                MessageBox.Show("create directory failed: " + ertype + "   " + todayInstaDirectory);
            }

            string fname = d.ToString("HH") + "_" + d.Minute.ToString("D2") + "_" + d.Second.ToString("D2") + "_" + d.Millisecond.ToString() + ".png";
            lastSavedImageFileName = todayPrintDirectory + @"\" + fname;
            instaFileNameWithPath = todayInstaDirectory + @"\" + fname;

            audiohandler.playsound(audioHandler.SOUNDTYPE.SHUTTER);
            currentSelfCamState = SELFCAMSTATE.WAITFOROK;
            vf2.changeSelfCamState(currentSelfCamState);
        }

        private void takeSnapShotOld()
        {
            //TODO CHANGE THIS TO USE THE ACTUAL CAM IMAGE INSTEAD
           
            currentSelfCamState = SELFCAMSTATE.WAITFOROK;
            vf2.changeSelfCamState(currentSelfCamState);

            printCapture = new System.Drawing.Bitmap(768, 1366);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(printCapture))
            {
                g.Clear(System.Drawing.Color.Black); // Change this to whatever you want the background color to be, you may set this to Color.Transparent as well
                g.DrawImage(vf2.bild, new System.Drawing.Rectangle(-280, 147, 1280, 720));//fix this
                if (!isBPMMeasuring)
                {
                    g.DrawImage(vf2.printOverLay, new System.Drawing.Rectangle(0, 0, 768, 1366));
                }
                else
                {
                    g.DrawImage(vf2.printOverLayBPM, new System.Drawing.Rectangle(0, 0, 768, 1366));
                    RectangleF rectf = new RectangleF(490, 734, 140, 50);
                    g.DrawString(MainForm.currentAvgBPM.ToString("0") + " BPM", new Font("Sofia Pro Bold", 18), Brushes.White, rectf);
                }
            }

            instaCapture = new System.Drawing.Bitmap(640, 640);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(instaCapture))
            {
                g.Clear(System.Drawing.Color.Black); // Change this to whatever you want the background color to be, you may set this to Color.Transparent as well
                g.DrawImage(vf2.bild, new System.Drawing.Rectangle(-319, -44, 1280, 720));//just guessing here
                if (!isBPMMeasuring)
                {
                    g.DrawImage(vf2.instaOver, new System.Drawing.Rectangle(0, 0, 640, 640));
                }
                else
                {
                    g.DrawImage(vf2.instaOverBPM, new System.Drawing.Rectangle(0, 0, 640, 640));
                    RectangleF rectf = new RectangleF(415, 543, 140, 50);
                    g.DrawString(MainForm.currentAvgBPM.ToString("0") + " BPM", new Font("Sofia Pro Bold", 18), Brushes.White, rectf);

                }
            }

            DateTime d = DateTime.Now;
            string todayDate = d.Year + "_" + d.Month.ToString("D2") + "_" + d.Day.ToString("D2");
            string todayPrintDirectory = printImageDirectory + @"\" + todayDate;
            string todayInstaDirectory = instaImageDirectory + @"\" + todayDate;
            try
            {
                if (!Directory.Exists(todayPrintDirectory))
                    Directory.CreateDirectory(todayPrintDirectory);
            }
            catch (Exception x)
            {
                string ertype = x.GetType().ToString();
                MessageBox.Show("create directory failed: " + ertype + "   " + todayPrintDirectory);
            }
            try
            {
                if (!Directory.Exists(todayInstaDirectory))
                    Directory.CreateDirectory(todayInstaDirectory);
            }
            catch (Exception x)
            {
                string ertype = x.GetType().ToString();
                MessageBox.Show("create directory failed: " + ertype + "   " + todayInstaDirectory);
            }

            string fname = d.ToString("HH") + "_" + d.Minute.ToString("D2") + "_" + d.Second.ToString("D2") + "_" + d.Millisecond.ToString() + ".png";
            lastSavedImageFileName = todayPrintDirectory + @"\" + fname;
            instaFileNameWithPath = todayInstaDirectory + @"\" + fname;

            audiohandler.playsound(audioHandler.SOUNDTYPE.SHUTTER);
            currentSelfCamState = SELFCAMSTATE.WAITFOROK;
            vf2.changeSelfCamState(currentSelfCamState);
        }

        private void LiveViewPicBox_Click(object sender, EventArgs e)
        {

        }
        private void setsRect()
        {
            vf2.SX = (int)sx.Value;
            vf2.SY = (int)sy.Value;
            vf2.SW = (int)sw.Value;
            vf2.SH = (int)sh.Value;
        
        }
        private void sx_ValueChanged(object sender, EventArgs e)
        {
            setsRect();
        }
        private void sy_ValueChanged(object sender, EventArgs e)
        {
            setsRect();
        }
        private void sw_ValueChanged(object sender, EventArgs e)
        {
            setsRect();
        }
        private void sh_ValueChanged(object sender, EventArgs e)
        {
            setsRect();
        }


        private void setdRect()
        {
            vf2.DX = (int)dx.Value;
            vf2.DY = (int)dy.Value;
            vf2.DW = (int)dw.Value;
            vf2.DH = (int)dh.Value;
            
        }
        private void dx_ValueChanged(object sender, EventArgs e)
        {
            setdRect();
        }
        private void dy_ValueChanged(object sender, EventArgs e)
        {
            setdRect();
        }
        private void dw_ValueChanged(object sender, EventArgs e)
        {
            setdRect();
        }
        private void dh_ValueChanged(object sender, EventArgs e)
        {
            setdRect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(vf2!=null)
            vf2.Clear();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

     

   

     

        

        

        
    }
  
}
