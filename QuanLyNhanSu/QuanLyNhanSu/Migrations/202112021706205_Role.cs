namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AlterColumn("dbo.ChucVus", "IDChucVu", c => c.String(maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChucVus", "IDChucVu", c => c.String(maxLength: 10));
            DropTable("dbo.Roles");
        }
    }
}
