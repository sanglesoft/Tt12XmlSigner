namespace TT12.Signer
{
    partial class frmDocument
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocument));
            tabControl = new TabControl();
            tabBoPhan = new TabPage();
            dgvBoPhan = new DataGridView();
            tabNhanLuc = new TabPage();
            dgvNhanLuc = new DataGridView();
            tabThuoc = new TabPage();
            dgvThuoc = new DataGridView();
            tabVatTu = new TabPage();
            dgvVatTu = new DataGridView();
            tabDichVu = new TabPage();
            dgvDichVu = new DataGridView();
            tabMay = new TabPage();
            dgvMay = new DataGridView();
            tabC79 = new TabPage();
            dgvC79 = new DataGridView();
            txtXml = new TextBox();
            btnLoadExcel = new Button();
            btnExportExcel = new Button();
            cbbCert = new ComboBox();
            btnExportXML = new Button();
            btnLoadXmlFile = new Button();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            toolStripStatusLabelSpring = new ToolStripStatusLabel();
            lblEMR = new ToolStripStatusLabel();
            txtLimit = new TextBox();
            lblPart = new Label();
            lblCert = new Label();
            tabControl.SuspendLayout();
            tabBoPhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBoPhan).BeginInit();
            tabNhanLuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanLuc).BeginInit();
            tabThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).BeginInit();
            tabVatTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVatTu).BeginInit();
            tabDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).BeginInit();
            tabMay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMay).BeginInit();
            tabC79.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvC79).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabBoPhan);
            tabControl.Controls.Add(tabNhanLuc);
            tabControl.Controls.Add(tabThuoc);
            tabControl.Controls.Add(tabVatTu);
            tabControl.Controls.Add(tabDichVu);
            tabControl.Controls.Add(tabMay);
            tabControl.Controls.Add(tabC79);
            tabControl.Location = new Point(0, 49);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 379);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabBoPhan
            // 
            tabBoPhan.Controls.Add(dgvBoPhan);
            tabBoPhan.Location = new Point(4, 24);
            tabBoPhan.Name = "tabBoPhan";
            tabBoPhan.Padding = new Padding(3);
            tabBoPhan.Size = new Size(792, 351);
            tabBoPhan.TabIndex = 0;
            tabBoPhan.Text = "1. Bộ phận";
            tabBoPhan.UseVisualStyleBackColor = true;
            // 
            // dgvBoPhan
            // 
            dgvBoPhan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBoPhan.Dock = DockStyle.Fill;
            dgvBoPhan.Location = new Point(3, 3);
            dgvBoPhan.Name = "dgvBoPhan";
            dgvBoPhan.RowHeadersVisible = false;
            dgvBoPhan.Size = new Size(786, 345);
            dgvBoPhan.TabIndex = 0;
            dgvBoPhan.DataBindingComplete += Shared_DataBindingComplete;
            // 
            // tabNhanLuc
            // 
            tabNhanLuc.Controls.Add(dgvNhanLuc);
            tabNhanLuc.Location = new Point(4, 24);
            tabNhanLuc.Name = "tabNhanLuc";
            tabNhanLuc.Padding = new Padding(3);
            tabNhanLuc.Size = new Size(792, 351);
            tabNhanLuc.TabIndex = 1;
            tabNhanLuc.Text = "2. Nhân lực";
            tabNhanLuc.UseVisualStyleBackColor = true;
            // 
            // dgvNhanLuc
            // 
            dgvNhanLuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanLuc.Dock = DockStyle.Fill;
            dgvNhanLuc.Location = new Point(3, 3);
            dgvNhanLuc.Name = "dgvNhanLuc";
            dgvNhanLuc.RowHeadersVisible = false;
            dgvNhanLuc.Size = new Size(786, 345);
            dgvNhanLuc.TabIndex = 1;
            dgvNhanLuc.DataBindingComplete += Shared_DataBindingComplete;
            // 
            // tabThuoc
            // 
            tabThuoc.Controls.Add(dgvThuoc);
            tabThuoc.Location = new Point(4, 24);
            tabThuoc.Name = "tabThuoc";
            tabThuoc.Padding = new Padding(3);
            tabThuoc.Size = new Size(792, 351);
            tabThuoc.TabIndex = 2;
            tabThuoc.Text = "3. Thuốc";
            tabThuoc.UseVisualStyleBackColor = true;
            // 
            // dgvThuoc
            // 
            dgvThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThuoc.Dock = DockStyle.Fill;
            dgvThuoc.Location = new Point(3, 3);
            dgvThuoc.Name = "dgvThuoc";
            dgvThuoc.RowHeadersVisible = false;
            dgvThuoc.Size = new Size(786, 345);
            dgvThuoc.TabIndex = 1;
            dgvThuoc.DataBindingComplete += Shared_DataBindingComplete;
            // 
            // tabVatTu
            // 
            tabVatTu.Controls.Add(dgvVatTu);
            tabVatTu.Location = new Point(4, 24);
            tabVatTu.Name = "tabVatTu";
            tabVatTu.Padding = new Padding(3);
            tabVatTu.Size = new Size(792, 351);
            tabVatTu.TabIndex = 3;
            tabVatTu.Text = "4. Vật tư";
            tabVatTu.UseVisualStyleBackColor = true;
            // 
            // dgvVatTu
            // 
            dgvVatTu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVatTu.Dock = DockStyle.Fill;
            dgvVatTu.Location = new Point(3, 3);
            dgvVatTu.Name = "dgvVatTu";
            dgvVatTu.RowHeadersVisible = false;
            dgvVatTu.Size = new Size(786, 345);
            dgvVatTu.TabIndex = 1;
            dgvVatTu.DataBindingComplete += Shared_DataBindingComplete;
            // 
            // tabDichVu
            // 
            tabDichVu.Controls.Add(dgvDichVu);
            tabDichVu.Location = new Point(4, 24);
            tabDichVu.Name = "tabDichVu";
            tabDichVu.Padding = new Padding(3);
            tabDichVu.Size = new Size(792, 351);
            tabDichVu.TabIndex = 4;
            tabDichVu.Text = "5. Dịch vụ";
            tabDichVu.UseVisualStyleBackColor = true;
            // 
            // dgvDichVu
            // 
            dgvDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDichVu.Dock = DockStyle.Fill;
            dgvDichVu.Location = new Point(3, 3);
            dgvDichVu.Name = "dgvDichVu";
            dgvDichVu.RowHeadersVisible = false;
            dgvDichVu.Size = new Size(786, 345);
            dgvDichVu.TabIndex = 1;
            dgvDichVu.DataBindingComplete += Shared_DataBindingComplete;
            // 
            // tabMay
            // 
            tabMay.Controls.Add(dgvMay);
            tabMay.Location = new Point(4, 24);
            tabMay.Name = "tabMay";
            tabMay.Padding = new Padding(3);
            tabMay.Size = new Size(792, 351);
            tabMay.TabIndex = 5;
            tabMay.Text = "6. Máy";
            tabMay.UseVisualStyleBackColor = true;
            // 
            // dgvMay
            // 
            dgvMay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMay.Dock = DockStyle.Fill;
            dgvMay.Location = new Point(3, 3);
            dgvMay.Name = "dgvMay";
            dgvMay.RowHeadersVisible = false;
            dgvMay.Size = new Size(786, 345);
            dgvMay.TabIndex = 1;
            dgvMay.DataBindingComplete += Shared_DataBindingComplete;
            // 
            // tabC79
            // 
            tabC79.Controls.Add(dgvC79);
            tabC79.Location = new Point(4, 24);
            tabC79.Name = "tabC79";
            tabC79.Padding = new Padding(3);
            tabC79.Size = new Size(792, 351);
            tabC79.TabIndex = 6;
            tabC79.Text = "Tổng hợp C79";
            tabC79.UseVisualStyleBackColor = true;
            // 
            // dgvC79
            // 
            dgvC79.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvC79.Dock = DockStyle.Fill;
            dgvC79.Location = new Point(3, 3);
            dgvC79.Name = "dgvC79";
            dgvC79.RowHeadersVisible = false;
            dgvC79.Size = new Size(786, 345);
            dgvC79.TabIndex = 1;
            dgvC79.DataBindingComplete += Shared_DataBindingComplete;
            // 
            // txtXml
            // 
            txtXml.BackColor = Color.FromArgb(64, 64, 64);
            txtXml.BorderStyle = BorderStyle.None;
            txtXml.Dock = DockStyle.Bottom;
            txtXml.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtXml.ForeColor = SystemColors.Window;
            txtXml.Location = new Point(0, 357);
            txtXml.Multiline = true;
            txtXml.Name = "txtXml";
            txtXml.Size = new Size(800, 71);
            txtXml.TabIndex = 0;
            txtXml.Visible = false;
            txtXml.KeyDown += txtXml_KeyDown;
            txtXml.KeyPress += txtXml_KeyPress;
            txtXml.KeyUp += txtXml_KeyUp;
            // 
            // btnLoadExcel
            // 
            btnLoadExcel.Location = new Point(107, 12);
            btnLoadExcel.Name = "btnLoadExcel";
            btnLoadExcel.Size = new Size(89, 31);
            btnLoadExcel.TabIndex = 1;
            btnLoadExcel.Text = "Nhập Excel";
            btnLoadExcel.UseVisualStyleBackColor = true;
            btnLoadExcel.Click += btnLoadExcel_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(12, 12);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(89, 31);
            btnExportExcel.TabIndex = 1;
            btnExportExcel.Text = "Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // cbbCert
            // 
            cbbCert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbbCert.FormattingEnabled = true;
            cbbCert.Location = new Point(382, 17);
            cbbCert.Name = "cbbCert";
            cbbCert.Size = new Size(170, 23);
            cbbCert.TabIndex = 2;
            // 
            // btnExportXML
            // 
            btnExportXML.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportXML.Location = new Point(674, 12);
            btnExportXML.Name = "btnExportXML";
            btnExportXML.Size = new Size(114, 31);
            btnExportXML.TabIndex = 1;
            btnExportXML.Text = "Xuất && Ký số XML";
            btnExportXML.UseVisualStyleBackColor = true;
            btnExportXML.Click += btnExportXml_Click;
            // 
            // btnLoadXmlFile
            // 
            btnLoadXmlFile.Location = new Point(202, 12);
            btnLoadXmlFile.Name = "btnLoadXmlFile";
            btnLoadXmlFile.Size = new Size(89, 31);
            btnLoadXmlFile.TabIndex = 1;
            btnLoadXmlFile.Text = "Nhập Xml";
            btnLoadXmlFile.UseVisualStyleBackColor = true;
            btnLoadXmlFile.Click += btnLoadXmlFile_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, toolStripStatusLabelSpring, lblEMR });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 17);
            lblStatus.Text = "Ready";
            // 
            // toolStripStatusLabelSpring
            // 
            toolStripStatusLabelSpring.Name = "toolStripStatusLabelSpring";
            toolStripStatusLabelSpring.Size = new Size(689, 17);
            toolStripStatusLabelSpring.Spring = true;
            // 
            // lblEMR
            // 
            lblEMR.IsLink = true;
            lblEMR.Name = "lblEMR";
            lblEMR.Size = new Size(57, 17);
            lblEMR.Text = "emr.io.vn";
            // 
            // txtLimit
            // 
            txtLimit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLimit.Location = new Point(625, 17);
            txtLimit.Name = "txtLimit";
            txtLimit.Size = new Size(43, 23);
            txtLimit.TabIndex = 4;
            txtLimit.Text = "2000";
            txtLimit.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPart
            // 
            lblPart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPart.AutoSize = true;
            lblPart.Location = new Point(558, 20);
            lblPart.Name = "lblPart";
            lblPart.Size = new Size(61, 15);
            lblPart.TabIndex = 5;
            lblPart.Text = "Chia đoạn";
            // 
            // lblCert
            // 
            lblCert.AutoSize = true;
            lblCert.Location = new Point(297, 20);
            lblCert.Name = "lblCert";
            lblCert.Size = new Size(79, 15);
            lblCert.TabIndex = 5;
            lblCert.Text = "Chứng thư số";
            // 
            // frmDocument
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCert);
            Controls.Add(lblPart);
            Controls.Add(txtLimit);
            Controls.Add(cbbCert);
            Controls.Add(btnLoadXmlFile);
            Controls.Add(btnExportXML);
            Controls.Add(btnExportExcel);
            Controls.Add(btnLoadExcel);
            Controls.Add(tabControl);
            Controls.Add(txtXml);
            Controls.Add(statusStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 489);
            Name = "frmDocument";
            Text = "TT12 Xml signer";
            Load += frmDocument_Load;
            tabControl.ResumeLayout(false);
            tabBoPhan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBoPhan).EndInit();
            tabNhanLuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanLuc).EndInit();
            tabThuoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).EndInit();
            tabVatTu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVatTu).EndInit();
            tabDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).EndInit();
            tabMay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMay).EndInit();
            tabC79.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvC79).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabBoPhan;
        private TabPage tabNhanLuc;
        private Button btnLoadExcel;
        private DataGridView dgvBoPhan;
        private TabPage tabThuoc;
        private TabPage tabVatTu;
        private TabPage tabDichVu;
        private TabPage tabMay;
        private TextBox txtXml;
        private Button btnExportExcel;
        private ComboBox cbbCert;
        private TabPage tabC79;
        private DataGridView dgvNhanLuc;
        private DataGridView dgvThuoc;
        private DataGridView dgvVatTu;
        private DataGridView dgvDichVu;
        private DataGridView dgvMay;
        private DataGridView dgvC79;
        private Button btnExportXML;
        private Button btnLoadXmlFile;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblEMR;
        private ToolStripStatusLabel toolStripStatusLabelSpring;
        private TextBox txtLimit;
        private Label lblPart;
        private Label lblCert;
    }
}
