create database dbScoutStamp;
use dbScoutStamp;


create table tbFornecedor(
IdFornecedor int primary key auto_increment,
RazaoSocial varchar(100) not null,
NomeFantasia varchar(100) not null,
CNPJ bigint unique not null,
Email varchar(100) unique not null
);

create table tbProduto(
IdProduto int primary key auto_increment,
Nome varchar(100) not null,
ValorUnid decimal(5,2) not null,
QtdEstoque decimal(7,2) not null
);

create table tbCliente(
IdCliente int primary key auto_increment,
Email varchar(100) unique not null,
Telefone bigint unique not null,
CPF bigint unique not null,
Nome varchar(100) not null,
DataNasc date not null
);


create table tbPedido(
IdPedido int primary key auto_increment,
DataPedido datetime not null,
Produto varchar(100) not null,
ValorTotal decimal(5,2) not null,
StatusPedido varchar(50) not null,
IdCliente int not null,
foreign key (IdCliente) references tbCliente(IdCliente)
);

create table tbEntrega(
IdEntrega int primary key auto_increment,
DataHoraSaída datetime not null,
DataHoraEntrega datetime not null,
PrevisaoEntrega date not null,
StatusEntrega varchar(50) not null,
IdPedido int not null,
foreign key (IdPedido) references tbPedido(IdPedido)
);

create table tbItemPedido(
IdItemPedido int primary key auto_increment,
QtdProdutos smallint not null,
ValorUnid decimal(7,2) not null,
IdProduto int not null,
IdPedido int not null,
foreign key (IdProduto) references tbProduto(IdProduto),
foreign key (IdPedido) references tbPedido(IdPedido)
);

create table tbPagamento(
IdPagamento int primary key auto_increment,
FormaPagamento varchar(50) not null,
Valor decimal(7,2) not null,
DataPagamento date not null,
IdEntrega int not null,
IdPedido int not null,
foreign key (IdEntrega) references tbEntrega(IdEntrega), 
foreign key (IdPedido) references tbPedido(IdPedido)
);

select * from tbFornecedor
