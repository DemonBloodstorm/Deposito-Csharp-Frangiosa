CREATE IF NOT EXISTS DATABASE todo_db;

use todo_db;


create table Rubrica (
    Id int primary key AUTO_INCREMENT NOT NULL ,
    Nome varchar(50),
    Cognome varchar(50),
    Telefono varchar(15) NOT NULL
)

drop table Rubrica;