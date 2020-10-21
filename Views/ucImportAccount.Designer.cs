namespace BKToolSpamVIP.Views
{
    partial class ucImportAccount
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtPassNew = new System.Windows.Forms.TextBox();
            this.cbChangePass = new System.Windows.Forms.CheckBox();
            this.btnStartChangeInfo = new FontAwesome.Sharp.IconButton();
            this.btnLoadDataToGridView = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Thread = new System.Windows.Forms.Label();
            this.txtTotalThread = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalAccount = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImport)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImport
            // 
            this.dataGridViewImport.AllowUserToAddRows = false;
            this.dataGridViewImport.AllowUserToDeleteRows = false;
            this.dataGridViewImport.AllowUserToResizeColumns = false;
            this.dataGridViewImport.AllowUserToResizeRows = false;
            this.dataGridViewImport.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewImport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewImport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.ip,
            this.uid,
            this.password,
            this.tfa,
            this.fullname,
            this.message});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewImport.Location = new System.Drawing.Point(8, 13);
            this.dataGridViewImport.Name = "dataGridViewImport";
            this.dataGridViewImport.RowHeadersVisible = false;
            this.dataGridViewImport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewImport.ShowEditingIcon = false;
            this.dataGridViewImport.Size = new System.Drawing.Size(822, 642);
            this.dataGridViewImport.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.txtTotalThread);
            this.panel1.Controls.Add(this.Thread);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.txtPassNew);
            this.panel1.Controls.Add(this.cbChangePass);
            this.panel1.Controls.Add(this.btnStartChangeInfo);
            this.panel1.Controls.Add(this.btnLoadDataToGridView);
            this.panel1.Location = new System.Drawing.Point(15, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 684);
            this.panel1.TabIndex = 1;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(14, 238);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(105, 17);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Text = "Logout All Group";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(14, 212);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(110, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Logout All Device";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 186);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Enable 2FA";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtPassNew
            // 
            this.txtPassNew.Location = new System.Drawing.Point(111, 158);
            this.txtPassNew.Name = "txtPassNew";
            this.txtPassNew.Size = new System.Drawing.Size(75, 20);
            this.txtPassNew.TabIndex = 15;
            this.txtPassNew.Text = "Vkldkm123";
            // 
            // cbChangePass
            // 
            this.cbChangePass.AutoSize = true;
            this.cbChangePass.Checked = true;
            this.cbChangePass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbChangePass.Location = new System.Drawing.Point(14, 160);
            this.cbChangePass.Name = "cbChangePass";
            this.cbChangePass.Size = new System.Drawing.Size(89, 17);
            this.cbChangePass.TabIndex = 14;
            this.cbChangePass.Text = "Change Pass";
            this.cbChangePass.UseVisualStyleBackColor = true;
            // 
            // btnStartChangeInfo
            // 
            this.btnStartChangeInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnStartChangeInfo.FlatAppearance.BorderSize = 0;
            this.btnStartChangeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartChangeInfo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnStartChangeInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStartChangeInfo.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnStartChangeInfo.IconColor = System.Drawing.Color.Gainsboro;
            this.btnStartChangeInfo.IconSize = 32;
            this.btnStartChangeInfo.Location = new System.Drawing.Point(14, 287);
            this.btnStartChangeInfo.Name = "btnStartChangeInfo";
            this.btnStartChangeInfo.Rotation = 0D;
            this.btnStartChangeInfo.Size = new System.Drawing.Size(172, 44);
            this.btnStartChangeInfo.TabIndex = 0;
            this.btnStartChangeInfo.Text = "Start Change Info";
            this.btnStartChangeInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartChangeInfo.UseVisualStyleBackColor = false;
            this.btnStartChangeInfo.Click += new System.EventHandler(this.btnStartChangeInfo_Click);
            // 
            // btnLoadDataToGridView
            // 
            this.btnLoadDataToGridView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnLoadDataToGridView.FlatAppearance.BorderSize = 0;
            this.btnLoadDataToGridView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDataToGridView.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLoadDataToGridView.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLoadDataToGridView.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.btnLoadDataToGridView.IconColor = System.Drawing.Color.Gainsboro;
            this.btnLoadDataToGridView.IconSize = 32;
            this.btnLoadDataToGridView.Location = new System.Drawing.Point(17, 13);
            this.btnLoadDataToGridView.Name = "btnLoadDataToGridView";
            this.btnLoadDataToGridView.Rotation = 0D;
            this.btnLoadDataToGridView.Size = new System.Drawing.Size(169, 44);
            this.btnLoadDataToGridView.TabIndex = 0;
            this.btnLoadDataToGridView.Text = "Load Account";
            this.btnLoadDataToGridView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadDataToGridView.UseVisualStyleBackColor = false;
            this.btnLoadDataToGridView.Click += new System.EventHandler(this.btnLoadDataToGridView_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTotalAccount);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dataGridViewImport);
            this.panel2.Location = new System.Drawing.Point(232, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(838, 684);
            this.panel2.TabIndex = 2;
            // 
            // Thread
            // 
            this.Thread.AutoSize = true;
            this.Thread.Location = new System.Drawing.Point(14, 138);
            this.Thread.Name = "Thread";
            this.Thread.Size = new System.Drawing.Size(82, 13);
            this.Thread.TabIndex = 17;
            this.Thread.Text = "Thread / Action";
            // 
            // txtTotalThread
            // 
            this.txtTotalThread.Location = new System.Drawing.Point(111, 135);
            this.txtTotalThread.Name = "txtTotalThread";
            this.txtTotalThread.Size = new System.Drawing.Size(75, 20);
            this.txtTotalThread.TabIndex = 18;
            this.txtTotalThread.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 663);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Total: ";
            // 
            // lblTotalAccount
            // 
            this.lblTotalAccount.AutoSize = true;
            this.lblTotalAccount.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAccount.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalAccount.Location = new System.Drawing.Point(39, 660);
            this.lblTotalAccount.Name = "lblTotalAccount";
            this.lblTotalAccount.Size = new System.Drawing.Size(18, 19);
            this.lblTotalAccount.TabIndex = 18;
            this.lblTotalAccount.Text = "0";
            // 
            // stt
            // 
            this.stt.HeaderText = "*";
            this.stt.Name = "stt";
            this.stt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stt.Width = 30;
            // 
            // ip
            // 
            this.ip.HeaderText = "IP";
            this.ip.Name = "ip";
            // 
            // uid
            // 
            this.uid.HeaderText = "UID";
            this.uid.Name = "uid";
            this.uid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // password
            // 
            this.password.HeaderText = "PassWord";
            this.password.Name = "password";
            this.password.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tfa
            // 
            this.tfa.HeaderText = "2FA";
            this.tfa.Name = "tfa";
            this.tfa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tfa.Width = 120;
            // 
            // fullname
            // 
            this.fullname.HeaderText = "Full Name";
            this.fullname.Name = "fullname";
            this.fullname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fullname.Width = 120;
            // 
            // message
            // 
            this.message.HeaderText = "Message";
            this.message.Name = "message";
            this.message.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.message.Width = 230;
            // 
            // ucImportAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucImportAccount";
            this.Size = new System.Drawing.Size(1084, 711);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewImport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnLoadDataToGridView;
        private System.Windows.Forms.TextBox txtPassNew;
        private System.Windows.Forms.CheckBox cbChangePass;
        private System.Windows.Forms.CheckBox checkBox1;
        private FontAwesome.Sharp.IconButton btnStartChangeInfo;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox txtTotalThread;
        private System.Windows.Forms.Label Thread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfa;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
    }
}
