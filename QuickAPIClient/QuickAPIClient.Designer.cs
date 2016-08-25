namespace Flight.Trade.TradeQuickAPI.Client
{
    partial class QuickAPIClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickAPIClient));
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.lblURL = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.RichTextBox();
            this.txtRequest = new System.Windows.Forms.RichTextBox();
            this.cmbRequestType = new System.Windows.Forms.ComboBox();
            this.lblTimeConsuming = new System.Windows.Forms.Label();
            this.chkLoadRequestSample = new System.Windows.Forms.CheckBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.chkAccessProxy = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.specifyURL = new System.Windows.Forms.CheckBox();
            this.checkGZip = new System.Windows.Forms.CheckBox();
            this.checkGUID = new System.Windows.Forms.CheckBox();
            this.checkMD5 = new System.Windows.Forms.CheckBox();
            this.btnSaveResponse = new System.Windows.Forms.Button();
            this.btnSaveRequest = new System.Windows.Forms.Button();
            this.btnOpenRequest = new System.Windows.Forms.Button();
            this.btnGenerateRequest = new System.Windows.Forms.Button();
            this.lblResponse = new System.Windows.Forms.Label();
            this.lblRequest = new System.Windows.Forms.Label();
            this.txtRequestURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbXML = new System.Windows.Forms.RadioButton();
            this.rbSOAP = new System.Windows.Forms.RadioButton();
            this.rbJSON = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPWD = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.chkValidateRequest = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSendRequest.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnSendRequest.Location = new System.Drawing.Point(981, 13);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(75, 23);
            this.btnSendRequest.TabIndex = 2;
            this.btnSendRequest.Text = "发送";
            this.btnSendRequest.UseVisualStyleBackColor = false;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(13, 24);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(47, 12);
            this.lblURL.TabIndex = 4;
            this.lblURL.Text = "服务器:";
            // 
            // txtResponse
            // 
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.Location = new System.Drawing.Point(0, 0);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.Size = new System.Drawing.Size(554, 552);
            this.txtResponse.TabIndex = 1;
            this.txtResponse.Text = "";
            // 
            // txtRequest
            // 
            this.txtRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRequest.Location = new System.Drawing.Point(0, 0);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(555, 552);
            this.txtRequest.TabIndex = 5;
            this.txtRequest.Text = "";
            this.txtRequest.TextChanged += new System.EventHandler(this.txtRequest_TextChanged);
            // 
            // cmbRequestType
            // 
            this.cmbRequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequestType.FormattingEnabled = true;
            this.cmbRequestType.Location = new System.Drawing.Point(555, 16);
            this.cmbRequestType.Name = "cmbRequestType";
            this.cmbRequestType.Size = new System.Drawing.Size(184, 20);
            this.cmbRequestType.TabIndex = 11;
            this.cmbRequestType.SelectedIndexChanged += new System.EventHandler(this.cmbRequestType_SelectedIndexChanged);
            // 
            // lblTimeConsuming
            // 
            this.lblTimeConsuming.AutoSize = true;
            this.lblTimeConsuming.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblTimeConsuming.Location = new System.Drawing.Point(3, 3);
            this.lblTimeConsuming.Name = "lblTimeConsuming";
            this.lblTimeConsuming.Size = new System.Drawing.Size(47, 12);
            this.lblTimeConsuming.TabIndex = 12;
            this.lblTimeConsuming.Text = "耗时： ";
            // 
            // chkLoadRequestSample
            // 
            this.chkLoadRequestSample.AutoSize = true;
            this.chkLoadRequestSample.Checked = true;
            this.chkLoadRequestSample.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoadRequestSample.Location = new System.Drawing.Point(745, 19);
            this.chkLoadRequestSample.Name = "chkLoadRequestSample";
            this.chkLoadRequestSample.Size = new System.Drawing.Size(96, 16);
            this.chkLoadRequestSample.TabIndex = 17;
            this.chkLoadRequestSample.Text = "加载示例请求";
            this.chkLoadRequestSample.UseVisualStyleBackColor = true;
            // 
            // cmbServer
            // 
            this.cmbServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(67, 18);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(300, 20);
            this.cmbServer.TabIndex = 19;
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
            this.cmbServer.TextChanged += new System.EventHandler(this.cmbServer_TextChanged);
            // 
            // chkAccessProxy
            // 
            this.chkAccessProxy.AutoSize = true;
            this.chkAccessProxy.Checked = true;
            this.chkAccessProxy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccessProxy.Location = new System.Drawing.Point(373, 20);
            this.chkAccessProxy.Name = "chkAccessProxy";
            this.chkAccessProxy.Size = new System.Drawing.Size(72, 16);
            this.chkAccessProxy.TabIndex = 20;
            this.chkAccessProxy.Text = "访问外网";
            this.chkAccessProxy.UseVisualStyleBackColor = true;
            this.chkAccessProxy.CheckedChanged += new System.EventHandler(this.chkAccessProxy_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "接口名称:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 157);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtRequest);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtResponse);
            this.splitContainer1.Size = new System.Drawing.Size(1113, 552);
            this.splitContainer1.SplitterDistance = 555;
            this.splitContainer1.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.specifyURL);
            this.panel1.Controls.Add(this.checkGZip);
            this.panel1.Controls.Add(this.checkGUID);
            this.panel1.Controls.Add(this.checkMD5);
            this.panel1.Controls.Add(this.btnSaveResponse);
            this.panel1.Controls.Add(this.btnSaveRequest);
            this.panel1.Controls.Add(this.btnOpenRequest);
            this.panel1.Controls.Add(this.btnGenerateRequest);
            this.panel1.Controls.Add(this.lblResponse);
            this.panel1.Controls.Add(this.lblRequest);
            this.panel1.Controls.Add(this.txtRequestURL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbXML);
            this.panel1.Controls.Add(this.rbSOAP);
            this.panel1.Controls.Add(this.rbJSON);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblPWD);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.btnSendRequest);
            this.panel1.Controls.Add(this.lblURL);
            this.panel1.Controls.Add(this.cmbRequestType);
            this.panel1.Controls.Add(this.chkValidateRequest);
            this.panel1.Controls.Add(this.chkLoadRequestSample);
            this.panel1.Controls.Add(this.cmbServer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkAccessProxy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 157);
            this.panel1.TabIndex = 25;
            // 
            // specifyURL
            // 
            this.specifyURL.AutoSize = true;
            this.specifyURL.Location = new System.Drawing.Point(745, 63);
            this.specifyURL.Name = "specifyURL";
            this.specifyURL.Size = new System.Drawing.Size(78, 16);
            this.specifyURL.TabIndex = 39;
            this.specifyURL.Text = "自定义URL";
            this.specifyURL.UseVisualStyleBackColor = true;
            this.specifyURL.CheckedChanged += new System.EventHandler(this.specifyURL_CheckedChanged);
            // 
            // checkGZip
            // 
            this.checkGZip.AutoSize = true;
            this.checkGZip.Checked = true;
            this.checkGZip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkGZip.Location = new System.Drawing.Point(855, 59);
            this.checkGZip.Name = "checkGZip";
            this.checkGZip.Size = new System.Drawing.Size(72, 16);
            this.checkGZip.TabIndex = 38;
            this.checkGZip.Text = "启用GZip";
            this.checkGZip.UseVisualStyleBackColor = true;
            // 
            // checkGUID
            // 
            this.checkGUID.AutoSize = true;
            this.checkGUID.Checked = true;
            this.checkGUID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkGUID.Location = new System.Drawing.Point(855, 40);
            this.checkGUID.Name = "checkGUID";
            this.checkGUID.Size = new System.Drawing.Size(72, 16);
            this.checkGUID.TabIndex = 37;
            this.checkGUID.Text = "生成GUID";
            this.checkGUID.UseVisualStyleBackColor = true;
            // 
            // checkMD5
            // 
            this.checkMD5.AutoSize = true;
            this.checkMD5.Checked = true;
            this.checkMD5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMD5.Location = new System.Drawing.Point(745, 41);
            this.checkMD5.Name = "checkMD5";
            this.checkMD5.Size = new System.Drawing.Size(66, 16);
            this.checkMD5.TabIndex = 36;
            this.checkMD5.Text = "MD5密码";
            this.checkMD5.UseVisualStyleBackColor = true;
            // 
            // btnSaveResponse
            // 
            this.btnSaveResponse.Location = new System.Drawing.Point(616, 131);
            this.btnSaveResponse.Name = "btnSaveResponse";
            this.btnSaveResponse.Size = new System.Drawing.Size(75, 23);
            this.btnSaveResponse.TabIndex = 35;
            this.btnSaveResponse.Text = "保存报文";
            this.btnSaveResponse.UseVisualStyleBackColor = true;
            this.btnSaveResponse.Click += new System.EventHandler(this.btnSaveResponse_Click);
            // 
            // btnSaveRequest
            // 
            this.btnSaveRequest.Location = new System.Drawing.Point(224, 131);
            this.btnSaveRequest.Name = "btnSaveRequest";
            this.btnSaveRequest.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRequest.TabIndex = 35;
            this.btnSaveRequest.Text = "保存报文";
            this.btnSaveRequest.UseVisualStyleBackColor = true;
            this.btnSaveRequest.Click += new System.EventHandler(this.btnSaveRequest_Click);
            // 
            // btnOpenRequest
            // 
            this.btnOpenRequest.Location = new System.Drawing.Point(143, 131);
            this.btnOpenRequest.Name = "btnOpenRequest";
            this.btnOpenRequest.Size = new System.Drawing.Size(75, 23);
            this.btnOpenRequest.TabIndex = 35;
            this.btnOpenRequest.Text = "打开报文";
            this.btnOpenRequest.UseVisualStyleBackColor = true;
            this.btnOpenRequest.Click += new System.EventHandler(this.btnOpenRequest_Click);
            // 
            // btnGenerateRequest
            // 
            this.btnGenerateRequest.Location = new System.Drawing.Point(62, 131);
            this.btnGenerateRequest.Name = "btnGenerateRequest";
            this.btnGenerateRequest.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateRequest.TabIndex = 34;
            this.btnGenerateRequest.Text = "生成报文";
            this.btnGenerateRequest.UseVisualStyleBackColor = true;
            this.btnGenerateRequest.Click += new System.EventHandler(this.btnGenerateRequest_Click);
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(557, 139);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(53, 12);
            this.lblResponse.TabIndex = 33;
            this.lblResponse.Text = "响应报文";
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Location = new System.Drawing.Point(3, 137);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(53, 12);
            this.lblRequest.TabIndex = 32;
            this.lblRequest.Text = "请求报文";
            // 
            // txtRequestURL
            // 
            this.txtRequestURL.Location = new System.Drawing.Point(67, 56);
            this.txtRequestURL.Name = "txtRequestURL";
            this.txtRequestURL.ReadOnly = true;
            this.txtRequestURL.Size = new System.Drawing.Size(672, 21);
            this.txtRequestURL.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "URL:";
            // 
            // rbXML
            // 
            this.rbXML.AutoSize = true;
            this.rbXML.Checked = true;
            this.rbXML.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbXML.Location = new System.Drawing.Point(21, 100);
            this.rbXML.Name = "rbXML";
            this.rbXML.Size = new System.Drawing.Size(41, 16);
            this.rbXML.TabIndex = 22;
            this.rbXML.TabStop = true;
            this.rbXML.Text = "xml";
            this.rbXML.UseVisualStyleBackColor = true;
            this.rbXML.CheckedChanged += new System.EventHandler(this.rbXML_CheckedChanged);
            // 
            // rbSOAP
            // 
            this.rbSOAP.AutoSize = true;
            this.rbSOAP.Enabled = false;
            this.rbSOAP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbSOAP.Location = new System.Drawing.Point(121, 100);
            this.rbSOAP.Name = "rbSOAP";
            this.rbSOAP.Size = new System.Drawing.Size(47, 16);
            this.rbSOAP.TabIndex = 24;
            this.rbSOAP.Text = "soap";
            this.rbSOAP.UseVisualStyleBackColor = true;
            // 
            // rbJSON
            // 
            this.rbJSON.AutoSize = true;
            this.rbJSON.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbJSON.Location = new System.Drawing.Point(68, 100);
            this.rbJSON.Name = "rbJSON";
            this.rbJSON.Size = new System.Drawing.Size(47, 16);
            this.rbJSON.TabIndex = 23;
            this.rbJSON.Text = "json";
            this.rbJSON.UseVisualStyleBackColor = true;
            this.rbJSON.CheckedChanged += new System.EventHandler(this.rbJSON_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Location = new System.Drawing.Point(13, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(162, 40);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "协议类型";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(419, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 28;
            this.txtPassword.Text = "Ctrip@2014Test";
            // 
            // lblPWD
            // 
            this.lblPWD.AutoSize = true;
            this.lblPWD.Location = new System.Drawing.Point(378, 104);
            this.lblPWD.Name = "lblPWD";
            this.lblPWD.Size = new System.Drawing.Size(35, 12);
            this.lblPWD.TabIndex = 27;
            this.lblPWD.Text = "密码:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(262, 99);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 26;
            this.txtUserName.Text = "内部测试";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(209, 104);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(47, 12);
            this.lblUserName.TabIndex = 25;
            this.lblUserName.Text = "用户名:";
            // 
            // chkValidateRequest
            // 
            this.chkValidateRequest.AutoSize = true;
            this.chkValidateRequest.Location = new System.Drawing.Point(855, 19);
            this.chkValidateRequest.Name = "chkValidateRequest";
            this.chkValidateRequest.Size = new System.Drawing.Size(72, 16);
            this.chkValidateRequest.TabIndex = 17;
            this.chkValidateRequest.Text = "校验请求";
            this.chkValidateRequest.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTimeConsuming);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 709);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1113, 21);
            this.panel2.TabIndex = 26;
            // 
            // QuickAPIClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 730);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuickAPIClient";
            this.Text = "QuickAPIClient";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.RichTextBox txtResponse;
        private System.Windows.Forms.RichTextBox txtRequest;
        private System.Windows.Forms.ComboBox cmbRequestType;
        private System.Windows.Forms.Label lblTimeConsuming;
        private System.Windows.Forms.CheckBox chkLoadRequestSample;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.CheckBox chkAccessProxy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbXML;
        private System.Windows.Forms.RadioButton rbSOAP;
        private System.Windows.Forms.RadioButton rbJSON;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPWD;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.TextBox txtRequestURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerateRequest;
        private System.Windows.Forms.CheckBox chkValidateRequest;
        private System.Windows.Forms.Button btnSaveResponse;
        private System.Windows.Forms.Button btnSaveRequest;
        private System.Windows.Forms.Button btnOpenRequest;
        private System.Windows.Forms.CheckBox checkMD5;
        private System.Windows.Forms.CheckBox checkGUID;
        private System.Windows.Forms.CheckBox checkGZip;
        private System.Windows.Forms.CheckBox specifyURL;

    }
}

