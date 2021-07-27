# Gestão de Eventos

Este projeto tem como finalidade gerenciar a organização de um evento como uma festa ou um churrasco por exemplo

## 🚀 Começando

Realize o download do projeto, configure o banco de dados e realize o Build/Run para rodar.

Consulte **Instalação** para saber como implantar o projeto.

### 📋 Pré-requisitos

.Net 5
Banco de dados Sql Server

```
https://dotnet.microsoft.com/download
https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
```

### 🔧 Instalação

Informar os dados de acesso do banco de dados em appsettings.json
Exemplo:
```
"ConnectionStrings": {
    "DatabaseConnection": "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=db_Event;Persist Security Info=True;MultipleActiveResultSets=True;Trusted_Connection=True;Connection Timeout=30;"
  }
```

No Visual Studio, em package manager console executar o comando abaixo para criar a base de dados:
```
update-database
```

Em seguida executar a aplicação Events.API

## ⚙️ Executando os testes



### 🔩 Retornos da API

A API retorna os seguintes status:
200 OK
400 Payload invalido
401 Token inválido/Nao autenticado
402 Requerida confirmação ou informação
403 Acesso negado
409 Registro duplicado/Regras de negocio


## 🛠️ Construído com

* [.Net](https://docs.microsoft.com/pt-br/dotnet/core/dotnet-five) - Framework .Net 5 com Web API
* [Entity framework](https://docs.microsoft.com/pt-br/ef/) - ORM
* [AutoMapper](https://automapper.org/) - Mapeamento Entity - ViewModel

## 🛠️ Técnicas

* [DDD](https://en.wikipedia.org/wiki/Domain-driven_design) - Domain Driven Design
* [Clean Code](https://pt.wikipedia.org/wiki/Robert_Cecil_Martin) - Clean code

## 🛠️ Padrões

* [SOLID](https://pt.wikipedia.org/wiki/SOLID) - SOLID

## ✒️ Autor

* **Fullstack developer .Net** - *LinkedIn* - [Wilham Ezequiel de Sousa ](https://www.linkedin.com/in/wilham-ezequiel-de-sousa-22373696/)

## 📄 Licença

MIT


