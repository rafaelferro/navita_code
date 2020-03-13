create table Usuario( id int primary key not null identity(1,1),
                    nome varchar(100) not null,
                    email varchar(150) not null,
                    senha varchar(200) not null)