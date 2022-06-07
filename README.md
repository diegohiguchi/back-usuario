# back-end Usuários

Aplicação para adicionar, alterar, listar e excluir usuários. 

Executar comandos da migration:

dotnet ef migrations add InitialMigration -s ../Confitec.API/Confitec.API.csproj -o ./Persistence/Migrations

dotnet ef database update -s ../Confitec.API/Confitec.API.csproj 
