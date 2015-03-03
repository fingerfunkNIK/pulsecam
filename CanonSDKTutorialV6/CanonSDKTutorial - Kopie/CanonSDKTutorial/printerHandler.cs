using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;

namespace CanonPulse
{
    class printerHandler
    {
        private string printImagePath;
        public delegate void PrintErrEventHandler(object sender, EventArgs e, string msg);
        public event PrintErrEventHandler printLogMsg;

        public void CheckPrinter()
        {

            if (PrinterSettings.InstalledPrinters.Count > 0)
            {
                PrinterSettings settings = new PrinterSettings();
                Console.WriteLine(settings.PrinterName);

                    if (printLogMsg != null)
                        printLogMsg(this, EventArgs.Empty, "DEFAULT PRINTER IS " + settings.PrinterName);  
    
              
                
            }
            else
            {
                if (printLogMsg != null)
                    printLogMsg(this, EventArgs.Empty, "ERROR NO PRINTER FOUND");  
            }
        }

        public void printIt(string docpath,int copies)
        {
            if (copies > 0)
            {
                try { 
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.Landscape = true;
                pd.PrintPage += (sender, args) =>
                {
                    Image i = Image.FromFile(docpath);
                    Rectangle m = args.PageBounds;
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
              
                    args.Graphics.Clear(Color.Black);
                    Rectangle mr = new Rectangle(m.Left, m.Top, m.Width, m.Height);//HARD CODE HACK!!!!
                    args.Graphics.DrawImage(i, mr);
                };
                    pd.PrinterSettings.Copies = (short)copies;
                    pd.Print();
                    }
                catch (Exception e)
                {
                    if (printLogMsg!=null)
                        printLogMsg(this, EventArgs.Empty, e.ToString());  
                   
                }
               
            }
        }
    
        void pqr(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image i = System.Drawing.Image.FromFile(printImagePath);
            Rectangle m = e.MarginBounds;
            if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
            {
                m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
            }
            else
            {
                m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
            }
            e.Graphics.DrawImage(i, m);
        }
    }
}
