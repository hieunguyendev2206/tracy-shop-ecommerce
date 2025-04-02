using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TracyShop.Models;

namespace TracyShop.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Address> Address { set; get; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Size> Sizes { set; get; }
        public DbSet<ProductSize> ProductSize { set; get; }
        public DbSet<Promotion> Promotion { get; set; }

        public DbSet<Cart> Carts { set; get; }

        //public DbSet<UserRole> UserRole { set; get; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<PaymentMenthod> PaymentMenthod { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetail { set; get; }
        public DbSet<StockReceivedDetail> StockReceivedDetail { set; get; }
        public DbSet<StockReceived> StockReceived { set; get; }
        public DbSet<Message> Messages { set; get; }
        public DbSet<Chat> Chats { set; get; }
        public DbSet<ResponseMessage> ResponseMessages { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>().HasIndex(a => a.UserId).IsUnique();
            builder.Entity<ProductSize>().HasKey(ps => new { ps.ProductId, ps.SizeId });

            builder.Entity<ProductSize>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(ps => ps.ProductId);


            builder.Entity<ProductSize>()
                .HasOne(ps => ps.Size)
                .WithMany(s => s.ProductSizes)
                .HasForeignKey(ps => ps.SizeId);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Product>()
                .HasOne(p => p.Promotion)
                .WithMany(pm => pm.Products)
                .HasForeignKey(p => p.PromotionId);

            builder.Entity<Image>()
                .HasOne(p => p.Product)
                .WithMany(i => i.Images)
                .HasForeignKey(p => p.ProductId);

            builder.Entity<Address>()
                .HasOne(u => u.User)
                .WithMany(a => a.Addresses)
                .HasForeignKey(u => u.UserId);

            builder.Entity<Cart>()
                .HasOne(p => p.Product)
                .WithMany(c => c.Carts)
                .HasForeignKey(p => p.ProductId);

            builder.Entity<Cart>()
                .HasOne(p => p.User)
                .WithMany(c => c.Carts)
                .HasForeignKey(p => p.UserId);

            builder.Entity<Order>()
                .HasOne(p => p.PaymentMenthod)
                .WithMany(o => o.Orders)
                .HasForeignKey(p => p.PaymentMenthodId);

            builder.Entity<Order>()
                .HasOne(u => u.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(u => u.UserId);

            builder.Entity<OrderDetail>()
                .HasOne(p => p.Product)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(p => p.ProductId);

            builder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            builder.Entity<Reviews>()
                .HasOne(p => p.Product)
                .WithMany(r => r.Reviews)
                .HasForeignKey(p => p.ProductId);

            builder.Entity<Reviews>()
                .HasOne(u => u.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(u => u.UserId);

            builder.Entity<StockReceived>()
                .HasOne(u => u.User)
                .WithMany(s => s.StockReceiveds)
                .HasForeignKey(u => u.UserId);

            builder.Entity<StockReceivedDetail>()
                .HasOne(p => p.Product)
                .WithMany(s => s.StockReceivedDetails)
                .HasForeignKey(p => p.ProductId);

            builder.Entity<StockReceivedDetail>()
                .HasOne(s => s.StockReceived)
                .WithMany(r => r.StockReceivedDetails)
                .HasForeignKey(s => s.StockReceivedId);

            builder.Entity<Chat>()
                .HasOne(c => c.User)
                .WithMany(u => u.Chats)
                .HasForeignKey(c => c.UserId);

            builder.Entity<Chat>()
                .HasOne(c => c.Message)
                .WithMany(m => m.Chats)
                .HasForeignKey(c => c.MessageId);

            builder.Entity<ResponseMessage>()
                .HasOne(r => r.Chat)
                .WithMany(c => c.ResponseMessages)
                .HasForeignKey(r => r.ChatId);


            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet")) entityType.SetTableName(tableName.Substring(6));
            }
        }
    }
}