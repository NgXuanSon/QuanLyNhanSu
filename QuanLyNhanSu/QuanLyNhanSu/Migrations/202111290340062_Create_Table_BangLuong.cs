namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_BangLuong : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangLuongs",
                c => new
                    {
                        TenNV = c.String(nullable: false, maxLength: 128),
                        Luong = c.String(),
                        Phucap = c.String(),
                        NhanViens_IDNV = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.TenNV)
                .ForeignKey("dbo.NhanViens", t => t.NhanViens_IDNV)
                .Index(t => t.NhanViens_IDNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BangLuongs", "NhanViens_IDNV", "dbo.NhanViens");
            DropIndex("dbo.BangLuongs", new[] { "NhanViens_IDNV" });
            DropTable("dbo.BangLuongs");
        }
    }
}
