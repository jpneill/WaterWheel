namespace WaterWheel
{
    partial class frmParameterDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtR = new System.Windows.Forms.TextBox();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.txtQc = new System.Windows.Forms.TextBox();
            this.txtK = new System.Windows.Forms.TextBox();
            this.txtSigma = new System.Windows.Forms.TextBox();
            this.txtRho = new System.Windows.Forms.TextBox();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOmega = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(162, 36);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(86, 20);
            this.txtR.TabIndex = 0;
            // 
            // txtQ
            // 
            this.txtQ.Location = new System.Drawing.Point(162, 68);
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(86, 20);
            this.txtQ.TabIndex = 1;
            // 
            // txtQc
            // 
            this.txtQc.Location = new System.Drawing.Point(162, 102);
            this.txtQc.Name = "txtQc";
            this.txtQc.Size = new System.Drawing.Size(86, 20);
            this.txtQc.TabIndex = 2;
            // 
            // txtK
            // 
            this.txtK.Location = new System.Drawing.Point(162, 136);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(86, 20);
            this.txtK.TabIndex = 3;
            // 
            // txtSigma
            // 
            this.txtSigma.Location = new System.Drawing.Point(162, 169);
            this.txtSigma.Name = "txtSigma";
            this.txtSigma.Size = new System.Drawing.Size(86, 20);
            this.txtSigma.TabIndex = 4;
            // 
            // txtRho
            // 
            this.txtRho.Location = new System.Drawing.Point(162, 202);
            this.txtRho.Name = "txtRho";
            this.txtRho.Size = new System.Drawing.Size(86, 20);
            this.txtRho.TabIndex = 5;
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(162, 272);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(86, 20);
            this.txtN.TabIndex = 6;
            // 
            // txtT
            // 
            this.txtT.Location = new System.Drawing.Point(162, 306);
            this.txtT.Name = "txtT";
            this.txtT.Size = new System.Drawing.Size(86, 20);
            this.txtT.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Radius of the wheel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rate of water flowing in:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Angle qc (degrees):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Prandtl number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Rayleigh number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Number of buckets:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Time Interval:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Leakage rate:";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(40, 350);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(87, 32);
            this.btOK.TabIndex = 16;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(156, 350);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(92, 32);
            this.btCancel.TabIndex = 17;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Initial Velocity (omega):";
            // 
            // txtOmega
            // 
            this.txtOmega.Location = new System.Drawing.Point(162, 237);
            this.txtOmega.Name = "txtOmega";
            this.txtOmega.Size = new System.Drawing.Size(86, 20);
            this.txtOmega.TabIndex = 19;
            // 
            // frmParameterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 394);
            this.Controls.Add(this.txtOmega);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtT);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.txtRho);
            this.Controls.Add(this.txtSigma);
            this.Controls.Add(this.txtK);
            this.Controls.Add(this.txtQc);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.txtR);
            this.Name = "frmParameterDialog";
            this.Text = "frmParameterDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.TextBox txtQc;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.TextBox txtSigma;
        private System.Windows.Forms.TextBox txtRho;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOmega;
    }
}