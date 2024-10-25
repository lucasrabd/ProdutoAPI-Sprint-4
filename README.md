# ProdutoAPI

Este projeto é uma API desenvolvida em ASP.NET Core, chamada **ProdutoAPI**, responsável pela gestão de produtos. Ela implementa operações de CRUD (Criar, Ler, Atualizar, Deletar) em um banco de dados, permitindo a interação com dados de produtos através de endpoints HTTP.

## Integrantes do Grupo

- **Bruno Ramos da Costa** (RM551942)
- **Guilherme Faria de Aguiar** (RM551374)
- **Henrique Roncon Pereira** (RM99161)
- **Lucas Carabolad Bob** (RM550519)
- **Thiago Ulrych** (RM97951)

## Arquitetura

A arquitetura da API segue o padrão de camadas, que separam as responsabilidades de maneira clara:

- **Controllers**: São responsáveis por lidar com as requisições HTTP, receber os dados, chamar os serviços necessários e retornar a resposta adequada.
- **Services**: Contêm a lógica de negócio da aplicação. Aqui é onde são feitas as validações e regras antes de acessar o banco de dados.
- **Repositories**: Fazem a interface entre os serviços e o banco de dados. São responsáveis pelas operações de CRUD no banco.
- **Data**: Gerencia o contexto do Entity Framework e a configuração do banco de dados.

Esta separação facilita a manutenção, escalabilidade e testabilidade do projeto.

## Design Patterns Utilizados

- **Repository Pattern**: Implementado para encapsular a lógica de acesso ao banco de dados, proporcionando uma abstração entre a camada de negócio e a camada de dados.
- **Dependency Injection**: Utilizada em toda a aplicação para garantir que as dependências sejam injetadas nas classes de forma clara e flexível, facilitando a substituição de implementações e a realização de testes.
- **DTO (Data Transfer Object)**: Utilizado para transferir dados entre as camadas de forma segura e eficiente, evitando o acoplamento direto das entidades do banco de dados.

## Instalação e Execução

### Requisitos

- .NET SDK 6.0 ou superior
- Visual Studio 2022 (ou IDE compatível)
- Banco de dados SQL Server (ou outro banco compatível com o Entity Framework)

### Passo a Passo

1. Clone este repositório:
   ```bash
   git clone <URL_DO_REPOSITORIO>
   ```

2. Abra a solução no Visual Studio:
   ```bash
   cd ProdutoAPI
   start ProdutoAPI.sln
   ```

3. Configure o banco de dados no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=<SERVIDOR>;Database=<NOME_DO_BANCO>;User Id=<USUARIO>;Password=<SENHA>;"
   }
   ```

4. Execute as migrações para preparar o banco de dados:
   ```bash
   dotnet ef database update
   ```

5. Execute a aplicação:
   ```bash
   dotnet run
   ```

6. Acesse a API através do navegador ou de um cliente HTTP, como Postman, utilizando o endereço:
   ```
   https://localhost:5001/api/produtos
   ```

## Endpoints da API

- **GET /api/produtos**: Retorna a lista de todos os produtos.
- **GET /api/produtos/{id}**: Retorna os detalhes de um produto específico.
- **POST /api/produtos**: Cria um novo produto.
- **PUT /api/produtos/{id}**: Atualiza os dados de um produto existente.
- **DELETE /api/produtos/{id}**: Exclui um produto.

### Exemplo de Requisição POST

```json
{
  "nome": "Produto Teste",
  "descricao": "Descrição do Produto Teste",
  "preco": 99.99
}
```

## Executando Testes

Os testes podem ser executados com o seguinte comando:

```bash
dotnet test
```

## Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

