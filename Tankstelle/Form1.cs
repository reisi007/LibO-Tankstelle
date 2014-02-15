using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tankstelle
{
    public partial class Form1 : Form
    {
        DriveInfo[] USBSticks = null;
        Program[] files;
        CopyJobProvider copyJob;
        PictureBox curLang;
        string[,] l10n;


        #region HelperClasses
        private class CopyJobProvider
        {
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("CopyJob provider contains of the following jobs:\n");
                int length = jobs.Count;
                for (int i = 0; i < length; i++)
                    sb.AppendLine((i + 1) + ") " + jobs[i]);
                return sb.ToString();
            }
            private List<CopyJob> jobs = new List<CopyJob>();
            private class CopyJob
            {
                public override string ToString()
                {
                    return "Copyjob for: " + filename + " [" + from + "||" + to + "]";
                }
                public CopyJob(Program p, string to)
                    : this(p.path, p.filename, to, p.Byte)
                {
                }
                public CopyJob(string from, string filename, string to, long size)
                {
                    this.from = from;
                    this.to = to;
                    this.size = size;
                    this.filename = filename;
                }

                public long getSize()
                {
                    return size;
                }
                private string from, to, filename;
                private long size;
                public bool Do(string drive)
                {
                    bool working = false;
                    try
                    {
                        Directory.CreateDirectory(Path.Combine(drive, to));
                        File.Copy(Path.Combine(from, filename), Path.Combine(drive, to, filename), false);
                        working = true;
                    }
                    catch (Exception)
                    { } return working;
                }
            }
            public void reset()
            {
                jobs.Clear();
            }
            public int getNumberOfJobs()
            {
                return jobs.Count;
            }
            public long getSize()
            {
                long size = 0;
                foreach (CopyJob c in jobs)
                    size += c.getSize();
                return size;
            }
            public void Add(string from, string filename, string to, long size)
            {
                jobs.Add(new CopyJob(from, filename, to, size));
            }
            public void Add(CopyJobProvider cjp)
            {
                if (cjp != null)
                    jobs.AddRange(cjp.jobs);
            }
            //"to" is a path
            public void Add(Program p, string to)
            {
                jobs.Add(new CopyJob(p, to));
            }
            public bool Do(DriveInfo drive)
            {
                bool result = true;
                foreach (CopyJob cj in jobs)
                {
                    result = result & cj.Do(drive.ToString());
                    if (pb.Value == pb.Maximum)
                        pb.Value = 1;
                    pb.Value++;
                }
                return result;
            }

            private ProgressBar pb;
            public CopyJobProvider(ref ProgressBar pb)
            {
                this.pb = pb;
            }
        }
        private class Program
        {
            public override string ToString()
            {
                return path + " (" + (Byte / (1024 * 1024)) + " MB)";
            }
            public string path, filename;
            public long Byte;
            public Program(string s)
            {
                try
                {
                    FileInfo fi = new System.IO.FileInfo(s);
                    path = fi.Directory.FullName;
                    Byte = fi.Length;
                    filename = fi.Name;
                }
                catch (Exception)
                {
                    MessageBox.Show("\"" + s + "\" is not a valid file");
                    Environment.Exit(-1);
                }
            }
        }
        #endregion


        enum Programs
        {
            WINMAIN = 0, WINHELPDE, WINHELPEN, //3
            RPMMAIN32, RPMHELPDE32, RPMHELPEN32, RPMLANGDE32, RPMMAIN64, RPMHELPDE64, RPMHELPEN64, RPMLANGDE64, //8
            DEBMAIN32, DEBHELPDE32, DEBLANGDE32, DEBHELPEN32, DEBMAIN64, DEBHELPDE64, DEBLANGDE64, DEBHELPEN64, // 8
            MACMAIN32, MACMAIN64, MACHELPDE32, MACHELPEN32, MACHELPDE64, MACHELPEN64 //6
        }
        private int getProgramsIndex(Programs ps)
        {
            return (int)ps;
        }
        const int nol_files = 25;
        Button[] os, which, startstop;
        private void doResize()
        {
            splitForm_Resize(splitForm, new EventArgs());
            split2(splitContainer2, new EventArgs());
            splitContainerResize(splitContainer1, new EventArgs());
            resizePanel(flowLayoutPanel1, new EventArgs());
            resizePanel(flowLayoutPanel2, new EventArgs());
            adaptflagsSize(floatingPictures, new EventArgs());
        }
        public Form1()
        {
            InitializeComponent();
            pictureCopyFinished.BringToFront();
            curLang = picFlagDE;
            updateCopySize();
            loadBitmap();
            /*
             * Initial flowlayot resize
             */
            doResize();
            os = new Button[] { b_windows, b_macos_x86, b_macos_x86_64, b_linux_deb_x86, b_linux_deb_x86_64, b_linux_rpm_x86, b_linux_rpm_x86_64 };
            which = new Button[] { b_help, b_main };
            startstop = new Button[] { b_start, b_reset };
            getFilesData();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nol_files; i++)
                sb.AppendLine(((Programs)i).ToString() + '@' + files[i].ToString());
            MessageBox.Show(sb.ToString(), "Files loaded");
        }
        Image pictureFlagDE, pictureFlagEN, pictureLogoDE, pictureLogoEN, pictureSucceedDE, pictureSucceedEN;
        private void loadBitmap()
        {
            try
            {
                pictureFlagDE = Bitmap.FromFile(Path.Combine("pictures", "flags", "DE.png"), true);
                pictureFlagEN = Bitmap.FromFile(Path.Combine("pictures", "flags", "EN.png"), true);
                pictureLogoDE = Bitmap.FromFile(Path.Combine("pictures", "logos", "DE.png"), true);
                pictureLogoEN = Bitmap.FromFile(Path.Combine("pictures", "logos", "EN.png"), true);
                pictureSucceedDE = Bitmap.FromFile(Path.Combine("pictures", "finished", "DE.png"), true);
                pictureSucceedEN = Bitmap.FromFile(Path.Combine("pictures", "finished", "EN.png"), true);
                picFlagDE.Image = pictureFlagDE;
                picFlagEN.Image = pictureFlagEN;

            }
            catch (Exception e)
            {
                MessageBox.Show("Picture missing. Original error message:\n" + e.Message);
                Environment.Exit(-10);
            }


        }
        private void getFilesData()
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "settings"));
            }
            catch (Exception e)
            {
                MessageBox.Show("Settings could not be created... Original error message:\n" + e.Message);
            }
            #region l10n
            string url = Path.Combine("settings", "l10n.txt");
            string[] tmp = null;
            try
            {
                tmp = File.ReadAllLines(url);
            }
            catch (Exception e)
            {
                MessageBox.Show("No l10n.txt found. Original error message:\n" + e.Message);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Description#Language LEFT#Language RIGHT");
                sb.AppendLine("0Program#Programm#Program");
                sb.AppendLine("1Langcode#DE#EN");
                sb.AppendLine("2Title#LibreOffice USB Tankstelle#LibreOffice USB gas station");
                sb.AppendLine("3Select#Auswählen#Select");
                sb.AppendLine("4OS#Betriebssystem#Operating System");
                sb.AppendLine("5Main#Hauptprogramm#Main program");
                sb.AppendLine("6Help#Offline Hilfedateien#Offline help");
                sb.AppendLine("7Start#Tanken beginnen#Start filling");
                sb.AppendLine("8Reset#Zurücksetzen#Reset");
                sb.AppendLine("9Choose#Auswählen#Choose");
                try
                {
                    File.WriteAllText(url, sb.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Environment.Exit(-5);
            }

            l10n = new string[2, tmp.Length - 1];
            StringBuilder stringb = new StringBuilder("l10n");
            for (int i = 1; i < tmp.Length; i++)
            {
                string[] values = tmp[i].Split(new char[] { '#' });
                if (values.Length != 3)
                {
                    MessageBox.Show("Invalid length of line " + (i + 1));
                    Environment.Exit(-4);
                }
                l10n[0, (i - 1)] = values[1];
                l10n[1, (i - 1)] = values[2];
                stringb.AppendLine(values[0] + "\t-\t" + values[1] + "\t-\t" + values[2]);
            }
            MessageBox.Show(stringb.ToString());
            #endregion
            #region Load files (LibreOffice installers)
            url = Path.Combine("settings", "files.txt");
            try
            {
                tmp = File.ReadAllLines(url);
            }
            catch (Exception e)
            {
                MessageBox.Show("No files.txt found. Original error message:\n" + e.Message);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < nol_files; i++)
                {
                    sb.AppendLine("#" + ((Programs)i).ToString());
                }
                try
                {
                    File.WriteAllText(url, sb.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Environment.Exit(-2);
            }
            if (tmp == null || tmp.Length != nol_files)
            {
                if (tmp != null)
                    MessageBox.Show("Number of lines is " + tmp.Length + ".Should:" + nol_files);
                Environment.Exit(-3);
            }
            // Everything as it should, create Program[]
            files = new Program[nol_files];
            for (int i = 0; i < nol_files; i++)
            {
                string[] a = tmp[i].Split(new char[] { '#' });
                if (a.Length > 2)
                {
                    MessageBox.Show("Error at line " + i + " (" + ((Programs)i).ToString() + ")");
                    Environment.Exit(-4);
                }
                files[i] = new Program(a[0]);
            }
            #endregion
        }
        private long progressbar100 = long.MaxValue;
        private readonly Color red = Color.Red, green = Color.FromArgb(24, 163, 3), white = Color.White, black = Color.Black, light = Color.FromArgb(205, 201, 201), dark = Color.FromArgb(139, 137, 137);
        private readonly string SUBDIRWIN = Path.Combine("LibreOffice", "Windows"), SUBDIRLIN = Path.Combine("LibreOffice", "Linux"), SUBDIRMAC = Path.Combine("LibreOffice", "MacOS");

        private void getMinFreeSpace()
        {
            long pbmax = long.MaxValue;
            pb_byte.Value = 0;
            List<DriveInfo> di = DriveInfo.GetDrives().ToList<DriveInfo>();
            int i;
            for (i = 0; i < di.Count; i++)
            {
                if (di[i].DriveType != DriveType.Removable)
                {
                    di.Remove(di[i]);
                    i--;
                }
                else
                {
                    try
                    {
                        if (pbmax > di[i].TotalFreeSpace)
                            pbmax = di[i].TotalFreeSpace;
                    }

                    catch (Exception e)
                    {
                        if (e is UnauthorizedAccessException || e is System.IO.DirectoryNotFoundException || e is System.IO.IOException)
                        {
                            di.Remove(di[i]);
                            i--;
                        }
                        else
                            MessageBox.Show(e.Message);
                    }
                }
            }
            USBSticks = di.ToArray();
            // Progressbar's value in MB
            progressbar100 = pbmax;
            setTitle(isNative(), pbmax == long.MaxValue ? "No stick inserted" : Convert.ToString(Math.Round((pbmax / (Math.Pow(1024, 3))), 3)) + " GB - " + i + "sticks");

        }
        private void updateCopySize()
        {
            if (copyJob == null)
            {
                copyJob = new CopyJobProvider(ref pb_number);
            }
            else
                copyJob.reset();
            #region Main program
            // Gets the total size of all copyjobs and fill copyJob with the jobs
            if (isButtonPressed(b_main))
            {
                //Check for main installer
                //Windows
                if (isButtonPressed(b_windows))
                {
                    copyJob.Add(files[getProgramsIndex(Programs.WINMAIN)], SUBDIRWIN);
                }
                // Linux DEB x86
                if (isButtonPressed(b_linux_deb_x86))
                {
                    copyJob.Add(files[getProgramsIndex(Programs.DEBMAIN32)], SUBDIRLIN);
                }
                // Linux DEB x86_64
                if (isButtonPressed(b_linux_deb_x86_64))
                {
                    copyJob.Add(files[getProgramsIndex(Programs.DEBMAIN64)], SUBDIRLIN);
                }
                // Linux RPM x86
                if (isButtonPressed(b_linux_rpm_x86))
                {
                    copyJob.Add(files[getProgramsIndex(Programs.RPMMAIN32)], SUBDIRLIN);
                }
                // Linux RPM x86_64
                if (isButtonPressed(b_linux_rpm_x86_64))
                {
                    copyJob.Add(files[getProgramsIndex(Programs.RPMMAIN64)], SUBDIRLIN);
                }
                // MacOS x86
                if (isButtonPressed(b_macos_x86))
                {
                    copyJob.Add(files[getProgramsIndex(Programs.MACMAIN32)], SUBDIRMAC);
                }
                // MacOS x86_64
                if (isButtonPressed(b_macos_x86_64))
                {
                    copyJob.Add(files[getProgramsIndex(Programs.MACMAIN64)], SUBDIRMAC);
                }
            }
            #endregion
            #region Helppack (and) Langpack (if not included in Main or helppack)
            // Help and OR langpack
            if (isButtonPressed(b_help))
            {
                //Check for help and langpack
                //Windows
                if (isButtonPressed(b_windows))
                {
                    if (isNative())
                        copyJob.Add(files[getProgramsIndex(Programs.WINHELPDE)], SUBDIRWIN);
                    else
                        copyJob.Add(files[getProgramsIndex(Programs.WINHELPEN)], SUBDIRWIN);
                }
                // Linux DEB x86
                if (isButtonPressed(b_linux_deb_x86))
                {
                    //Also include translation of the UI
                    if (isNative())
                    {
                        copyJob.Add(files[getProgramsIndex(Programs.DEBLANGDE32)], SUBDIRLIN);
                        copyJob.Add(files[getProgramsIndex(Programs.DEBHELPDE32)], SUBDIRLIN);
                    }
                    else
                        copyJob.Add(files[getProgramsIndex(Programs.DEBHELPEN32)], SUBDIRLIN);
                }
                // Linux DEB x86_64
                if (isButtonPressed(b_linux_deb_x86_64))
                {
                    //Also include translation of the UI
                    if (isNative())
                    {
                        copyJob.Add(files[getProgramsIndex(Programs.DEBLANGDE64)], SUBDIRLIN);
                        copyJob.Add(files[getProgramsIndex(Programs.DEBHELPDE64)], SUBDIRLIN);
                    }
                    else
                        copyJob.Add(files[getProgramsIndex(Programs.DEBHELPEN64)], SUBDIRLIN);
                }
                // Linux RPM x86
                if (isButtonPressed(b_linux_rpm_x86))
                {
                    //Also include translation of the UI
                    if (isNative())
                    {
                        copyJob.Add(files[getProgramsIndex(Programs.RPMLANGDE32)], SUBDIRLIN);
                        copyJob.Add(files[getProgramsIndex(Programs.RPMHELPDE32)], SUBDIRLIN);
                    }
                    else
                        copyJob.Add(files[getProgramsIndex(Programs.RPMHELPEN32)], SUBDIRLIN);
                }
                // Linux RPM x86_64
                if (isButtonPressed(b_linux_rpm_x86_64))
                {
                    //Also include translation of the UI
                    if (isNative())
                    {
                        copyJob.Add(files[getProgramsIndex(Programs.RPMHELPDE64)], SUBDIRLIN);
                        copyJob.Add(files[getProgramsIndex(Programs.RPMLANGDE64)], SUBDIRLIN);
                    }
                    else
                        copyJob.Add(files[getProgramsIndex(Programs.RPMHELPEN64)], SUBDIRLIN);
                }
                // MacOS x86
                if (isButtonPressed(b_macos_x86))
                {
                    if (isNative())
                        copyJob.Add(files[getProgramsIndex(Programs.MACHELPDE32)], SUBDIRMAC);
                    else
                        copyJob.Add(files[getProgramsIndex(Programs.MACHELPEN32)], SUBDIRMAC);
                }
                // MacOS x86_64
                if (isButtonPressed(b_macos_x86_64))
                {
                    if (isNative())
                        copyJob.Add(files[getProgramsIndex(Programs.MACHELPDE64)], SUBDIRMAC);
                    else
                        copyJob.Add(files[getProgramsIndex(Programs.MACHELPEN64)], SUBDIRMAC);
                }
            }
            #endregion
            if (updateProgressbar(copyJob.getSize()))
            {
                b_start.BackColor = light;
                b_start.ForeColor = black;
            }
            else
            {
                b_start.BackColor = red;
                b_start.ForeColor = white;
            }
        }
        private bool updateProgressbar(long value)
        {
            if (value > progressbar100)
            {
                pb_byte.Value = pb_byte.Maximum;
                return false;
            }
            else
            {
                pb_byte.Value = (int)(Math.Round(value / (double)progressbar100, 2) * 10000);
                return true;
            }
        }
        private bool isButtonPressed(Button b)
        {
            return b.BackColor == dark ? true : false;
        }
        //Returns true, if lang is de [Native language]
        private bool isNative()
        {
            return curLang == picFlagDE;
        }
        private void setTitle(int index, string n)
        {
            output.Text = l10n[index, 2] + ((n != null && n.Length > 0) ? " " + n : "");
        }
        private void setTitle(bool left, string n)
        {
            setTitle(left ? 0 : 1, n);
        }
        private void setl10n()
        {
            setl10n(isNative());
        }
        private void setl10n(bool left)
        {
            int index = left ? 0 : 1;
            setTitle(index, "");
            lProg.Text = l10n[index, 0];
            gb_choose.Text = l10n[index, 3];
            lOS.Text = l10n[index, 4];
            b_main.Text = l10n[index, 5];
            b_help.Text = l10n[index, 6];
            b_start.Text = l10n[index, 7];
            b_reset.Text = l10n[index, 8];
            gb_choose.Text = l10n[index, 9];
            if (left)
            {
                picBigLogo.Image = pictureLogoDE;
                pictureCopyFinished.Image = pictureSucceedDE;
            }
            else
            {
                picBigLogo.Image = pictureLogoEN;
                pictureCopyFinished.Image = pictureSucceedEN;
            }
            updateCopySize();
            setSize(ref os);
            setSize(ref which);
            setSize(ref startstop);
        }
        private void changeColor(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == light)
                ((Button)sender).BackColor = dark;
            else
                ((Button)sender).BackColor = light;
            getMinFreeSpace();
            updateCopySize();

        }
        private void reset()
        {
            foreach (Button b in os)
                b.BackColor = light;
            b_help.BackColor = light;
            b_main.BackColor = light;
            pb_byte.Visible = true;
            pb_number.Visible = false;
            pb_number.Value = 0;
            updateCopySize();
        }
        private void b_reset_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void resizePanel(object sender, EventArgs e)
        {
            FlowLayoutPanel p = (FlowLayoutPanel)sender;
            System.Windows.Forms.Control.ControlCollection controls = p.Controls;
            int width = p.Size.Width / controls.Count - 6, height = p.Size.Height - 4;
            for (int i = 0; i < controls.Count; i++)
            {
                Control c = controls[i];
                c.Width = width;
                c.Height = height;
            }
        }
        private void setSize(ref Button[] b)
        {
            List<Control> lc = new List<Control>();
            foreach (Button a in b)
                lc.Add(a);
            Control[] c = lc.ToArray();
            setSize(ref c);
        }
        private void setSize(ref Control[] c)
        {
            if (c == null)
                return;
            float minsize = float.MaxValue, temp;
            for (int i = 0; i < c.Length; i++)
            {
                temp = fitSize(c[i]);
                if (temp < minsize)
                    minsize = temp;
            }
            for (int i = 0; i < c.Length; i++)
            {
                c[i].Font = getFont(minsize);
            }
        }

        private float fitSize(Control c)
        {
            float fontSize = 50f;
            do
            {
                c.Font = getFont(fontSize -= 0.5f);

            } while (!MeasureString(c));
            return fontSize;
        }

        //Returns true, if the text fits the control
        private bool MeasureString(Control c)
        {
            Size s = TextRenderer.MeasureText(c.Text, c.Font);
            return ((s.Width <= (0.9 * c.Width)) && (s.Height <= (0.9 * c.Height)));

        }
        private Font getFont(float size)
        {
            return new Font("Microsoft Sans Serif", size, FontStyle.Regular);
        }
        private void adaptflagsSize(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.ControlCollection controls = floatingPictures.Controls;
            int qW = floatingPictures.Size.Width / 10 - 6;
            int fH = floatingPictures.Size.Height - 4;
            for (int i = 0; i < controls.Count; i++)
            {
                Control c = controls[i];
                c.Height = fH;
                switch (i)
                {
                    case (0):
                    case (2):
                        c.Width = qW;
                        break;
                    default:
                        c.Width = 8 * qW + (6 * 7);
                        break;
                }
            }
        }
        private void b_start_Click(object sender, EventArgs e)
        {
            updateCopySize();
            getMinFreeSpace();
            // Do copy, if sender is red
            if (((Button)sender).BackColor == red || output.Text.Contains("No stick") || USBSticks == null)
                return;
            pb_byte.Visible = false;
            pb_number.Visible = true;
            pb_number.Maximum = 1 + (USBSticks.Length * copyJob.getNumberOfJobs());
            pb_number.PerformStep();
            foreach (DriveInfo fi in USBSticks)
                copyJob.Do(fi);
            pictureCopyFinished.Visible = true;
        }
        private void changeL10n(object sender, EventArgs e)
        {
            curLang = (PictureBox)sender;
            setl10n();
        }

        private void keypressedExit(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                    // Close
                case (Keys.Escape):
                    Environment.Exit(0);
                    break;
                    // See picture sizes
                case (Keys.F1):
                    StringBuilder sb = new StringBuilder("© Reisisoft 2013-" + DateTime.Now.Year);
                    sb.AppendLine("\nPicture sizes:");
                    sb.Append("-\tFlags: ");
                    sb.AppendLine(pictureBoxToString(picFlagDE));
                    sb.Append("-\tBig logo between flags: ");
                    sb.AppendLine(pictureBoxToString(picBigLogo));
                    sb.Append("-\tFinished copying: ");
                    sb.AppendLine(pictureBoxToString(pictureCopyFinished));
                    MessageBox.Show(sb.ToString());
                    break;
                    // Show / Hide admin info
                case (Keys.A):
                    output.Visible = !output.Visible;
                    break;
            }
        }
        private string pictureBoxToString(PictureBox pb)
        {
            return "(" + pb.Width + "x" + pb.Height + ")";
        }

        private void splitContainerResize(object sender, EventArgs e)
        {
            SplitContainer sc = (SplitContainer)sender;
            sc.Panel1MinSize = (int)((3f / 5) * sc.Size.Height);
        }

        private void pictureCopyFinished_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Visible = false;
            reset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setl10n();
        }

        private void splitForm_Resize(object sender, EventArgs e)
        {
            SplitContainer sc = (SplitContainer)sender;
            int size35 = (int)(0.5f + sc.Size.Height * 0.35) - 2;
            sc.Panel1MinSize = size35;
            sc.Panel2MinSize = (sc.Size.Height - size35);
        }

        private void split2(object sender, EventArgs e)
        {
            SplitContainer sc = (SplitContainer)sender;
            int size74 = (int)(0.5f + sc.Size.Height * 0.74) - 2;
            sc.Panel1MinSize = size74;
            sc.Panel2MinSize = (sc.Size.Height - size74);
        }
    }
}
