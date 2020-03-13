create table Patrimonio( Tombo int primary key not null identity(1,1),
                    nome varchar(100) not null,
                    id_marcald int not null,
                    Descricao varchar(255),
                    ativo bit not null)