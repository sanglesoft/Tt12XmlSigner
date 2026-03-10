# TT12.Signer

Ứng dụng Windows Forms hỗ trợ nhập, xuất và ký số dữ liệu theo chuẩn XML quy định tại **Thông tư số 12/2026/TT-BTC của Bộ Tài chính**:  
Quy định trình tự, thủ tục giám định chi phí khám bệnh, chữa bệnh bảo hiểm y tế, biểu mẫu tổng hợp thanh toán, quyết toán và biện pháp thi hành **Nghị định số 188/2025/NĐ-CP ngày 01/07/2025 của Chính phủ**.

---
<img width="802" height="482" alt="image" src="https://github.com/user-attachments/assets/c90b8cf4-8fe4-4148-bde3-2eb80890bfcb" />
---

## ✨ Tính năng chính

- **Nhập dữ liệu từ Excel (.xlsx)**  
  - Sử dụng thư viện [ClosedXML](https://github.com/ClosedXML/ClosedXML).  
  - Tự động nhận diện loại dữ liệu dựa trên tiêu đề cột.  
  - Hỗ trợ nhiều danh mục:  
    - `DMBOPHANCHUYENMON`  
    - `DMNHANLUCKBCB`  
    - `DMTHUOCMAUCHEPHAMMAU`  
    - `DM_TBYT`  
    - `DMDICHVUKBCB`  
    - `DM_TBYTTHDV`  
    - `C79_CHITIET` (bao gồm chuyển đổi từ Mẫu Excel `79A, 80A`).

- **Xuất dữ liệu ra Excel (.xlsx)**  
  - Tạo file Excel với nhiều sheet, mỗi sheet tương ứng một danh mục.  
  - Tự động định dạng tiêu đề và điều chỉnh độ rộng cột.

- **Sinh XML theo chuẩn Thông tư 12/2026/TT-BTC**  
  - Tạo XML từ dữ liệu hiện tại trên tab.  
  - Gán thuộc tính `Id` cho node dữ liệu để phục vụ ký số.  
  - Đảm bảo namespace `xsd` và `xsi` theo chuẩn.

- **Ký số XML bằng chứng thư số**  
  - Lấy chứng thư số từ Windows Certificate Store (CurrentUser).  
  - Lọc chứng thư hợp lệ có quyền **Digital Signature**.  
  - Ký XML bằng thuật toán **RSA-SHA256**.  
  - Thêm node `<CHUKYDONVI>` chứa chữ ký vào XML.

- **Nhập XML đã ký**  
  - Kiểm tra chữ ký số nếu có.  
  - Tự động nhận diện loại danh mục từ node gốc.  
  - Chuyển đổi XML thành đối tượng và hiển thị trên lưới dữ liệu.

---

## 🛠 Công nghệ sử dụng

- **Ngôn ngữ:** C# (.NET WinForms)  
- **Thư viện:**  
  - [ClosedXML](https://github.com/ClosedXML/ClosedXML) – xử lý Excel  
  - `System.Security.Cryptography.Xml` – ký số XML  
  - `System.Xml.Serialization` – sinh XML từ đối tượng  

---

## 📂 Cấu trúc chức năng chính

- `btnLoadExcel_Click` → Nhập dữ liệu từ Excel.  
- `btnExportExcel_Click` → Xuất dữ liệu ra Excel.  
- `btnExportXml_Click` → Sinh XML và ký số.  
- `btnLoadXmlFile_Click` → Nhập XML và kiểm tra chữ ký.  
- `DetectType` → Nhận diện loại dữ liệu từ tiêu đề Excel.  
- `BuildXml` → Sinh XML theo chuẩn Thông tư.  
- `SignXml` → Ký số XML bằng chứng thư số.  

---

## 🚀 Cách sử dụng

1. **Nhập Excel**  
   - Nhấn nút **Load Excel**, chọn file `.xlsx`.  
   - Ứng dụng sẽ tự động nhận diện và hiển thị dữ liệu trên tab tương ứng.

2. **Xuất Excel**  
   - Sau khi chỉnh sửa dữ liệu, nhấn **Export Excel** để lưu ra file mới.

3. **Sinh XML & Ký số**  
   - Chọn tab dữ liệu cần xuất.  
   - Nhấn **Export XML**, chọn chứng thư số hợp lệ.  
   - Lưu file XML đã ký.

4. **Nhập XML**  
   - Nhấn **Load XML File**, chọn file `.xml`.  
   - Ứng dụng sẽ kiểm tra chữ ký và hiển thị dữ liệu.

---

## 📜 Ghi chú pháp lý

- Chuẩn XML được xây dựng theo **Thông tư số 12/2026/TT-BTC** của Bộ Tài chính.  
- Phục vụ quy trình giám định chi phí khám chữa bệnh bảo hiểm y tế, tổng hợp thanh toán, quyết toán theo **Nghị định số 188/2025/NĐ-CP**.  
