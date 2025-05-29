namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaiTaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenBaiTap = c.String(nullable: false, maxLength: 100),
                        MoTa = c.String(),
                        VideoUrl = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoTrinh_BaiTap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdLoTrinh = c.Int(nullable: false),
                        IdBaiTap = c.Int(nullable: false),
                        BaiTap_Id = c.Int(),
                        LoTrinh_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaiTaps", t => t.BaiTap_Id)
                .ForeignKey("dbo.LoTrinhs", t => t.LoTrinh_Id)
                .Index(t => t.BaiTap_Id)
                .Index(t => t.LoTrinh_Id);
            
            CreateTable(
                "dbo.LoTrinhs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenLoTrinh = c.String(nullable: false, maxLength: 100),
                        MoTa = c.String(),
                        BMI = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BaiViets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(nullable: false, maxLength: 200),
                        NoiDung = c.String(nullable: false),
                        HinhAnh = c.String(),
                        NgayTao = c.DateTime(nullable: false),
                        IdNguoiDung = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiDungs", t => t.IdNguoiDung)
                .Index(t => t.IdNguoiDung);
            
            CreateTable(
                "dbo.BinhLuans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(nullable: false),
                        NgayTao = c.DateTime(nullable: false),
                        IdBaiViet = c.Int(nullable: false),
                        IdNguoiDung = c.Int(nullable: false),
                        IdBinhLuanCha = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaiViets", t => t.IdBaiViet, cascadeDelete: true)
                .ForeignKey("dbo.BinhLuans", t => t.IdBinhLuanCha)
                .ForeignKey("dbo.NguoiDungs", t => t.IdNguoiDung)
                .Index(t => t.IdBaiViet)
                .Index(t => t.IdNguoiDung)
                .Index(t => t.IdBinhLuanCha);
            
            CreateTable(
                "dbo.NguoiDungs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDangNhap = c.String(nullable: false, maxLength: 100),
                        MatKhau = c.String(nullable: false, maxLength: 100),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        SoDienThoai = c.String(maxLength: 20),
                        NgaySinh = c.DateTime(nullable: false),
                        HinhAnh = c.String(),
                        IdPhanQuyen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhanQuyens", t => t.IdPhanQuyen, cascadeDelete: true)
                .Index(t => t.IdPhanQuyen);
            
            CreateTable(
                "dbo.ChiSoBMIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChieuCao = c.Double(nullable: false),
                        CanNang = c.Double(nullable: false),
                        BMI = c.Double(nullable: false),
                        NgayCapNhat = c.DateTime(),
                        NgayTao = c.DateTime(nullable: false),
                        IdNguoiDung = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiDungs", t => t.IdNguoiDung)
                .Index(t => t.IdNguoiDung);
            
            CreateTable(
                "dbo.LikeBaiViets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayLike = c.DateTime(),
                        IdNguoiDung = c.Int(nullable: false),
                        IdBaiViet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaiViets", t => t.IdBaiViet, cascadeDelete: true)
                .ForeignKey("dbo.NguoiDungs", t => t.IdNguoiDung)
                .Index(t => t.IdNguoiDung)
                .Index(t => t.IdBaiViet);
            
            CreateTable(
                "dbo.PhanQuyens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenQuyen = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLoTrinhs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdNguoiDung = c.Int(nullable: false),
                        IdLoTrinh = c.Int(nullable: false),
                        NgayThamGia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoTrinhs", t => t.IdLoTrinh, cascadeDelete: true)
                .ForeignKey("dbo.NguoiDungs", t => t.IdNguoiDung, cascadeDelete: true)
                .Index(t => t.IdNguoiDung)
                .Index(t => t.IdLoTrinh);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLoTrinhs", "IdNguoiDung", "dbo.NguoiDungs");
            DropForeignKey("dbo.UserLoTrinhs", "IdLoTrinh", "dbo.LoTrinhs");
            DropForeignKey("dbo.BaiViets", "IdNguoiDung", "dbo.NguoiDungs");
            DropForeignKey("dbo.BinhLuans", "IdNguoiDung", "dbo.NguoiDungs");
            DropForeignKey("dbo.NguoiDungs", "IdPhanQuyen", "dbo.PhanQuyens");
            DropForeignKey("dbo.LikeBaiViets", "IdNguoiDung", "dbo.NguoiDungs");
            DropForeignKey("dbo.LikeBaiViets", "IdBaiViet", "dbo.BaiViets");
            DropForeignKey("dbo.ChiSoBMIs", "IdNguoiDung", "dbo.NguoiDungs");
            DropForeignKey("dbo.BinhLuans", "IdBinhLuanCha", "dbo.BinhLuans");
            DropForeignKey("dbo.BinhLuans", "IdBaiViet", "dbo.BaiViets");
            DropForeignKey("dbo.LoTrinh_BaiTap", "LoTrinh_Id", "dbo.LoTrinhs");
            DropForeignKey("dbo.LoTrinh_BaiTap", "BaiTap_Id", "dbo.BaiTaps");
            DropIndex("dbo.UserLoTrinhs", new[] { "IdLoTrinh" });
            DropIndex("dbo.UserLoTrinhs", new[] { "IdNguoiDung" });
            DropIndex("dbo.LikeBaiViets", new[] { "IdBaiViet" });
            DropIndex("dbo.LikeBaiViets", new[] { "IdNguoiDung" });
            DropIndex("dbo.ChiSoBMIs", new[] { "IdNguoiDung" });
            DropIndex("dbo.NguoiDungs", new[] { "IdPhanQuyen" });
            DropIndex("dbo.BinhLuans", new[] { "IdBinhLuanCha" });
            DropIndex("dbo.BinhLuans", new[] { "IdNguoiDung" });
            DropIndex("dbo.BinhLuans", new[] { "IdBaiViet" });
            DropIndex("dbo.BaiViets", new[] { "IdNguoiDung" });
            DropIndex("dbo.LoTrinh_BaiTap", new[] { "LoTrinh_Id" });
            DropIndex("dbo.LoTrinh_BaiTap", new[] { "BaiTap_Id" });
            DropTable("dbo.UserLoTrinhs");
            DropTable("dbo.PhanQuyens");
            DropTable("dbo.LikeBaiViets");
            DropTable("dbo.ChiSoBMIs");
            DropTable("dbo.NguoiDungs");
            DropTable("dbo.BinhLuans");
            DropTable("dbo.BaiViets");
            DropTable("dbo.LoTrinhs");
            DropTable("dbo.LoTrinh_BaiTap");
            DropTable("dbo.BaiTaps");
        }
    }
}
