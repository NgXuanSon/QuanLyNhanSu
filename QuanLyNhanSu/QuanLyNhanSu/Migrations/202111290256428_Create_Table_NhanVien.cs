namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_NhanVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        IDNV = c.String(nullable: false, maxLength: 128, unicode: false),
                        TenNV = c.String(maxLength: 50),
                        GioiTinh = c.String(),
                        Tuoi = c.Int(nullable: false),
                        SDT = c.String(),
                        Email = c.String(maxLength: 100),
                        DiaChi = c.String(maxLength: 255),
                        NgayVaolam = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDNV);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhanViens");
        }
    }
}
