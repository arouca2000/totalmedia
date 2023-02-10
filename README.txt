TOTAL MEDIA
===========


FrontEnd
--------

Usamos as seguintes versões:

Angular - 15.0.0
AngularCli - 15.0.4
Angular Material - 15.1.4
Angular CDK - 15.1.4
Node - 16.16.0
Visual Studio Code - 1.75.1
Google Chrome

Na pasta SERVICES temos o ficheiro Service.ts onde vemos os endpoints que serão chamados do BackEnd.
Caso seja necessário, os endereções poderão ser alterados.


Seguir os passos para instalação:

node.js - https://nodejs.org/en/
Na pasta do projeto - npm install -g @angular/cli
material e cdk - na pasta do projeto - ng add @angular/material @angular/cdk


 

BackEnd
-------

Usamos as seguintes versões:

AutoMapper - 12.0.1
Entity Framework Core - 7.0.2
Microsoft Core SQL Server - 7.0.2
Visual Studio 2022

O ficheiro appsettings.json possuí a configuração de acesso à base de dados do SQL. Necessário alterar o utilizador e password,
colocando credenciais válidas para o vosso ambiente.

Projeto feito seguindo o padrão Code First. Portanto, existem migrations a serem feitos para a criação da base de dados e tabelas, 
bem como populá-las com alguns registos.



