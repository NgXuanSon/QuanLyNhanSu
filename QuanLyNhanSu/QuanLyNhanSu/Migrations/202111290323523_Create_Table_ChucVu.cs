namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_ChucVu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChucVus",
                c => new
                    {
                        TenPB = c.String(nullable: false, maxLength: 128),
                        IDChucVu = c.String(maxLength: 10),
                        TenChucVu = c.String(),
                        PhongBans_MaPB = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.TenPB)
                .ForeignKey("dbo.PhongBans", t => t.PhongBans_MaPB)
                .Index(t => t.PhongBans_MaPB);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChucVus", "PhongBans_MaPB", "dbo.PhongBans");
            DropIndex("dbo.ChucVus", new[] { "PhongBans_MaPB" });
            DropTable("dbo.ChucVus");
        }
    }
}
