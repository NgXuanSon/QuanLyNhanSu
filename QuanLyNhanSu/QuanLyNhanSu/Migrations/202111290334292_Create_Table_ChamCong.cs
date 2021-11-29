namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_ChamCong : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChamCongs",
                c => new
                    {
                        TenNV = c.String(nullable: false, maxLength: 128),
                        SoNgayLam = c.Int(nullable: false),
                        SoNgayNghi = c.Int(nullable: false),
                        LyDoNghi = c.String(),
                        NhanViens_IDNV = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.TenNV)
                .ForeignKey("dbo.NhanViens", t => t.NhanViens_IDNV)
                .Index(t => t.NhanViens_IDNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChamCongs", "NhanViens_IDNV", "dbo.NhanViens");
            DropIndex("dbo.ChamCongs", new[] { "NhanViens_IDNV" });
            DropTable("dbo.ChamCongs");
        }
    }
}
