namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AppUserRoles", name: "EntityId", newName: "Id");
            RenameColumn(table: "dbo.AppUsers", name: "EntityId", newName: "Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.AppUsers", name: "Id", newName: "EntityId");
            RenameColumn(table: "dbo.AppUserRoles", name: "Id", newName: "EntityId");
        }
    }
}
