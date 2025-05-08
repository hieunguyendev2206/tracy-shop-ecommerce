# Tracy Shop - Nền tảng Thương mại điện tử

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-5.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/5.0)
[![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-5.0-brightgreen.svg)](https://docs.microsoft.com/en-us/ef/core/)
[![License](https://img.shields.io/github/license/yourusername/tracy-shop-ecommerce)](LICENSE)

Tracy Shop là một ứng dụng thương mại điện tử toàn diện được xây dựng trên nền tảng ASP.NET Core 5.0, cung cấp trải nghiệm mua sắm trực tuyến đầy đủ tính năng và thân thiện với người dùng.

## Tính năng chính

- **Xác thực và ủy quyền người dùng**: Đăng nhập, đăng ký, đăng nhập bằng Google/Facebook, xác thực email
- **Quản lý sản phẩm**: Danh mục, thông tin chi tiết sản phẩm, hình ảnh, kích thước, đánh giá
- **Giỏ hàng và thanh toán**: Thêm sản phẩm, quản lý số lượng, thanh toán PayPal
- **Quản lý đơn hàng**: Theo dõi trạng thái đơn hàng, lịch sử mua hàng
- **Trò chuyện trực tiếp**: Hỗ trợ khách hàng qua tính năng chat trực tiếp sử dụng SignalR
- **Quản lý kho hàng**: Theo dõi hàng tồn kho, nhập hàng
- **Giao diện quản trị**: Bảng điều khiển riêng cho quản trị viên và nhân viên
- **Khuyến mãi**: Quản lý chương trình khuyến mãi và giảm giá

## Công nghệ sử dụng

- **Backend**: ASP.NET Core 5.0, Entity Framework Core
- **Frontend**: HTML, CSS, JavaScript, Bootstrap
- **Cơ sở dữ liệu**: Microsoft SQL Server
- **Xác thực**: ASP.NET Core Identity, OAuth (Google, Facebook)
- **Giao tiếp thời gian thực**: SignalR
- **Email**: SMTP, MailKit
- **Thanh toán**: PayPal

## Cài đặt và chạy ứng dụng

### Yêu cầu hệ thống
- .NET 5.0 SDK
- Microsoft SQL Server
- Visual Studio 2019 hoặc cao hơn (khuyến nghị)

### Các bước cài đặt
1. Clone repository:
   ```
   git clone https://github.com/yourusername/tracy-shop-ecommerce.git
   cd tracy-shop-ecommerce
   ```

2. Khôi phục các gói NuGet:
   ```
   dotnet restore
   ```

3. Cập nhật chuỗi kết nối trong file `appsettings.json` với thông tin SQL Server của bạn.

4. Áp dụng migration để tạo cơ sở dữ liệu:
   ```
   dotnet ef database update
   ```

5. Chạy ứng dụng:
   ```
   dotnet run
   ```

## Cấu trúc dự án

- **Areas/**: Phân chia các khu vực chức năng (Admin, User, v.v.)
- **Controllers/**: Xử lý các yêu cầu HTTP
- **Data/**: DbContext và migration
- **EmailTemplate/**: Mẫu email
- **Helpers/**: Các hàm và tiện ích
- **Models/**: Các lớp đối tượng dữ liệu
- **Repository/**: Các repository để truy cập dữ liệu
- **Services/**: Các dịch vụ nghiệp vụ
- **ViewModels/**: Các model cho view
- **Views/**: Giao diện người dùng
- **wwwroot/**: Tài nguyên tĩnh (CSS, JavaScript, hình ảnh)

## Giao diện ứng dụng

### Trang chủ
![Trang chủ](https://github.com/user-attachments/assets/a9949dac-d442-4aa9-a6c9-66b495963c0b)

### Trang cửa hàng
![Trang cửa hàng](https://github.com/user-attachments/assets/b782084d-2909-45c7-9f65-ba3502fe22fb)

### Trang chi tiết sản phẩm
![Trang chi tiết sản phẩm](https://github.com/user-attachments/assets/ce9c3d0b-8c49-4944-9a9f-ab74dd2e9858)

### Trang trò chuyện
![Trang trò chuyện](https://github.com/user-attachments/assets/c3d4de77-21b9-4e08-bf9f-c4a9427c90f0)

### Trang đăng nhập
![Trang đăng nhập](https://github.com/user-attachments/assets/5e6f3cc9-6721-406d-8160-4b3823cb684e)

### Trang đăng ký
![Trang đăng ký](https://github.com/user-attachments/assets/b8645be3-3583-4b49-bd1a-4a10c04754c8)

### Trang giỏ hàng
![Trang giỏ hàng](https://github.com/user-attachments/assets/bfede359-5c1e-4e9b-9eb6-af65a4840a9c)

### Trang hồ sơ
![Trang hồ sơ](https://github.com/user-attachments/assets/8e080720-afcd-46ec-968f-a65ee961a738)

### Trang quản trị viên
![Trang quản trị viên](https://github.com/user-attachments/assets/3b3778bd-4985-4074-8535-c48af2ded976)

### Trang nhân viên
![Trang nhân viên](https://github.com/user-attachments/assets/417324fd-11c2-439d-bcfb-8d399f5fe99b)

## Đóng góp

Các đóng góp được đánh giá cao. Để đóng góp:

1. Fork repository
2. Tạo nhánh tính năng (`git checkout -b feature/amazing-feature`)
3. Commit thay đổi của bạn (`git commit -m 'Add some amazing feature'`)
4. Push lên nhánh (`git push origin feature/amazing-feature`)
5. Mở Pull Request

## Giấy phép

Dự án này được cấp phép theo [Giấy phép MIT](LICENSE).

## Liên hệ

Nếu bạn có bất kỳ câu hỏi hoặc đề xuất nào, vui lòng liên hệ:

- Email: your.email@example.com
- GitHub: [your-username](https://github.com/your-username)
