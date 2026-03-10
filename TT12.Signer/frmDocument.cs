using ClosedXML.Excel;
using System.Collections;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TT12.Signer
{
    public partial class frmDocument : Form
    {
        public frmDocument()
        {
            InitializeComponent();
        }

        private void frmDocument_Load(object sender, EventArgs e)
        {
            LoadCertificatesToComboBox();

            dgvBoPhan.DataSource = new List<DMBOPHANCHUYENMON>();
            dgvNhanLuc.DataSource = new List<DMNHANLUCKBCB>();
            dgvThuoc.DataSource = new List<DMTHUOCMAUCHEPHAMMAU>();
            dgvVatTu.DataSource = new List<DM_TBYT>();
            dgvDichVu.DataSource = new List<DMDICHVUKBCB>();
            dgvMay.DataSource = new List<DM_TBYTTHDV>();
            dgvC79.DataSource = new List<C79_CHITIET>();
        }


        #region BUTTON LOAD EXCEL
        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblStatus.Text = "Đang mở file exccel";
            }));
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel (*.xlsx)|*.xlsx";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string filePath = ofd.FileName;

            Dictionary<Type, IList> buffer = new Dictionary<Type, IList>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var wb = new XLWorkbook(stream))
                {
                    foreach (var ws in wb.Worksheets)
                    {
                        if (ws.LastRowUsed() == null)
                            continue;

                        List<string> headers = new List<string>();
                        int colCount = ws.LastColumnUsed().ColumnNumber();

                        for (int i = 1; i <= colCount; i++)
                            headers.Add(ws.Cell(1, i).GetString().Trim().ToUpper());

                        Type detectedType = DetectType(headers);
                        if (detectedType == null)
                            continue;

                        var list = LoadData(ws, detectedType);

                        if (detectedType == typeof(O79))
                        {
                            list = ((IEnumerable<O79>)list)
                                .Select(x => MapO79ToC79(x))
                                .ToList();

                            detectedType = typeof(C79_CHITIET);
                        }

                        if (list == null || ((IList)list).Count == 0)
                            continue;

                        if (!buffer.ContainsKey(detectedType))
                        {
                            buffer[detectedType] = (IList)list;
                        }
                        else
                        {
                            foreach (var item in (IList)list)
                                buffer[detectedType].Add(item);
                        }
                    }
                }
            }

            foreach (var kv in buffer)
            {
                BindToGrid(kv.Key, kv.Value);
            }

            Invoke(new Action(() =>
            {
                lblStatus.Text = "Ready";
            }));
        }
        #endregion

        #region DETECT TYPE

        private Type DetectType(List<string> headers)
        {
            var map = new Dictionary<Type, List<string>>
    {
        { typeof(O79), GetProps(typeof(O79)) },
        { typeof(C79_CHITIET), GetProps(typeof(C79_CHITIET)) },
        { typeof(DMBOPHANCHUYENMON), GetProps(typeof(DMBOPHANCHUYENMON)) },
        { typeof(DMNHANLUCKBCB), GetProps(typeof(DMNHANLUCKBCB)) },
        { typeof(DM_TBYTTHDV), GetProps(typeof(DM_TBYTTHDV)) },
        { typeof(DMDICHVUKBCB), GetProps(typeof(DMDICHVUKBCB)) },
        { typeof(DMTHUOCMAUCHEPHAMMAU), GetProps(typeof(DMTHUOCMAUCHEPHAMMAU)) },
        { typeof(DM_TBYT), GetProps(typeof(DM_TBYT)) }
    };

            Type bestType = null;
            double bestScore = 0;

            foreach (var kv in map)
            {
                int match = headers.Count(h => kv.Value.Contains(h));
                double score = (double)match / kv.Value.Count;

                if (score > bestScore)
                {
                    bestScore = score;
                    bestType = kv.Key;
                }
            }

            if (bestScore < 0.3) // tối thiểu 30% match
                return null;

            return bestType;
        }
        private C79_CHITIET MapO79ToC79(O79 o)
        {
            var c = new C79_CHITIET();

            foreach (var p in typeof(C79_CHITIET).GetProperties())
            {
                var src = typeof(O79).GetProperty(p.Name);
                if (src != null)
                {
                    try
                    {

                        var val = src.GetValue(o);
                        if (val != null)
                            p.SetValue(c, Convert.ChangeType(val, p.PropertyType));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Source + "\n-----------------------------\n" + ex.StackTrace, ex.Message);
                    }
                }
            }

            // map các trường khác tên
            c.MA_BENH_CHINH = o.MA_BENH;
            c.MA_THE_BHYT = o.MA_THE;

            return c;
        }
        private List<string> GetProps(Type t)
        {
            return t.GetProperties().Select(x => x.Name.ToUpper()).ToList();
        }

        #endregion

        #region LOAD EXCEL

        private object LoadData(IXLWorksheet ws, Type type)
        {
            int rowCount = ws.LastRowUsed().RowNumber();
            int colCount = ws.LastColumnUsed().ColumnNumber();

            Dictionary<int, PropertyInfo> map = new Dictionary<int, PropertyInfo>();

            for (int c = 1; c <= colCount; c++)
            {
                string header = ws.Cell(1, c).GetString().Trim();

                var prop = type.GetProperty(header,
                    BindingFlags.IgnoreCase |
                    BindingFlags.Public |
                    BindingFlags.Instance);

                if (prop != null)
                    map[c] = prop;
            }

            var listType = typeof(List<>).MakeGenericType(type);
            IList list = (IList)Activator.CreateInstance(listType);

            for (int r = 2; r <= rowCount; r++)
            {
                var obj = Activator.CreateInstance(type);

                foreach (var m in map)
                {
                    string val = ws.Cell(r, m.Key).GetValue<string>();

                    if (string.IsNullOrWhiteSpace(val))
                        continue;

                    var prop = m.Value;

                    try
                    {
                        object converted = ConvertValue(val, prop.PropertyType);
                        prop.SetValue(obj, converted);
                    }
                    catch { }
                }

                list.Add(obj);
            }

            return list;
        }

        #endregion

        #region BIND TO GRID

        private void BindToGrid(Type type, object list)
        {
            if (type == typeof(DMBOPHANCHUYENMON))
            {
                dgvBoPhan.DataSource = list;
                tabControl.SelectedTab = tabBoPhan;
                tabBoPhan.Tag = typeof(DMBOPHANCHUYENMON);
            }

            else if (type == typeof(DMNHANLUCKBCB))
            {
                dgvNhanLuc.DataSource = list;
                tabControl.SelectedTab = tabNhanLuc;
                tabNhanLuc.Tag = typeof(DMNHANLUCKBCB);
            }

            else if (type == typeof(DMTHUOCMAUCHEPHAMMAU))
            {
                dgvThuoc.DataSource = list;
                tabControl.SelectedTab = tabThuoc;
                tabThuoc.Tag = typeof(DMTHUOCMAUCHEPHAMMAU);
            }

            else if (type == typeof(DM_TBYT))
            {
                dgvVatTu.DataSource = list;
                tabControl.SelectedTab = tabVatTu;
                tabVatTu.Tag = typeof(DM_TBYT);
            }

            else if (type == typeof(DMDICHVUKBCB))
            {
                dgvDichVu.DataSource = list;
                tabControl.SelectedTab = tabDichVu;
                tabDichVu.Tag = typeof(DMDICHVUKBCB);
            }

            else if (type == typeof(DM_TBYTTHDV))
            {
                dgvMay.DataSource = list;
                tabControl.SelectedTab = tabMay;
                tabMay.Tag = typeof(DM_TBYTTHDV);
            }

            else if (type == typeof(C79_CHITIET))
            {
                dgvC79.DataSource = list;
                tabControl.SelectedTab = tabC79;
                tabC79.Tag = typeof(C79_CHITIET);
            }

            GenerateXmlFromCurrentTab();
        }

        #endregion

        #region TAB CHANGE EVENT

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateXmlFromCurrentTab();
        }

        #endregion

        #region GENERATE XML

        private void GenerateXmlFromCurrentTab()
        {
            object data = null;
            Type type = null;

            if (tabControl.SelectedTab == tabBoPhan)
            {
                data = dgvBoPhan.DataSource;
                type = typeof(DMBOPHANCHUYENMON);
            }

            else if (tabControl.SelectedTab == tabNhanLuc)
            {
                data = dgvNhanLuc.DataSource;
                type = typeof(DMNHANLUCKBCB);
            }

            else if (tabControl.SelectedTab == tabThuoc)
            {
                data = dgvThuoc.DataSource;
                type = typeof(DMTHUOCMAUCHEPHAMMAU);
            }

            else if (tabControl.SelectedTab == tabVatTu)
            {
                data = dgvVatTu.DataSource;
                type = typeof(DM_TBYT);
            }

            else if (tabControl.SelectedTab == tabDichVu)
            {
                data = dgvDichVu.DataSource;
                type = typeof(DMDICHVUKBCB);
            }

            else if (tabControl.SelectedTab == tabMay)
            {
                data = dgvMay.DataSource;
                type = typeof(DM_TBYTTHDV);
            }

            else if (tabControl.SelectedTab == tabC79)
            {
                data = dgvC79.DataSource;
                type = typeof(C79_CHITIET);
            }

            if (data == null)
            {
                txtXml.Text = "";
                return;
            }

            txtXml.Text = BuildXml(type,(IEnumerable)data);
        }

        #endregion


        #region CONVERT VALUE

        private object ConvertValue(string value, Type type)
        {
            if (type == typeof(string))
                return value;

            if (type == typeof(int) || type == typeof(int?))
                return int.TryParse(value, out int i) ? i : 0;

            if (type == typeof(decimal) || type == typeof(decimal?))
                return decimal.TryParse(value, out decimal d) ? d : 0;

            if (type == typeof(double) || type == typeof(double?))
                return double.TryParse(value, out double db) ? db : 0;

            if (type == typeof(DateTime) || type == typeof(DateTime?))
                return DateTime.TryParse(value, out DateTime dt) ? dt : DateTime.MinValue;

            return value;
        }

        #endregion

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblStatus.Text = "Đang xuất Excel...";
            }));
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel (*.xlsx)|*.xlsx";
            sfd.FileName = "DanhMuc.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var wb = new XLWorkbook())
            {
                ExportSheet(wb, "DMBOPHANCHUYENMON", dgvBoPhan, typeof(DMBOPHANCHUYENMON));
                ExportSheet(wb, "DMNHANLUCKBCB", dgvNhanLuc, typeof(DMNHANLUCKBCB));
                ExportSheet(wb, "DMTHUOCMAUCHEPHAMMAU", dgvThuoc, typeof(DMTHUOCMAUCHEPHAMMAU));
                ExportSheet(wb, "DM_TBYT", dgvVatTu, typeof(DM_TBYT));
                ExportSheet(wb, "DMDICHVUKBCB", dgvDichVu, typeof(DMDICHVUKBCB));
                ExportSheet(wb, "DM_TBYTTHDV", dgvMay, typeof(DM_TBYTTHDV));
                ExportSheet(wb, "C79_CHITIET", dgvC79, typeof(C79_CHITIET));

                wb.SaveAs(sfd.FileName);
            }

            MessageBox.Show("Xuất Excel thành công.");

            Invoke(new Action(() =>
            {
                lblStatus.Text = "Ready";
            }));
        }

        private void ExportSheet(XLWorkbook wb, string sheetName, DataGridView dgv, Type type)
        {
            var ws = wb.Worksheets.Add(sheetName);

            var props = type.GetProperties();

            for (int c = 0; c < props.Length; c++)
            {
                ws.Cell(1, c + 1).Value = props[c].Name;
                ws.Cell(1, c + 1).Style.Font.Bold = true;
            }

            int row = 2;

            if (dgv.DataSource != null)
            {
                var list = ((IEnumerable)dgv.DataSource).Cast<object>().ToList();

                foreach (var item in list)
                {
                    for (int c = 0; c < props.Length; c++)
                    {
                        var val = props[c].GetValue(item);
                        ws.Cell(row, c + 1).Value = (string?)val;
                    }

                    row++;
                }
            }

            ws.Columns().AdjustToContents();
        }
        public class VdoLookup
        {
            public string Group { get; set; }
            public string Value { get; set; }     // SerialNumber
            public string Display { get; set; }   // Tên hiển thị trong ComboBox
        }

        private void LoadCertificatesToComboBox()
        {
            var lstSignature = new List<VdoLookup>();

            using (var store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
            {
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                var certs = store.Certificates
                    .Find(X509FindType.FindByTimeValid, DateTime.Now, false)
                    .Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false)
                    .Find(X509FindType.FindByExtension, "2.5.29.15", false); // KeyUsage extension

                foreach (var cert in certs)
                {
                    if (cert.HasPrivateKey)
                    {
                        string displayName = string.IsNullOrWhiteSpace(cert.FriendlyName)
                            ? cert.GetNameInfo(X509NameType.SimpleName, false)  // Subject
                            : cert.FriendlyName;

                        string groupName = cert.GetNameInfo(X509NameType.SimpleName, true); // Issuer

                        lstSignature.Add(new VdoLookup
                        {
                            Group = groupName,
                            Display = groupName + " - [" + cert.SerialNumber + "] " + displayName,
                            Value = cert.SerialNumber,
                        });
                    }
                }

                // Lọc và gán DataSource
                var filteredList = lstSignature
                    .Where(c => !string.IsNullOrEmpty(c.Group) && !c.Group.Contains("localhost", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(c => c.Display)   // tùy chọn: sắp xếp theo tên hiển thị
                    .ToList();
                filteredList.Add (new VdoLookup { Group = "NoSign", Value = "NoSign", Display = "Không ký số" }); // Thêm tùy chọn TEST
                cbbCert.DataSource = filteredList;
                cbbCert.DisplayMember = nameof(VdoLookup.Display);   // ← Quan trọng: hiển thị cột này
                cbbCert.ValueMember = nameof(VdoLookup.Value);     // ← Quan trọng: giá trị thực khi SelectedValue
            } // using sẽ tự động Close() store

            // Optional: chọn item đầu tiên nếu có
            if (cbbCert.Items.Count > 0)
            {
                cbbCert.SelectedIndex = 0;
            }
        }
        private void btnExportXml_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblStatus.Text = (cbbCert.SelectedValue != null && cbbCert.SelectedValue.ToString() == "NoSign")
                    ? "Đang xuất Xml"
                    : "Đang xuất Xml và ký số";
            }));

            if (cbbCert.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn chứng thư số.");
                return;
            }

            string serial = cbbCert.SelectedValue.ToString();

            X509Certificate2 cert = null;

            if (serial != "NoSign")
            {
                cert = GetCertificateBySerial(serial);

                if (cert == null)
                {
                    MessageBox.Show("Không tìm thấy certificate.");
                    return;
                }
            }

            if (tabControl.SelectedTab.Tag == null)
            {
                MessageBox.Show("Không có dữ liệu.");
                return;
            }

            Type type = (Type)tabControl.SelectedTab.Tag;

            IList list = GetCurrentGridData(type);

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML files (*.xml)|*.xml";
            sfd.FileName = tabControl.SelectedTab.Tag+"_"+DateTime.UtcNow.ToString("yyyyMMddHHmmss") + "Z.xml";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportXmlBatch(type, list, sfd.FileName, cert);

                MessageBox.Show("Xuất XML thành công.");
            }

            Invoke(new Action(() =>
            {
                lblStatus.Text = "Ready";
            }));
        }

        #region GET CERT

        private X509Certificate2 GetCertificateBySerial(string serial)
        {
            using (var store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
            {
                store.Open(OpenFlags.ReadOnly);

                foreach (var cert in store.Certificates)
                {
                    if (cert.SerialNumber.Equals(serial, StringComparison.OrdinalIgnoreCase))
                    {
                        return cert;
                    }
                }
            }

            return null;
        }

        #endregion
        #region BUILD XML
        private string BuildXml(Type type, IEnumerable list)
        {
            object root;

            if (type == typeof(C79_CHITIET))
            {
                HSTHC79 r = new HSTHC79();

                r.DS_CHITIET = new DS_CHITIET
                {
                    Items = ((IEnumerable)list).Cast<C79_CHITIET>().ToList()
                };

                root = r;
            }
            else
            {
                HSDanhMuc r = new HSDanhMuc();

                if (type == typeof(DMBOPHANCHUYENMON))
                    r.DanhSachBoPhanChuyenMon = new DanhSachBoPhanChuyenMon
                    {
                        Items = ((IEnumerable)list).Cast<DMBOPHANCHUYENMON>().ToList()
                    };

                else if (type == typeof(DMNHANLUCKBCB))
                    r.DanhSachNhanLuc = new DanhSachNhanLucKBCB
                    {
                        Items = ((IEnumerable)list).Cast<DMNHANLUCKBCB>().ToList()
                    };

                else if (type == typeof(DMTHUOCMAUCHEPHAMMAU))
                    r.DanhSachThuoc = new DanhSachThuoc
                    {
                        Items = ((IEnumerable)list).Cast<DMTHUOCMAUCHEPHAMMAU>().ToList()
                    };

                else if (type == typeof(DM_TBYT))
                    r.DanhSachTBYT = new DanhSachTBYT
                    {
                        Items = ((IEnumerable)list).Cast<DM_TBYT>().ToList()
                    };

                else if (type == typeof(DMDICHVUKBCB))
                    r.DanhSachDichVu = new DanhSachDichVuKBCB
                    {
                        Items = ((IEnumerable)list).Cast<DMDICHVUKBCB>().ToList()
                    };

                else if (type == typeof(DM_TBYTTHDV))
                    r.DanhSachTBYTTHDV = new DanhSachTBYTTHDV
                    {
                        Items = ((IEnumerable)list).Cast<DM_TBYTTHDV>().ToList()
                    };

                root = r;
            }

            XmlSerializer xs = new XmlSerializer(root.GetType());

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            string xml;

            using (var sw = new Utf8StringWriter())
            {
                xs.Serialize(sw, root, ns);
                xml = sw.ToString();
            }

            XmlDocument? doc = new XmlDocument();
            doc.LoadXml(xml);

            if (doc.DocumentElement == null)
                throw new Exception("Lỗi tạo XML: không có phần tử gốc.");

            XmlElement? dsNode = doc.DocumentElement
                .ChildNodes
                .OfType<XmlElement>()
                .FirstOrDefault(x => x.Name == "DANHSACH_DMBOPHANCHUYENMON"
                                    || x.Name == "DANHSACH_DMNHANLUCKBCB"
                                    || x.Name == "DANHSACH_DMTHUOCMAUCHEPHAMMAU"
                                    || x.Name == "DSACH_TBYT"
                                    || x.Name == "DANHSACH_DMDICHVUKBCB"
                                    || x.Name == "DSACH_TBYTTHDV"
                                    || x.Name == "DS_CHITIET");

            if (dsNode != null && !dsNode.HasAttribute("Id"))
            {
                string id = dsNode.Name.Replace("DANHSACH_", "") +
                            "-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                dsNode.SetAttribute("Id", id);
            }

            foreach (XmlNode node in doc.SelectNodes("//*"))
            {
                if (node is XmlElement el && !el.HasChildNodes)
                    el.InnerText = "";
            }

            return doc.OuterXml;
        }
        private void ExportXmlBatch(Type type, IList list, string filePath, X509Certificate2 cert)
        {
            int batchSize = 2000;
            int.TryParse(txtLimit.Text, out batchSize);

            var batches = SplitBatch(list.Cast<object>().ToList(), batchSize);

            string folder = Path.GetDirectoryName(filePath);
            string name = Path.GetFileNameWithoutExtension(filePath);

            int index = 1;

            foreach (var batch in batches)
            {
                string xml = BuildXml(type, batch);

                if (cert != null)
                {
                    xml = SignXml(xml, cert);
                }

                string path = Path.Combine(folder, $"{name}_{index}.xml");

                File.WriteAllText(path, xml, Encoding.UTF8);

                index++;
            }
        }
        public static List<List<T>> SplitBatch<T>(IList<T> source, int size)
        {
            List<List<T>> result = new List<List<T>>();

            for (int i = 0; i < source.Count; i += size)
            {
                result.Add(source.Skip(i).Take(size).ToList());
            }

            return result;
        }
        private IList GetCurrentGridData(Type type)
        {
            var grid = tabControl.SelectedTab.Controls
                .OfType<DataGridView>()
                .FirstOrDefault();

            if (grid == null)
                return null;

            List<object> selected = new List<object>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow)
                    continue;

                bool isChecked = false;

                if (grid.Columns.Contains("colSelected"))
                {
                    var val = row.Cells["colSelected"].Value;
                    if (val != null)
                        bool.TryParse(val.ToString(), out isChecked);
                }

                if (isChecked)
                {
                    selected.Add(row.DataBoundItem);
                }
            }

            // nếu không có dòng nào được chọn → lấy tất cả
            if (selected.Count == 0)
            {
                var data = grid.DataSource as IEnumerable;

                if (data == null)
                    return null;

                return data.Cast<object>().ToList();
            }

            return selected;
        }
        #endregion
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
        #region SIGN XML
        private string SignXml(string xml, X509Certificate2 cert)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(xml);

            XmlElement? root = doc.DocumentElement;

            if (root == null)
            {
                throw new Exception("Xml không hợp lệ");
            }
            // tìm node DANHSACH_*
            XmlElement? dataNode = root
                .ChildNodes
                .OfType<XmlElement>()
                .FirstOrDefault(x => x.Name == "DANHSACH_DMBOPHANCHUYENMON"
                                    || x.Name == "DANHSACH_DMNHANLUCKBCB"
                                    || x.Name == "DANHSACH_DMTHUOCMAUCHEPHAMMAU"
                                    || x.Name == "DSACH_TBYT"
                                    || x.Name == "DANHSACH_DMDICHVUKBCB"
                                    || x.Name == "DSACH_TBYTTHDV"
                                    || x.Name == "DS_CHITIET");

            if (dataNode == null)
                throw new Exception("Không tìm thấy DANHSACH");

            string dataId = dataNode.GetAttribute("Id");

            SignedXml signedXml = new SignedXml(doc);
            signedXml.SigningKey = cert.GetRSAPrivateKey();

            signedXml.SignedInfo.CanonicalizationMethod =
                SignedXml.XmlDsigExcC14NTransformUrl;

            signedXml.SignedInfo.SignatureMethod =
                SignedXml.XmlDsigRSASHA256Url;

            System.Security.Cryptography.Xml.Reference reference = new System.Security.Cryptography.Xml.Reference();
            reference.Uri = "#" + dataId;
            reference.DigestMethod = SignedXml.XmlDsigSHA256Url;

            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigExcC14NTransform());

            signedXml.AddReference(reference);

            System.Security.Cryptography.Xml.KeyInfo keyInfo = new System.Security.Cryptography.Xml.KeyInfo();

            KeyInfoX509Data x509Data = new KeyInfoX509Data(cert);
            x509Data.AddSubjectName(cert.Subject);
            x509Data.AddCertificate(cert);

            keyInfo.AddClause(x509Data);

            signedXml.KeyInfo = keyInfo;

            signedXml.ComputeSignature();

            XmlElement signature = signedXml.GetXml();

            // Signature Id theo chuẩn hệ thống
            signature.SetAttribute("Id", "CHUKYDONVI-" + dataId);

            XmlElement chuKy = doc.CreateElement("CHUKYDONVI");

            chuKy.AppendChild(doc.ImportNode(signature, true));

            root.AppendChild(chuKy);

            return doc.OuterXml;
        }
        #endregion
        private void btnLoadXmlFile_Click(object sender, EventArgs e)
        {

            Invoke(new Action(() =>
            {
                lblStatus.Text = "Đang mở file xml";
            }));
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML files (*.xml)|*.xml";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string file = ofd.FileName;

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(file);

            // kiểm tra chữ ký nếu có
            var sigNodes = doc.GetElementsByTagName("Signature");
            if (sigNodes.Count > 0)
            {
                SignedXml sx = new SignedXml(doc);
                sx.LoadXml((XmlElement)sigNodes[0]);
                if (!sx.CheckSignature())
                {
                    MessageBox.Show("Chữ ký XML không hợp lệ");
                    //return; vẫn lấy dữ liệu dù chữ ký không hợp lệ
                }
                else
                {
                    MessageBox.Show("Chữ ký XML hợp lệ");
                }
            }
            txtXml.Text = doc.OuterXml;

            XDocument xdoc = XDocument.Load(file);


            string typeName = "";

            XElement? dsNode = null;
            if (xdoc.Root.Elements().Any(x => x.Name.LocalName == "DANHSACH_DMBOPHANCHUYENMON"))
            {
                typeName = "DMBOPHANCHUYENMON";
                dsNode = xdoc.Root.Elements()
                .FirstOrDefault(x => x.Name.LocalName == "DANHSACH_DMBOPHANCHUYENMON");
            }
            else if (xdoc.Root.Elements().Any(x => x.Name.LocalName == "DANHSACH_DMNHANLUCKBCB"))
            {
                typeName = "DMNHANLUCKBCB";
                dsNode = xdoc.Root.Elements()
                .FirstOrDefault(x => x.Name.LocalName == "DANHSACH_DMNHANLUCKBCB");
            }
            else if (xdoc.Root.Elements().Any(x => x.Name.LocalName == "DANHSACH_DMTHUOCMAUCHEPHAMMAU"))
            {
                typeName = "DMTHUOCMAUCHEPHAMMAU";
                dsNode = xdoc.Root.Elements()
                .FirstOrDefault(x => x.Name.LocalName == "DANHSACH_DMTHUOCMAUCHEPHAMMAU");
            }
            else if (xdoc.Root.Elements().Any(x => x.Name.LocalName == "DSACH_TBYT"))
            {
                typeName = "DM_TBYT";
                dsNode = xdoc.Root.Elements()
                .FirstOrDefault(x => x.Name.LocalName == "DSACH_TBYT");
            }
            else if (xdoc.Root.Elements().Any(x => x.Name.LocalName == "DANHSACH_DMDICHVUKBCB"))
            {
                typeName = "DMDICHVUKBCB";
                dsNode = xdoc.Root.Elements()
                .FirstOrDefault(x => x.Name.LocalName == "DANHSACH_DMDICHVUKBCB");
            }
            else if (xdoc.Root.Elements().Any(x => x.Name.LocalName == "DSACH_TBYTTHDV"))
            {
                typeName = "DM_TBYTTHDV";
                dsNode = xdoc.Root.Elements()
                .FirstOrDefault(x => x.Name.LocalName == "DSACH_TBYTTHDV");
            }
            else if (xdoc.Root.Elements().Any(x => x.Name.LocalName == "DS_CHITIET"))
            {
                typeName = "C79_CHITIET";
                dsNode = xdoc.Root.Elements()
                .FirstOrDefault(x => x.Name.LocalName == "DS_CHITIET");
            }

            Type detectedType = Type.GetType(this.GetType().Namespace + "." + typeName);

            if (detectedType == null)
            {
                MessageBox.Show("Không nhận dạng được danh mục");
                return;
            }

            if (dsNode == null)
            {
                MessageBox.Show("Không tìm thấy DANHSACH");
                return;
            }
            var list = dsNode.Elements()
                .Select(x =>
                {
                    object obj = Activator.CreateInstance(detectedType);
                    foreach (var p in detectedType.GetProperties())
                    {
                        try
                        {

                            var el = x.Element(p.Name);
                            if (el != null)
                                p.SetValue(obj, Convert.ChangeType(el.Value, p.PropertyType));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Source + "\n-----------------------------\n" + ex.StackTrace, ex.Message);
                        }
                    }
                    return obj;
                }).ToList();

            if (detectedType == typeof(DMBOPHANCHUYENMON))
            { dgvBoPhan.DataSource = list; tabControl.SelectedTab = tabBoPhan; }
            else if (detectedType == typeof(DMNHANLUCKBCB))
            { dgvNhanLuc.DataSource = list; tabControl.SelectedTab = tabNhanLuc; }
            else if (detectedType == typeof(DMTHUOCMAUCHEPHAMMAU))
            { dgvThuoc.DataSource = list; tabControl.SelectedTab = tabThuoc; }
            else if (detectedType == typeof(DM_TBYT))
            { dgvVatTu.DataSource = list; tabControl.SelectedTab = tabVatTu; }
            else if (detectedType == typeof(DMDICHVUKBCB))
            { dgvDichVu.DataSource = list; tabControl.SelectedTab = tabDichVu; }
            else if (detectedType == typeof(DM_TBYTTHDV))
            { dgvMay.DataSource = list; tabControl.SelectedTab = tabMay; }
            else if (detectedType == typeof(C79_CHITIET))
            { dgvC79.DataSource = list; tabControl.SelectedTab = tabC79; }

            Invoke(new Action(() =>
            {
                lblStatus.Text = "Ready";
            }));
        }

        private void txtXml_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control && e.KeyCode == Keys.C))
            {
                e.Handled = true;
            }
        }

        private void txtXml_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtXml_KeyUp(object sender, KeyEventArgs e)
        {

            if (!(e.Control && e.KeyCode == Keys.C))
            {
                e.Handled = true;
            }
        }

        private void Shared_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Ép kiểu sender về DataGridView
            if (sender is DataGridView dgv)
            {
                string colName = "colSelected";

                if (!dgv.Columns.Contains(colName))
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = "";
                    checkBoxColumn.Name = colName;
                    checkBoxColumn.Width = 30;

                    dgv.Columns.Insert(0, checkBoxColumn);

                }
            }
        }

    }
}
