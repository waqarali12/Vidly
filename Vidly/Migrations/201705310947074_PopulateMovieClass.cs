namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieClass : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(name,Genre,ReleaseDate,AddedDate,NumberInStock) VALUES('Shrek','Comedy','01-01-2001',GETDATE(),5)");
            Sql("INSERT INTO Movies(name,Genre,ReleaseDate,AddedDate,NumberInStock) VALUES('Hitman','Action','02-02-2002',GETDATE(),6)");
            Sql("INSERT INTO Movies(name,Genre,ReleaseDate,AddedDate,NumberInStock) VALUES('Terminator','Drama','01-03-2003',GETDATE(),7)");

        }

        public override void Down()
        {
        }
    }
}
