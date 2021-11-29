namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_KhenThuong : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhenThuongs",
                c => new
                    {
                        TenNV = c.String(nullable: false, maxLength: 128),
                        DanhHieuKhenthuong = c.String(),
                        MaSoKhenThuong = c.String(),
                        TienThuong = c.String(),
                        NhanViens_IDNV = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.TenNV)
                .ForeignKey("dbo.NhanViens", t => t.NhanViens_IDNV)
                .Index(t => t.NhanViens_IDNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KhenThuongs", "NhanViens_IDNV", "dbo.NhanViens");
            DropIndex("dbo.KhenThuongs", new[] { "NhanViens_IDNV" });
            DropTable("dbo.KhenThuongs");
        }
    }
}
