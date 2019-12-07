# UsuarioTeste
Essa aplicação tem como objetivo criar um sistema que faça um CRUD de clientes.

## Tecnologias
Para esse o desenvolvimento desta API Rest, foram utilizados .NET Core 2.2, Entity Framework Core, Docker com banco de dados Microsoft SQL Server 2017.

# Configurando a API
A api se encontra na pasta ClienteCRUD.API. Para o perfeito funcionamento da mesma, as configurações abaixo devem ser efetuadas.

## Configurando a conexão do banco de dados e a API
Dentro do arquivo ./ClienteCRUD.Infra/appsettings.json você pode alterar a query string de acordo com o banco de dados escolhido.

```c#
  "ConnectionStrings": {
    "SqlExpressConnection": "Server=localhost\SQLEXPRESS;Database=UsuarioDB; Integrated Security=True;"
  }
```
# Configurando o banco de dados
O banco utilizado na aplicação foi o Microsoft SQL Server 2017, porém pode ser utilizado qualquer outro banco, com as devidas alterações na query string na API e a criação dos objetos descritos abaixo. Você também pode gerar as tabelas automaticamente utilizando o Entity Framework Core.

## Criação de objetos para o projeto
```sql
create table Endereco (
Id int IDENTITY(1,1),
Logradouro varchar(50),
Bairro varchar(40),
Cidade varchar(40),
Estado varchar(40),
   PRIMARY KEY (Id)
)
create table Cliente 
(
Id int IDENTITY(1,1),
Nome varchar(30),
CPF varchar(11),
DataNascimento datetime,
EnderecoId int,
PRIMARY KEY (Id),
FOREIGN KEY (EnderecoId) REFERENCES Endereco(Id)
)
```
