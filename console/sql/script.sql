-- para entrar no mysql terminal
mysql -uroot -p'root'

create database persistencia_codigo_do_futuro;

CREATE TABLE clientes (
    id int NOT NULL AUTO_INCREMENT,
    nome varchar(100) NOT NULL,
    email varchar(150),
    PRIMARY KEY (id)
);

select * from clientes;

insert into clientes(nome, email)values('Daniela', 'dani@gmail.com');
insert into clientes(nome, email)values('Bia', 'bia@gmail.com');
insert into clientes(nome, email)values('Sung ju', 'sung@gmail.com');

select * from clientes where id = 1; -- filtra por id
select * from clientes where id in (1,2); -- filtra por multiplos ids

select * from clientes where nome = 'Daniela'; -- filtra por nome de forma exata
select * from clientes where nome like 'dan%'; -- filtra por parte do nome no começo
select * from clientes where nome like '%ela'; -- filtra por parte do nome no final
select * from clientes where nome like '%ela%'; -- filtra por parte do texto

select * from clientes 
where id = '10' or email like '%bea%'

update clientes set nome='Beatriz', email='beatriz@gmail.com' where id = 2;

insert into clientes(nome, email)values('sddsds', 'dsdssds@gmail.com');

delete from clientes where id = 4;

START TRANSACTION; -- starta uma transação segura onde precisa de confirmação para efetivar
COMMIT; -- confirma a transação
ROLLBACK; -- desfaz a transação

-- como fazer um dump do banco de dados SQL
mysqldump -u root -p persistencia_codigo_do_futuro > console/sql/backup.sql
-- como restore do database
mysql -u root -p persistencia_codigo_do_futuro < console/sql/backup.sql
