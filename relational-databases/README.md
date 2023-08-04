# Relational Databases

## Benchmark

### Resultados 

Setup:

- Framework para consultas: Dapper.
- Tempo: 10 segundos.
- Teste simples rodando 10 segundos de consultas. Resultado no formato (total-de-queries) - (opera��es-por-segundo).

| Engine         | Driver                   | 1 Thread                 | 10 Threads               | 100 Threads                |
|----------------|--------------------------|--------------------------|--------------------------|----------------------------|
| PostgreSQL 14  | Npgsql                   | 25.787 - 2.578,7 op/sec  | 28.209 - 2.820,9 op/sec  | 29.410 - 2.941,0 op/sec    |
| MySQL 8        | MySqlConnector           | 13.018 - 1.301,8 op/sec  | 12.756 - 1.275,6 op/sec  | 13.013 - 1.301,3 op/sec    |
| MySQL 8        | MySql.Data               | 5.381 - 538,1 op/sec     | Inst�vel com burst test  | Inst�vel com burst test    |
| MariaDB 11     | MySqlConnector           | 16.323 - 1.632,3 op/sec  | 15.214 - 1.521,4 op/sec  | 18.924 - 1.892,4 op/sec    |
| SqlServer 2019 | Microsoft.Data.SqlClient | 21.577 - 2.157,7 op/sec  | 90.200 - 9.020,0 op/sec  | 117.402 - 11.740,2 op/sec  |

- [Npgsql](https://www.npgsql.org/doc/connection-string-parameters.html)
- [MySqlConnector Driver](https://mysqlconnector.net/connection-options/)

### Create database script

```bash
create database teste;

CREATE TABLE pessoa (
    id int4 NOT NULL,
    nome varchar(60) NOT NULL,
    CONSTRAINT pessoa_pk PRIMARY KEY (id)
);

INSERT INTO pessoa (id,nome) VALUES
     (1,'Fulano'),
     (2,'Beltrano');

select * from pessoa p;
```