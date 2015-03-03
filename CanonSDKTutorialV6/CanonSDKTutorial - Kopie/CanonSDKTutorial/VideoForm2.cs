using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
//using AForge.Video;
//using AForge.Video.DirectShow;

namespace CanonPulse
{
    public partial class VideoForm2 : Form
    {
        public Image pulseCamOverLay;
        private Image pulseCamOverLayBPM;
        public Image pulsecamOKorCancel;//{ get; private set; }
        public Image pulsecamOKorCancelBPM;//{ get; private set; }
        private Image thankyouImage;
        private Image cancelledImage;
        public Image printOverLay { get; private set; }
        public Image printOverLayBPM { get; private set; }
        public Image instaOver { get; private set; }
        public Image instaOverBPM { get; private set; }
        private bool stopLiveVideo;
        private int LVBw, LVBh, w, h;
        float LVBratio, LVration;
        public Bitmap bild;
        private System.Drawing.Rectangle sRect;
        private System.Drawing.Rectangle dRect;
        public int SX;
        public int SY;
        public int SW;
        public int SH;

        public int DX;
        public int DY;
        public int DW;
        public int DH;


        public VideoForm2()
        {
            InitializeComponent();
            LVBw = backgroundPB.Width;
            LVBh = backgroundPB.Height;
        }


        public void savePreview(Bitmap i)
        {
            bild = i;
        }

        public void changeSelfCamState(MainForm.SELFCAMSTATE scs)
        {
            if (scs == MainForm.SELFCAMSTATE.WAITFOROK)
            {
                stopLiveVideo = true;
                showOkCancel();
                return;
            }
            if (scs == MainForm.SELFCAMSTATE.PRINTING)
            {
                stopLiveVideo = true;
                return;
            }
            else
            {
                Clear();
                stopLiveVideo = false;
            }
        }

        public void showCancel()
        {
            {
                System.Drawing.Bitmap finalImage = new System.Drawing.Bitmap(1366, 768);
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    g.Clear(System.Drawing.Color.Black); // Change this to whatever you want the background color to be, you may set this to Color.Transparent as well
                    g.DrawImage(cancelledImage, new System.Drawing.Rectangle(0, 0, 1366, 768));
                }
                backgroundPB.Image = finalImage;
            }
        }

        public void showThanks()
        {
            System.Drawing.Bitmap finalImage = new System.Drawing.Bitmap(1366, 768);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
            {
                g.Clear(System.Drawing.Color.Black); // Change this to whatever you want the background color to be, you may set this to Color.Transparent as well
                g.DrawImage(thankyouImage, new System.Drawing.Rectangle(0, 0, 1366, 768));
            }
            backgroundPB.Image = finalImage;
        }

        private void showOkCancel()
        {
            System.Drawing.Bitmap finalImage = new System.Drawing.Bitmap(1366, 768);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
            {
                //g.Clear(System.Drawing.Color.Black); // Change this to whatever you want the background color to be, you may set this to Color.Transparent as well
                try {
                g.DrawImage(bild, new System.Drawing.Rectangle(43, 24, 1280, 720));
                if (!MainForm.isBPMMeasuring)
                    g.DrawImage(pulsecamOKorCancel, new System.Drawing.Rectangle(0, 0, 1366, 768));
                else
                {
                    g.DrawImage(pulsecamOKorCancelBPM, new System.Drawing.Rectangle(0, 0, 1366, 768));
                    RectangleF rectf = new RectangleF(776, 604, 140, 50);
                    g.DrawString(MainForm.currentAvgBPM.ToString("0") + " BPM", new Font("Sofia Pro Bold", 18), Brushes.White, rectf);
                }
                     }
                catch
                {

                }
            }
            backgroundPB.Image = finalImage;
        }

        public void Clear()
        {
            using (Graphics g = backgroundPB.CreateGraphics())
            {
                  g.Clear(Color.Black);
            }
        }

        public void setBackGroundImage(Bitmap b)
        {
            if (!stopLiveVideo)
            {

                using (Graphics g = backgroundPB.CreateGraphics())
             
                {
                     g.DrawImage(b, new System.Drawing.Rectangle(373, 59, 640, 640), new System.Drawing.Rectangle(176, 0, 704, 704), GraphicsUnit.Pixel);
                }


    
            }
        }

        private void VideoForm_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            showOnMonitor(1);
            loadImages();
        }

        private void loadImages()
        {
            try
            {
                //ok
                pulseCamOverLay = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\screen1_2.png");
                pulseCamOverLayBPM = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\screen1_2BPM.png");

                //ok
                pulsecamOKorCancel = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\okcancel4.png");
                pulsecamOKorCancelBPM = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\okcancel_BPM4.png");
                
                //bpm
                //printOverLay = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\printoverlay_nobpm4.png");
                printOverLay = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\pepsi_print2.png");
                printOverLayBPM = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\printoverlay4.png");

                //printoverlayBPM
                instaOver = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\instaover4.png");
                instaOverBPM = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\instaoverBPM4.png");

                //instaoverBPM
                thankyouImage = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\thanksForImage.png");
                cancelledImage = (Bitmap)Image.FromFile(@"D:\PepsiPulse\PNG\cancelled.png");
            }
            catch
            {
                MessageBox.Show("no image found ");
            }
        }

        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;

        }
    
    }
}
