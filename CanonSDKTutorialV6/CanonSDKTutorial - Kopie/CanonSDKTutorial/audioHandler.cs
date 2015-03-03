using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;

//using AForge.Video;
//using AForge.Video.DirectShow;

namespace CanonPulse
{
    class audioHandler
    {
        public enum SOUNDTYPE
        {
            SHUTTER,
            BUZZER,
            HEARTBEAT,
            BUTTON,
            ERROR,
            LESS5,
            LESS10,
            LESS20,
            LESS30,
            YES,
            CHECKBACK
        }

        public void playsound(int diff)
        {
            if (diff < 6)
            {
                playsound(SOUNDTYPE.LESS5);
                return;
            }
            if (diff < 11)
            {
                playsound(SOUNDTYPE.LESS10);
                return;
            }
            if (diff < 21)
            {
                playsound(SOUNDTYPE.LESS20);
                return;
            }
        }

        public void playsound(SOUNDTYPE st)
        {
            switch (st)
            {
                case SOUNDTYPE.ERROR:
                    System.Media.SoundPlayer eplayer = new System.Media.SoundPlayer(@"D:\PepsiPulse\SND\ERROR.wav");
                    eplayer.Play();
                    break;

                case SOUNDTYPE.HEARTBEAT:
                    System.Media.SoundPlayer hplayer = new System.Media.SoundPlayer(@"D:\PepsiPulse\SND\heartbeat1.wav");
                    hplayer.Play();
                    break;

                case SOUNDTYPE.BUZZER:
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\PepsiPulse\SND\buzzer2.wav");
                    player.Play();
                    break;

                case SOUNDTYPE.SHUTTER:
                    System.Media.SoundPlayer splayer = new System.Media.SoundPlayer(@"D:\PepsiPulse\SND\shutter_4.wav");
                    splayer.Play();
                    break;

                case SOUNDTYPE.BUTTON:
                    System.Media.SoundPlayer sbplayer = new System.Media.SoundPlayer(@"D:\PepsiPulse\SND\button.wav");
                    sbplayer.Play();
                    break;
            }

        }
    }
}
