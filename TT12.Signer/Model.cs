using System;
using System.Collections.Generic;
using System.Text;
    using System.Xml.Serialization;

namespace TT12.Signer
{

    #region ROOT COMMON

    [XmlRoot("HSDANHMUC")]
    public class HSDanhMuc
    {
        [XmlElement("DANHSACH_DMBOPHANCHUYENMON")]
        public DanhSachBoPhanChuyenMon DanhSachBoPhanChuyenMon { get; set; }

        [XmlElement("DANHSACH_DMNHANLUCKBCB")]
        public DanhSachNhanLucKBCB DanhSachNhanLuc { get; set; }

        [XmlElement("DANHSACH_DMTHUOCMAUCHEPHAMMAU")]
        public DanhSachThuoc DanhSachThuoc { get; set; }

        [XmlElement("DSACH_TBYT")]
        public DanhSachTBYT DanhSachTBYT { get; set; }

        [XmlElement("DANHSACH_DMDICHVUKBCB")]
        public DanhSachDichVuKBCB DanhSachDichVu { get; set; }

        [XmlElement("DSACH_TBYTTHDV")]
        public DanhSachTBYTTHDV DanhSachTBYTTHDV { get; set; }

        [XmlElement("CHUKYDONVI")]
        public ChuKyDonVi ChuKyDonVi { get; set; }
    }

    #endregion

    #region MAU 01 - BO PHAN CHUYEN MON

    public class DanhSachBoPhanChuyenMon
    {
        [XmlElement("DMBOPHANCHUYENMON")]
        public List<DMBOPHANCHUYENMON> Items { get; set; } = new();
    }

    public class DMBOPHANCHUYENMON
    {
        public int STT { get; set; }
        public string MA_KHOA { get; set; } = string.Empty;
        public string TEN_KHOA { get; set; } = string.Empty;
        public int BAN_KHAM { get; set; }
        public int GIUONG_PD { get; set; }
        public int GIUONG_TK { get; set; }
        public int GIUONG_HSTC { get; set; }
        public int GIUONG_HSCC { get; set; }
        public string TU_NGAY { get; set; } = string.Empty;
        public string? DEN_NGAY { get; set; } = string.Empty;
        public string MA_CSKCB { get; set; } = string.Empty;
    }

    #endregion

    #region MAU 02 - NHAN LUC

    public class DanhSachNhanLucKBCB
    {
        [XmlElement("DMNHANLUCKBCB")]
        public List<DMNHANLUCKBCB> Items { get; set; } = new();
    }

    public class DMNHANLUCKBCB
    {
        public int STT { get; set; }
        public string MA_KHOA { get; set; } = string.Empty;
        public string TEN_KHOA { get; set; } = string.Empty;
        public string HO_TEN { get; set; } = string.Empty;
        public string GIOI_TINH { get; set; } = string.Empty;
        public string SO_DINH_DANH { get; set; } = string.Empty;
        public string CHUCDANH_NN { get; set; } = string.Empty;
        public string VI_TRI { get; set; } = string.Empty;
        public string MACCHN { get; set; } = string.Empty;
        public string NGAYCAP_CCHN { get; set; } = string.Empty;
        public string NOICAP_CCHN { get; set; } = string.Empty;
        public string PHAMVI_CM { get; set; } = string.Empty;
        public string PHAMVI_CMBS { get; set; } = string.Empty;
        public string DVKT_KHAC { get; set; } = string.Empty;
        public string VB_PHANCONG { get; set; } = string.Empty;
        public string THOIGIAN_DK { get; set; } = string.Empty;
        public string THOIGIAN_TUAN { get; set; } = string.Empty;
        public string THOIGIAN_NGAY { get; set; } = string.Empty;
        public string CSKCB_KHAC { get; set; } = string.Empty;
        public string CSKCB_CGKT { get; set; } = string.Empty;
        public string QD_CGKT { get; set; } = string.Empty;
        public string TU_NGAY { get; set; } = string.Empty;
        public string DEN_NGAY { get; set; } = string.Empty;
        public string MA_CSKCB { get; set; } = string.Empty;
    }

    #endregion

    #region MAU 03 - THUOC

    public class DanhSachThuoc
    {
        [XmlElement("DMTHUOCMAUCHEPHAMMAU")]
        public List<DMTHUOCMAUCHEPHAMMAU> Items { get; set; } = new();
    }

    public class DMTHUOCMAUCHEPHAMMAU
    {
        public int STT { get; set; }
        public string MA_THUOC { get; set; } = string.Empty;
        public string TEN_HOAT_CHAT { get; set; } = string.Empty;
        public string TEN_THUOC { get; set; } = string.Empty;
        public string DON_VI_TINH { get; set; } = string.Empty;
        public string HAM_LUONG { get; set; } = string.Empty;
        public string DUONG_DUNG { get; set; } = string.Empty;
        public string MA_DUONG_DUNG { get; set; } = string.Empty;
        public string DANG_BAO_CHE { get; set; } = string.Empty;
        public string SO_DANG_KY { get; set; } = string.Empty;
        public int SO_LUONG { get; set; }
        public decimal DON_GIA { get; set; }
        public decimal DON_GIA_BH { get; set; } 
        public string QUY_CACH { get; set; } = string.Empty;
        public string NHA_SX { get; set; } = string.Empty;
        public string NUOC_SX { get; set; } = string.Empty;
        public string NHA_THAU { get; set; } = string.Empty;
        public string TT_THAU { get; set; } = string.Empty;
        public string TU_NGAY_HD { get; set; } = string.Empty;
        public string DEN_NGAY_HD { get; set; } = string.Empty;
        public string MA_CSKCB { get; set; } = string.Empty;
        public string LOAI_THUOC { get; set; } = string.Empty;
        public string LOAI_THAU { get; set; } = string.Empty;
        public string HT_THAU { get; set; } = string.Empty;
        public string MA_DVKT { get; set; } = string.Empty;
        public string TCCL { get; set; } = string.Empty;
        public string BO_PHAN_VT { get; set; } = string.Empty;
        public string TEN_KHOA_HOC { get; set; } = string.Empty;
        public string NGUON_GOC { get; set; } = string.Empty;
        public string PP_CHEBIEN { get; set; } = string.Empty;
        public string MA_DL_NHAP { get; set; } = string.Empty;
        public string MA_DL_CB { get; set; } = string.Empty;
        public decimal TLHH_CB { get; set; }
        public decimal TLHH_BQ { get; set; }
        public string MA_CSKCB_THUOC { get; set; } = string.Empty;
        public string TU_NGAY { get; set; } = string.Empty;
        public string DEN_NGAY { get; set; } = string.Empty;
    }

    #endregion

    #region MAU 04 - VAT TU Y TE

    public class DanhSachTBYT
    {
        [XmlElement("DM_TBYT")]
        public List<DM_TBYT> Items { get; set; } = new();
    }

    public class DM_TBYT
    {
        public int STT { get; set; }
        public string MA_VAT_TU { get; set; } = string.Empty;
        public string NHOM_VAT_TU { get; set; } = string.Empty;
        public string TEN_VAT_TU { get; set; } = string.Empty;
        public string MA_HIEU { get; set; } = string.Empty;
        public string SO_LUU_HANH { get; set; } = string.Empty;
        public string TINHNANG_KT { get; set; } = string.Empty;
        public string QUY_CACH { get; set; } = string.Empty;
        public string HANG_SX { get; set; } = string.Empty;
        public string NUOC_SX { get; set; } = string.Empty;
        public string DON_VI_TINH { get; set; } = string.Empty;
        public decimal DON_GIA { get; set; }
        public decimal DON_GIA_BH { get; set; }
        public decimal TYLE_TT_BH { get; set; }
        public int SO_LUONG { get; set; }
        public string DINH_MUC { get; set; } = string.Empty;
        public string NHA_THAU { get; set; } = string.Empty;
        public string TT_THAU { get; set; } = string.Empty;
        public string TU_NGAY_HD { get; set; } = string.Empty;
        public string DEN_NGAY_HD { get; set; } = string.Empty;
        public string MA_CSKCB { get; set; } = string.Empty;
        public string LOAI_THAU { get; set; } = string.Empty;
        public string HT_THAU { get; set; } = string.Empty;
        public string MA_CSKCB_TBYT { get; set; } = string.Empty;
        public string TU_NGAY { get; set; } = string.Empty;
        public string DEN_NGAY { get; set; } = string.Empty;
    }

    #endregion

    #region MAU 05 - DICH VU

    public class DanhSachDichVuKBCB
    {
        [XmlElement("DMDICHVUKBCB")]
        public List<DMDICHVUKBCB> Items { get; set; } = new();
    }

    public class DMDICHVUKBCB
    {
        public int STT { get; set; }
        public string MA_DICH_VU { get; set; } = string.Empty;
        public string TEN_DICH_VU { get; set; } = string.Empty;
        public string TEN_DVKT_GIA { get; set; } = string.Empty;
        public decimal DON_GIA { get; set; }
        public string QUY_TRINH { get; set; } = string.Empty;
        public int SO_LUONG_CGKT { get; set; }
        public string CSKCB_CGKT { get; set; } = string.Empty;
        public string CSKCB_CLS { get; set; } = string.Empty;
        public string QD_DVKT { get; set; } = string.Empty;
        public string QD_PD_GIA { get; set; } = string.Empty;
        public string GHI_CHU { get; set; } = string.Empty;
        public string TU_NGAY { get; set; } = string.Empty;
        public string DEN_NGAY { get; set; } = string.Empty;
        public string MA_CSKCB { get; set; } = string.Empty;
        public decimal GIA_THANH_TOAN { get; set; }

        [XmlArray("DS_THUOCPX")]
        [XmlArrayItem("TT_THUOCPX")]
        public List<TT_THUOCPX> ThuocPhu { get; set; } = new();
    }

    public class TT_THUOCPX
    {
        public int STT { get; set; }
        public string MA_THUOC { get; set; } = string.Empty;
        public string TEN_THUOC { get; set; } = string.Empty;
        public string SO_DANG_KY { get; set; } = string.Empty;
        public string DON_VI_TINH { get; set; } = string.Empty;
        public string TT_THAU { get; set; } = string.Empty;
        public decimal DON_GIA_THUOC { get; set; }
        public string DM_NSX_CDD { get; set; } = string.Empty;
        public string DM_THUCTE_CDD { get; set; } = string.Empty;
        public decimal LIEU_BQ_PX { get; set; }
        public decimal TL_THUCTE_BQ_PX { get; set; }
        public decimal THANH_TIEN_THUOC { get; set; }
    }

    #endregion

    #region MAU 06 - THIET BI THUC HIEN DV

    public class DanhSachTBYTTHDV
    {
        [XmlElement("DM_TBYTTHDV")]
        public List<DM_TBYTTHDV> Items { get; set; } = new();
    }

    public class DM_TBYTTHDV
    {
        public int STT { get; set; }
        public string TEN_TB { get; set; } = string.Empty;
        public string KY_HIEU { get; set; } = string.Empty;
        public string CONGTY_SX { get; set; } = string.Empty;
        public string NUOC_SX { get; set; } = string.Empty;
        public int NAM_SX { get; set; }
        public int NAM_SD { get; set; }
        public string MA_MAY { get; set; } = string.Empty;
        public string SO_LUU_HANH { get; set; } = string.Empty;
        public string HD_TU { get; set; } = string.Empty;
        public string HD_DEN { get; set; } = string.Empty;
        public string TU_NGAY { get; set; } = string.Empty;
        public string DEN_NGAY { get; set; } = string.Empty;
        public string MA_CSKCB { get; set; } = string.Empty;
    }

    #endregion

    #region MAU 01_BH - C79

    [XmlRoot("HSTHC79")]
    public class HSTHC79
    {
        [XmlElement("DS_CHITIET")]
        public DS_CHITIET DS_CHITIET { get; set; }

        [XmlElement("CHUKYDONVI")]
        public ChuKyDonVi ChuKyDonVi { get; set; }
    }

    public class DS_CHITIET
    {
        [XmlElement("C79_CHITIET")]
        public List<C79_CHITIET> Items { get; set; } = new();
    }

    public class C79_CHITIET
    {
        public int STT { get; set; }
        public string HO_TEN { get; set; } = string.Empty;
        public string NGAY_SINH { get; set; } = string.Empty;
        public string GIOI_TINH { get; set; } = string.Empty;
        public string MA_THE_BHYT { get; set; } = string.Empty;
        public string MA_BENH_CHINH { get; set; } = string.Empty;
        public string NGAY_VAO { get; set; } = string.Empty;
        public string NGAY_VAO_NOI_TRU { get; set; } = string.Empty;
        public string NGAY_RA { get; set; } = string.Empty;
        public int SO_NGAY_DTRI { get; set; }
        public string MA_LOAI_KCB { get; set; } = string.Empty;
        public decimal T_TONGCHI_BV { get; set; }
        public decimal T_TONGCHI_BH { get; set; }
        public decimal T_BHTT { get; set; }
        public decimal T_BNCCT { get; set; }
        public decimal T_BNTT { get; set; }
        public decimal T_NGUONKHAC { get; set; }
        public string MA_CSKCB { get; set; } = string.Empty;
        public int NAM_QT { get; set; }
        public int THANG_QT { get; set; }
    }
    public class O79
    {
        public string STT { get; set; }
        public string MA_BN { get; set; }
        public string HO_TEN { get; set; }
        public string NGAY_SINH { get; set; }
        public string GIOI_TINH { get; set; }
        public string DIA_CHI { get; set; }
        public string MA_THE { get; set; }
        public string MA_DKBD { get; set; }
        public string GT_THE_TU { get; set; }
        public string GT_THE_DEN { get; set; }
        public string MA_BENH { get; set; }
        public string MA_BENHKHAC { get; set; }
        public string MA_LYDO_VVIEN { get; set; }
        public string MA_NOI_CHUYEN { get; set; }
        public string NGAY_VAO { get; set; }
        public string NGAY_RA { get; set; }
        public string SO_NGAY_DTRI { get; set; }
        public string KET_QUA_DTRI { get; set; }
        public string TINH_TRANG_RV { get; set; }
        public string T_TONGCHI { get; set; }
        public string T_XN { get; set; }
        public string T_CDHA { get; set; }
        public string T_THUOC { get; set; }
        public string T_MAU { get; set; }
        public string T_PTTT { get; set; }
        public string T_VTYT { get; set; }
        public string T_DVKT_TYLE { get; set; }
        public string T_THUOC_TYLE { get; set; }
        public string T_VTYT_TYLE { get; set; }
        public string T_KHAM { get; set; }
        public string T_GIUONG { get; set; }
        public string T_VCHUYEN { get; set; }
        public string T_BNTT { get; set; }
        public string T_BHTT { get; set; }
        public string T_NGOAIDS { get; set; }
        public string MA_KHOA { get; set; }
        public string NAM_QT { get; set; }
        public string THANG_QT { get; set; }
        public string MA_KHUVUC { get; set; }
        public string MA_LOAIKCB { get; set; }
        public string MA_CSKCB { get; set; }
        public string T_NGUONKHAC { get; set; }
    }
    #endregion

    #region DIGITAL SIGNATURE

    public class ChuKyDonVi
    {
        [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public XmlSignature Signature { get; set; }
    }

    public class XmlSignature
    {
        public SignedInfo SignedInfo { get; set; }
        public string SignatureValue { get; set; }
        public KeyInfo KeyInfo { get; set; }
    }

    public class SignedInfo
    {
        public CanonicalizationMethod CanonicalizationMethod { get; set; }
        public SignatureMethod SignatureMethod { get; set; }

        [XmlElement("Reference")]
        public List<Reference> References { get; set; }
    }

    public class CanonicalizationMethod
    {
        [XmlAttribute]
        public string Algorithm { get; set; }
    }

    public class SignatureMethod
    {
        [XmlAttribute]
        public string Algorithm { get; set; }
    }

    public class Reference
    {
        [XmlAttribute]
        public string URI { get; set; }

        public DigestMethod DigestMethod { get; set; }
        public string DigestValue { get; set; }
    }

    public class DigestMethod
    {
        [XmlAttribute]
        public string Algorithm { get; set; }
    }

    public class KeyInfo
    {
        public X509Data X509Data { get; set; }
    }

    public class X509Data
    {
        public string X509SubjectName { get; set; }
        public string X509Certificate { get; set; }
    }

#endregion

}
