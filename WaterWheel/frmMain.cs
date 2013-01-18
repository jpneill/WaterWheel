using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using Wolfram.NETLink;

namespace WaterWheel
{
    public partial class frmMain : Form
    {
        parameterData paras = new parameterData();
        private int i, j;
        private Matrix m, minv;
        List<Bucket> bucketlist = new List<Bucket>();
        private double theta = 0;
        double[,] datalist;
        private int numrows;
        private int numcolumns;
        private bool firstIndicator = false; // just to indicate whether the function needs to be
        // called in mathematica again when start is pressed
        private int count = 0;
        float s1, s2, t1, t2;
        //private string path;

        private Timer t = new Timer();

        IKernelLink ml = null;

        private List<Coordinate> anglelist = null;
        private BindingSource bs = null;        

        public frmMain()
        {
            InitializeComponent();

            t.Interval = 50;
            t.Tick += frmMain_Tick;

            anglelist = new List<Coordinate>();// used for graph view

            //databinding
            bs = new BindingSource();
            bs.ListChanged += BindingSource_ListChanged;
            bs.DataSource = anglelist;
            bs.AllowNew = true;
        }

        private void SetupTransform()
        {
            float x1, y1, x2, y2;
            float x1d, y1d, x2d, y2d;
            //set up the world points
            x1 = -10; y1 = -10; x2 = 10; y2 = 10;
            //set up the corresponding device points
            //Rectangle crect = this.ClientRectangle;
            float width = this.ClientRectangle.Width;
            float height = this.ClientRectangle.Height;
            x1d = 0.1f * width;
            x2d = 0.9f * height;
            y1d = 0.1f * width;
            y2d = 0.9f * height;
            m = new Matrix();
            //calculate scales and translations
            s1 = (x1d - x2d) / (x1 - x2);
            s2 = (y1d - y2d) / (y1 - y2);
            t1 = (x1 * x2d - x2 * x1d) / (x1 - x2);
            t2 = (y1 * y2d - y2 * y1d) / (y1 - y2);
            //apply
            m.Translate(t1, t2);
            m.Scale(s1, s2);
            //get the inverse
            m.Invert();
            minv = m.Clone();
            m.Invert();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            SetupTransform();

            //receive user input
            // some initial values
            paras.R = 7;
            paras.QInflow = 10;
            paras.Qc = 10;
            paras.Sigma = 10;
            paras.Rho = 28;
            paras.Numb = 8;
            paras.Tlength = 5;
            paras.K = 1;
            paras.Omega = 0.1f;

            frmParameterDialog pd = new frmParameterDialog();
            pd.Text = "Enter the parameter values for the system";
            // just some default values
            pd.Data.R_ = paras.R;
            pd.Data.QInflow_ = paras.QInflow;
            pd.Data.Qc_ = paras.Qc;
            pd.Data.K_ = paras.K;
            pd.Data.Sigma_ = paras.Sigma;
            pd.Data.Rho_ = paras.Rho;
            pd.Data.Numb_ = paras.Numb;
            pd.Data.Tlength_ = paras.Tlength;
            pd.Data.Omega_ = paras.Omega;

            DialogResult d = pd.ShowDialog();
            if (d == DialogResult.OK)
            {
                paras.R = pd.Data.R_;
                paras.QInflow = pd.Data.QInflow_;
                paras.Qc = pd.Data.Qc_;
                paras.K = pd.Data.K_;
                paras.Sigma = pd.Data.Sigma_;
                paras.Rho = pd.Data.Rho_;
                paras.Numb = pd.Data.Numb_;
                paras.Tlength = pd.Data.Tlength_;
                paras.Omega = pd.Data.Omega_;
            }



            // set the initial positions of the buckets

            for (i = 0; i < paras.Numb; i++)
            {
                bucketlist.Add(new Bucket());
            }


            for (j = 0; j < bucketlist.Count; j++)
            {
                bucketlist[j].Width = 3.5f * (float)Math.Pow(0.9, paras.Numb - 8); // when there are 8 buckets, looks best if bucket width and height is 3.5
                bucketlist[j].Height = 3.5f * (float)Math.Pow(0.9, paras.Numb - 8); // adjust depending on number of buckets according to this formula: width = 3.5*(0.9)^(n-8)
                bucketlist[j].X = (float)(paras.R * Math.Sin(-theta - j * 2 * Math.PI / bucketlist.Count));
                bucketlist[j].Y = (float)(-paras.R * Math.Cos(-theta - j * 2 * Math.PI / bucketlist.Count));
            }

            frmWorking fw1 = new frmWorking();
            fw1.Show();
            fw1.Refresh();
            //System.Threading.Thread.Sleep(100);
            ml = MathLinkFactory.CreateKernelLink();
            ml.WaitAndDiscardAnswer();            
            //load the prepared package
            ml.Evaluate(@"<<C:\ChaosWheel\ChaosWheel2.m");            
            //dont need the result
            ml.WaitAndDiscardAnswer();
            //call method for new theta
            string input = string.Format("ChaosWheel2[{0},{1},{2},{3},{4},{5},{6},{7},{8}]", paras.R, paras.Sigma, paras.Rho, paras.K, paras.QInflow, paras.Qc, paras.Numb, paras.Tlength, paras.Omega);
            ml.Evaluate(input); // went for 45 seconds on time interval of 10
            ml.WaitForAnswer();
            //move the system according to theta
            //thetalist = (double[])ml.GetArray(typeof(double),1);
            datalist = (double[,])ml.GetArray(typeof(double), 2);
            numrows = datalist.GetLength(0);
            numcolumns = datalist.GetLength(1);
            firstIndicator = true;
            fw1.Close();
        }


        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Transform = m;

            for (i = 0; i < bucketlist.Count; i++)
            {                
                bucketlist[i].Draw(g, s1 / 500);
            }

        }



        private void frmMain_Tick(object sender, EventArgs e)
        {
            if (count < numrows)
            {
                // move each bucket in the list according to new theta values
                for (j = 0; j < numcolumns - 1; j++)
                {
                    bucketlist[j].X = (float)(paras.R * Math.Sin(-datalist[count, 0] - j * 2 * Math.PI / bucketlist.Count));
                    bucketlist[j].Y = (float)(-paras.R * Math.Cos(-datalist[count, 0] - j * 2 * Math.PI / bucketlist.Count));
                    
                    if (paras.QInflow <= 10) bucketlist[j].Water = (float)(datalist[count, j + 1]) / 4;
                    else if ((paras.QInflow > 10) && (paras.QInflow <= 25)) bucketlist[j].Water = (float)(datalist[count, j + 1]) / 10;
                    else bucketlist[j].Water = (float)(datalist[count, j + 1]) / 20;
                }

                anglelist.Add(new Coordinate((float)datalist[count, numcolumns - 2], (float)datalist[count, numcolumns - 1]));
                bs.ResetBindings(true);
            }
            count++;


            this.Refresh();
        }




        private void addBucketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firstIndicator = false;
            t.Stop();

            if (bucketlist.Count < 40)
            {
                bucketlist.Add(new Bucket());
                
                bucketlist[bucketlist.Count - 1].Width = bucketlist[bucketlist.Count - 2].Width;
                bucketlist[bucketlist.Count - 1].Height = bucketlist[bucketlist.Count - 2].Height;
                for (j = 0; j < bucketlist.Count; j++)
                {
                    bucketlist[j].X = (float)(paras.R * Math.Sin(theta + j * 2 * Math.PI / bucketlist.Count));
                    bucketlist[j].Y = (float)(-paras.R * Math.Cos(theta + j * 2 * Math.PI / bucketlist.Count));
                }
                //just for aesthetics, adjusting size of buckets so they look well on screen
                if (bucketlist.Count < 18)
                { //decrease length and width of each bucket by 10%
                    for (j = 0; j < bucketlist.Count; j++)
                    {
                        bucketlist[j].Width -= 0.1f * bucketlist[j].Width;
                        bucketlist[j].Height -= 0.1f * bucketlist[j].Height;
                    }
                }
                else
                { // if number of buckets is >18 decrease their size by just 5%
                    for (j = 0; j < bucketlist.Count; j++)
                    {
                        bucketlist[j].Width -= 0.05f * bucketlist[j].Width;
                        bucketlist[j].Height -= 0.05f * bucketlist[j].Height;
                    }
                }
            }
            //reset the parameter for number of buckets to be fed into mathematica function ChaosWheel
            paras.Numb = bucketlist.Count;
            count = 0;
            this.Refresh();
        }

        private void removeBucketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firstIndicator = false;
            t.Stop();
            // five is the min number of buckets
            if (bucketlist.Count > 5)
            {
                bucketlist.RemoveAt(bucketlist.Count - 1);

                for (j = 0; j < bucketlist.Count; j++)
                {
                    bucketlist[j].X = (float)(paras.R * Math.Sin(theta + j * 2 * Math.PI / bucketlist.Count));
                    bucketlist[j].Y = (float)(-paras.R * Math.Cos(theta + j * 2 * Math.PI / bucketlist.Count));
                }
                //just for aesthetics, adjusting size of buckets so they fit on screen
                if (bucketlist.Count < 18)
                {
                    for (j = 0; j < bucketlist.Count; j++)
                    {
                        bucketlist[j].Width += 0.111111f * bucketlist[j].Width;
                        bucketlist[j].Height += 0.111111f * bucketlist[j].Height;
                    }
                }
                else
                {
                    for (j = 0; j < bucketlist.Count; j++)
                    {
                        bucketlist[j].Width += 0.05263158f * bucketlist[j].Width;
                        bucketlist[j].Height += 0.05263158f * bucketlist[j].Height;
                    }
                }
            }
            //reset the parameter for number of buckets
            paras.Numb = bucketlist.Count;
            count = 0;
            this.Refresh();
        }



        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (count != 0 || firstIndicator == true) t.Start();
            else
            {
                frmWorking fw2 = new frmWorking();
                fw2.Show();
                fw2.Refresh();
                ml = MathLinkFactory.CreateKernelLink();
                ml.WaitAndDiscardAnswer();                
                //load the prepared package
                ml.Evaluate(@"<<C:\ChaosWheel\ChaosWheel2.m");
                //ml.Evaluate(path);                
                ml.WaitAndDiscardAnswer();
                string input = string.Format("ChaosWheel2[{0},{1},{2},{3},{4},{5},{6},{7},{8}]", paras.R, paras.Sigma, paras.Rho, paras.K, paras.QInflow, paras.Qc, paras.Numb, paras.Tlength, paras.Omega);
                ml.Evaluate(input); // went for 45 seconds on time interval of 10
                ml.WaitForAnswer();
                datalist = (double[,])ml.GetArray(typeof(double), 2);
                numrows = datalist.GetLength(0);
                numcolumns = datalist.GetLength(1);
                fw2.Close();
                t.Start();
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.Stop();
            firstIndicator = true;
        }

        private void restartAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            count = 0;
            t.Start();
        }


        private void modifyParameterValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firstIndicator = false;
            t.Stop();
            count = 0;
            bucketlist.Clear();
            frmParameterDialog pd = new frmParameterDialog();
            pd.Text = "Enter the parameter values for the system";
            // just some default values
            pd.Data.R_ = paras.R;
            pd.Data.QInflow_ = paras.QInflow;
            pd.Data.Qc_ = paras.Qc;
            pd.Data.K_ = paras.K;
            pd.Data.Sigma_ = paras.Sigma;
            pd.Data.Rho_ = paras.Rho;
            pd.Data.Numb_ = paras.Numb;
            pd.Data.Tlength_ = paras.Tlength;
            pd.Data.Omega_ = paras.Omega;

            DialogResult d = pd.ShowDialog();
            if (d == DialogResult.OK)
            {
                paras.R = pd.Data.R_;
                paras.QInflow = pd.Data.QInflow_;
                paras.Qc = pd.Data.Qc_;
                paras.K = pd.Data.K_;
                paras.Sigma = pd.Data.Sigma_;
                paras.Rho = pd.Data.Rho_;
                paras.Numb = pd.Data.Numb_;
                paras.Tlength = pd.Data.Tlength_;
                paras.Omega = pd.Data.Omega_;
            }
            //reset bucketlist
            for (i = 0; i < paras.Numb; i++) bucketlist.Add(new Bucket());
            for (j = 0; j < bucketlist.Count; j++)
            {
                bucketlist[j].Width = 4 * (float)Math.Pow(0.9, paras.Numb - 8); // when there are 8 buckets, looks best if bucket width and height is 4
                bucketlist[j].Height = 4 * (float)Math.Pow(0.9, paras.Numb - 8); // adjust depending on number of buckets according to this formula: width = 4*(0.9)^(n-8)
                bucketlist[j].X = (float)(paras.R * Math.Sin(-theta - j * 2 * Math.PI / bucketlist.Count));
                bucketlist[j].Y = (float)(-paras.R * Math.Cos(-theta - j * 2 * Math.PI / bucketlist.Count));
            }

            this.Refresh();
            firstIndicator = false;
        }


        void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            frmGraphView f = null;
            if (f != null) f.UpdateData();
        }

        private void newGraphViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGraphView g = new frmGraphView();
            g.UseExistingDataList(bs);
            g.Show();
        }


    }

    public class parameterData
    {
        private float r;
        public float R
        {
            get { return r; }
            set { r = value; }
        }
        private float qInflow;
        public float QInflow
        {
            get { return qInflow; }
            set { qInflow = value; }
        }
        private float qc;
        public float Qc
        {
            get { return qc; }
            set { qc = value; }
        }
        private float sigma;
        public float Sigma
        {
            get { return sigma; }
            set { sigma = value; }
        }
        private float rho;
        public float Rho
        {
            get { return rho; }
            set { rho = value; }
        }
        private float numb;
        public float Numb
        {
            get { return numb; }
            set { numb = value; }
        }
        private float tlength;
        public float Tlength
        {
            get { return tlength; }
            set { tlength = value; }
        }
        private float k;
        public float K
        {
            get { return k; }
            set { k = value; }
        }
        private float omega;
        public float Omega
        {
            get { return omega; }
            set { omega = value; }
        }
    }
}
