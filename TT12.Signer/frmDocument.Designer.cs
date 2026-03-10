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
            tabControl.Size = new Size(800, 242);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabBoPhan
            // 
            tabBoPhan.Controls.Add(dgvBoPhan);
            tabBoPhan.Location = new Point(4, 24);
            tabBoPhan.Name = "tabBoPhan";
            tabBoPhan.Padding = new Padding(3);
            tabBoPhan.Size = new Size(792, 214);
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
            dgvBoPhan.Size = new Size(786, 208);
            dgvBoPhan.TabIndex = 0;
            // 
            // tabNhanLuc
            // 
            tabNhanLuc.Controls.Add(dgvNhanLuc);
            tabNhanLuc.Location = new Point(4, 24);
            tabNhanLuc.Name = "tabNhanLuc";
            tabNhanLuc.Padding = new Padding(3);
            tabNhanLuc.Size = new Size(792, 214);
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
            dgvNhanLuc.Size = new Size(786, 208);
            dgvNhanLuc.TabIndex = 1;
            // 
            // tabThuoc
            // 
            tabThuoc.Controls.Add(dgvThuoc);
            tabThuoc.Location = new Point(4, 24);
            tabThuoc.Name = "tabThuoc";
            tabThuoc.Padding = new Padding(3);
            tabThuoc.Size = new Size(792, 214);
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
            dgvThuoc.Size = new Size(786, 208);
            dgvThuoc.TabIndex = 1;
            // 
            // tabVatTu
            // 
            tabVatTu.Controls.Add(dgvVatTu);
            tabVatTu.Location = new Point(4, 24);
            tabVatTu.Name = "tabVatTu";
            tabVatTu.Padding = new Padding(3);
            tabVatTu.Size = new Size(792, 214);
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
            dgvVatTu.Size = new Size(786, 208);
            dgvVatTu.TabIndex = 1;
            // 
            // tabDichVu
            // 
            tabDichVu.Controls.Add(dgvDichVu);
            tabDichVu.Location = new Point(4, 24);
            tabDichVu.Name = "tabDichVu";
            tabDichVu.Padding = new Padding(3);
            tabDichVu.Size = new Size(792, 214);
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
            dgvDichVu.Size = new Size(786, 208);
            dgvDichVu.TabIndex = 1;
            // 
            // tabMay
            // 
            tabMay.Controls.Add(dgvMay);
            tabMay.Location = new Point(4, 24);
            tabMay.Name = "tabMay";
            tabMay.Padding = new Padding(3);
            tabMay.Size = new Size(792, 214);
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
            dgvMay.Size = new Size(786, 208);
            dgvMay.TabIndex = 1;
            // 
            // tabC79
            // 
            tabC79.Controls.Add(dgvC79);
            tabC79.Location = new Point(4, 24);
            tabC79.Name = "tabC79";
            tabC79.Padding = new Padding(3);
            tabC79.Size = new Size(792, 214);
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
            dgvC79.Size = new Size(786, 208);
            dgvC79.TabIndex = 1;
            // 
            // txtXml
            // 
            txtXml.BackColor = Color.FromArgb(64, 64, 64);
            txtXml.BorderStyle = BorderStyle.None;
            txtXml.Dock = DockStyle.Bottom;
            txtXml.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtXml.ForeColor = SystemColors.Window;
            txtXml.Location = new Point(0, 291);
            txtXml.Multiline = true;
            txtXml.Name = "txtXml";
            txtXml.Size = new Size(800, 137);
            txtXml.TabIndex = 0;
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
            btnLoadExcel.Text = "Load Excel";
            btnLoadExcel.UseVisualStyleBackColor = true;
            btnLoadExcel.Click += btnLoadExcel_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(12, 12);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(89, 31);
            btnExportExcel.TabIndex = 1;
            btnExportExcel.Text = "Export Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // cbbCert
            // 
            cbbCert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbbCert.FormattingEnabled = true;
            cbbCert.Location = new Point(202, 17);
            cbbCert.Name = "cbbCert";
            cbbCert.Size = new Size(396, 23);
            cbbCert.TabIndex = 2;
            // 
            // btnExportXML
            // 
            btnExportXML.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportXML.Location = new Point(604, 12);
            btnExportXML.Name = "btnExportXML";
            btnExportXML.Size = new Size(89, 31);
            btnExportXML.TabIndex = 1;
            btnExportXML.Text = "Export XML";
            btnExportXML.UseVisualStyleBackColor = true;
            btnExportXML.Click += btnExportXml_Click;
            // 
            // btnLoadXmlFile
            // 
            btnLoadXmlFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoadXmlFile.Location = new Point(699, 12);
            btnLoadXmlFile.Name = "btnLoadXmlFile";
            btnLoadXmlFile.Size = new Size(89, 31);
            btnLoadXmlFile.TabIndex = 1;
            btnLoadXmlFile.Text = "Load Xml";
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
            // frmDocument
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
