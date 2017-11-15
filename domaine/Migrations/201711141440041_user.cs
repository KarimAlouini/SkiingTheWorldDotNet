namespace domaine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.users",
                    c => new
                    {
                        id = c.Int(nullable: false),
                        city = c.String(maxLength: 255, unicode: false),
                        latidue = c.Double(),
                        longitude = c.Double(),
                        country = c.String(maxLength: 255, unicode: false),
                        street = c.String(maxLength: 255, unicode: false),
                        zipCode = c.Int(),
                        confirmationCode = c.String(maxLength: 255, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        firstName = c.String(maxLength: 255, unicode: false),
                        isBanned = c.Int(),
                        isConfirmed = c.Int(),
                        lastName = c.String(maxLength: 255, unicode: false),
                        login = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        phoneNumber = c.String(maxLength: 255, unicode: false),
                        role = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
        }
        
        public override void Down()
        {
           
        }
    }
}
