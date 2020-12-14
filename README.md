# Parking
Sistema para gestão de estacionamentos

## Tecnologias Utilizadas
Linguagem: C#
Versão do projeto: .NET Core 2.1, 
Camada de apresentação: Web API, 
Framework de notificação: Flunt (1.0.5), 
Framework para acesso a dados: Dapper (20.0.78), 
Acesso a dado: SqlClient (4.8.2), 
Recuperar a connection string: Configuration.Abstractions (2.1.1), 

## Configurações para execução
Geração do banco de dados execute o script no banco Sql Server:

> create table Company(
>    Id int identity primary key,
>    Name varchar(70) not null,
>    Cnpj varchar(14) not null,
>    Address varchar(70) not null,
>    Telephone varchar(11) not null,
>    NumberOfSpacesForMotorcycles int not null,
>    NumberOfSpacesForCars int not null
> );

> create table VehicleType(
>    Id int primary key not null,
>    Description varchar(50) not null
>);

>insert into VehicleType (Id, Description) values (1, 'Car');
>insert into VehicleType (Id, Description) values (2, 'Motorcycle');

> create table Vehicle(
>    Id int identity primary key,
>    Brand varchar(70) not null,
>    Model varchar(70) not null,
>    Color varchar(50) not null,
>    Plate varchar(7),
>    [type] int not null foreign key references VehicleType(id),
> );

> create table CompanyVehicle (
>    Id int identity primary key,
>    VehicleId int foreign key references Vehicle(id),
>    CompanyId int foreign key references Company(id),
>    EntryDate DateTime not null,
>    DepartureDate DateTime,
>    IsActive bit
> );

Insira sua connection string no arquivo __"appsettings.json"__, nessa linha do json "parking.sql": "__Aqui__".
Sinta-se a vontade para executar no IIS Express ou Kestrel.

Para facilitar e documentar as chamadas da api no sistema, foi criado uma collection do postman com o nome de __Parking__ e se encontra na raiz do projeto.