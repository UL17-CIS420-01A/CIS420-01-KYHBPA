namespace KYHBPA.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMemberInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Membership_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Membership_Id");
            AddForeignKey("dbo.AspNetUsers", "Membership_Id", "dbo.Memberships", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Membership_Id", "dbo.Memberships");
            DropIndex("dbo.AspNetUsers", new[] { "Membership_Id" });
            DropColumn("dbo.AspNetUsers", "Membership_Id");
            DropColumn("dbo.AspNetUsers", "ZipCode");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Memberships");
        }
    }
}
