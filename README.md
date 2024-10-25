
# ProdutoAPI

## Descrição

Esta API foi desenvolvida utilizando **ASP.NET Core** e **Entity Framework Core** para interação com um banco de dados Oracle. A API inclui operações CRUD para gerenciamento de produtos e autenticação de usuários através do **Firebase Authentication**.

## Funcionalidades Principais

- Autenticação de usuários (registro e login) com Firebase.
- Operações CRUD para produtos.
- Documentação automática com Swagger.

## Práticas de Clean Code e SOLID aplicadas

O projeto segue práticas de **Clean Code** e princípios **SOLID** para garantir código de fácil manutenção e extensão. Aqui estão algumas das práticas aplicadas:

- **Single Responsibility Principle (SRP)**: Cada classe tem uma única responsabilidade. Por exemplo, o `FirebaseAuthService` lida apenas com a autenticação de usuários.
- **Dependency Injection**: Utilização de injeção de dependência para facilitar o teste e a reutilização dos componentes, como o `HttpClient` no serviço de autenticação.
- **Interface Segregation**: As interfaces foram mantidas específicas para evitar dependências indesejadas. 
- **Uso de DTOs**: Transferência de dados entre camadas é feita utilizando Data Transfer Objects (DTOs) para melhorar a clareza e manutenibilidade.

## Testes Implementados

O projeto inclui testes unitários implementados com **xUnit** e **Moq**. Os testes cobrem as seguintes áreas:

- **Testes de Registro e Login de Usuários**: Utilizando mocks do `HttpClient`, verificamos se os métodos de autenticação estão retornando os tokens adequados.
  
Exemplo de teste de unidade:
```csharp
[Fact]
public async Task RegisterUser_ShouldReturnToken()
{
    var token = await _authService.RegisterUser("test@example.com", "password123");
    Assert.NotNull(token);
}
```

Os testes garantem que os métodos de autenticação estão funcionando corretamente e que o retorno esperado (um token JWT) é gerado.

## Funcionalidades de IA Generativa

Uma possível funcionalidade de **IA generativa** que pode ser integrada à API é a recomendação de produtos com base em dados do usuário. Esta funcionalidade pode ser desenvolvida utilizando **ML.NET** para criar modelos de recomendação ou análise de sentimento, que podem agregar valor ao sistema recomendando produtos ou analisando feedback dos clientes.

## Como Rodar o Projeto

1. Clone o repositório.
2. Configure o banco de dados Oracle e atualize a string de conexão no arquivo `appsettings.json`.
3. Rode os seguintes comandos para restaurar os pacotes e rodar a aplicação:

```bash
dotnet restore
dotnet build
dotnet run
```

4. Acesse o Swagger para testar os endpoints:
   ```
   https://localhost:<porta>/swagger
   ```

## Como Rodar os Testes

Execute os testes utilizando o Test Explorer no Visual Studio ou via terminal com o comando:

```bash
dotnet test
```
