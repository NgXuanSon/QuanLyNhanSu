namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_KyLuat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KyLuats",
                c => new
                    {
                        TenNV = c.String(nullable: false, maxLength: 128),
                        LoaiKyLuat = c.String(),
                        MucDoKyLuat = c.String(),
                        LyDo = c.String(),
                        LoaiHinhPhat = c.String(),
                        NhanViens_IDNV = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.TenNV)
                .ForeignKey("dbo.NhanViens", t => t.NhanViens_IDNV)
                .Index(t => t.NhanViens_IDNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KyLuats", "NhanViens_IDNV", "dbo.NhanViens");
            DropIndex("dbo.KyLuats", new[] { "NhanViens_IDNV" });
            DropTable("dbo.KyLuats");
        }
    }
}
