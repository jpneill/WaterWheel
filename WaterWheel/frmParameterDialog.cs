using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WaterWheel
{
    public partial class frmParameterDialog : Form
    {
        private dlgData data;
        public dlgData Data
        {
            get { return data; }
        }
        public frmParameterDialog()
        {
            InitializeComponent();
            data = new dlgData();
            //bind the properties to the controls
            txtR.DataBindings.Add("Text", data, "R_");
            txtQ.DataBindings.Add("Text", data, "QInflow_");
            txtQc.DataBindings.Add("Text", data, "Qc_");
            txtK.DataBindings.Add("Text", data, "K_");
            txtSigma.DataBindings.Add("Text", data, "Sigma_");
            txtRho.DataBindings.Add("Text", data, "Rho_");
            txtN.DataBindings.Add("Text", data, "Numb_");
            txtT.DataBindings.Add("Text", data, "Tlength_");
            txtOmega.DataBindings.Add("Text", data, "Omega_");
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }


    public class dlgData
    {
        private float r_;
        public float R_
        {
            get { return r_; }
            set { r_ = value; }
        }
        private float qInflow_;
        public float QInflow_
        {
            get { return qInflow_; }
            set { qInflow_ = value; }
        }
        private float qc_;
        public float Qc_
        {
            get { return qc_; }
            set { qc_ = value; }
        }
        private float sigma_;
        public float Sigma_
        {
            get { return sigma_; }
            set { sigma_ = value; }
        }
        private float rho_;
        public float Rho_
        {
            get { return rho_; }
            set { rho_ = value; }
        }
        private float numb_;
        public float Numb_
        {
            get { return numb_; }
            set { numb_ = value; }
        }
        private float tlength_;
        public float Tlength_
        {
            get { return tlength_; }
            set { tlength_ = value; }
        }
        private float k_;
        public float K_
        {
            get { return k_; }
            set { k_ = value; }
        }
        private float omega_;
        public float Omega_
        {
            get { return omega_; }
            set { omega_ = value; }
        }
    }
}