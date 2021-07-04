namespace poc.AspNet5.Ioc.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class init_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.calendario",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 150),
                    IdEquipe = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.equipe", t => t.IdEquipe, cascadeDelete: true)
                .Index(t => t.IdEquipe);

            CreateTable(
                "dbo.equipe",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 150),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.usuario",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 150),
                    Apelido = c.String(nullable: false, maxLength: 100),
                    Setor = c.String(nullable: false, maxLength: 150),
                    DDD = c.String(nullable: false, maxLength: 2),
                    Telefone = c.String(nullable: false, maxLength: 9),
                    Email = c.String(nullable: false, maxLength: 255),
                    Senha = c.String(nullable: false, maxLength: 255),
                    IdEquipe = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.equipe", t => t.IdEquipe, cascadeDelete: true)
                .Index(t => t.IdEquipe);

            CreateTable(
                "dbo.confirmacao",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IdEvento = c.Int(nullable: false),
                    IdUsuario = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.evento", t => t.IdEvento, cascadeDelete: true)
                .ForeignKey("dbo.usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdEvento)
                .Index(t => t.IdUsuario);

            CreateTable(
                "dbo.evento",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 150),
                    DataInicio = c.DateTime(nullable: false),
                    DataFinal = c.DateTime(nullable: false),
                    IdOrganizador = c.Int(nullable: false),
                    IdCalendario = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.calendario", t => t.IdCalendario)
                .ForeignKey("dbo.usuario", t => t.IdOrganizador)
                .Index(t => t.IdOrganizador)
                .Index(t => t.IdCalendario);

        }

        public override void Down()
        {
            DropForeignKey("dbo.calendario", "IdEquipe", "dbo.equipe");
            DropForeignKey("dbo.usuario", "IdEquipe", "dbo.equipe");
            DropForeignKey("dbo.confirmacao", "IdUsuario", "dbo.usuario");
            DropForeignKey("dbo.confirmacao", "IdEvento", "dbo.evento");
            DropForeignKey("dbo.evento", "IdOrganizador", "dbo.usuario");
            DropForeignKey("dbo.evento", "IdCalendario", "dbo.calendario");
            DropIndex("dbo.evento", new[] { "IdCalendario" });
            DropIndex("dbo.evento", new[] { "IdOrganizador" });
            DropIndex("dbo.confirmacao", new[] { "IdUsuario" });
            DropIndex("dbo.confirmacao", new[] { "IdEvento" });
            DropIndex("dbo.usuario", new[] { "IdEquipe" });
            DropIndex("dbo.calendario", new[] { "IdEquipe" });
            DropTable("dbo.evento");
            DropTable("dbo.confirmacao");
            DropTable("dbo.usuario");
            DropTable("dbo.equipe");
            DropTable("dbo.calendario");
        }
    }
}
