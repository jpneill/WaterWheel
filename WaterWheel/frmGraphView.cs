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
    public partial class frmGraphView : Form
    {
        private BindingSource bs = null;
        public frmGraphView()
        {
            InitializeComponent();
        }
        public void UseExistingDataList(BindingSource bsref)
        {
            bs = bsref;
            chartData.DataSource = bs;
            chartData.Series[0].XValueMember = "X";
            chartData.Series[0].YValueMembers = "Y";
        }
        public void UpdateData()
        {
            chartData.DataBind();
        }
    }
}
