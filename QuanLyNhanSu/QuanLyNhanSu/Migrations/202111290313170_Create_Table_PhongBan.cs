namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_PhongBan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhongBans",
                c => new
                    {
                        MaPB = c.String(nullable: false, maxLength: 10, unicode: false),
                        TenPB = c.String(),
                    })
                .PrimaryKey(t => t.MaPB);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhongBans");
        }
    }
}
