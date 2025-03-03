## Sobre o projeto

Esta **API**, desenvolvida utilizando **.NET 8**, foi criada para fornecer uma solução eficiente no gerenciamento de barbearias. Com base nos princípios do **Domain-Driven Design (DDD)**, a API possibilita um controle preciso de agendamentos, clientes, serviços e profissionais, garantindo um fluxo de trabalho otimizado para barbearias de todos os tamanhos.

A arquitetura da **API** segue os padrões **REST**, utilizando métodos **HTTP** para comunicação eficiente e simplificada. Além disso, conta com uma documentação **Swagger**, permitindo que desenvolvedores explorem e testem os endpoints de maneira interativa.

Entre os pacotes **NuGet** utilizados, destacam-se:

- **AutoMapper**: Facilita o mapeamento entre objetos de domínio e requisição/resposta, reduzindo código repetitivo.
- **FluentAssertions**: Utilizado para tornar os testes de unidade mais legíveis e compreensíveis.
- **FluentValidation**: Permite a implementação de regras de validação de forma clara e intuitiva.
- **EntityFramework**: ORM que simplifica a interação com o banco de dados, permitindo manipulação de dados sem necessidade de consultas SQL diretas.

![Example-Image]

### Features

- **Domain-Driven Design (DDD)**: Estrutura modular que facilita a manutenção e evolução do projeto.
- **Testes de Unidade**: Implementação de testes automatizados para garantir a qualidade do código.
- **Gestão Completa de Barbearias**: Controle eficiente de clientes, profissionais e agendamentos.
- **Geração de Relatórios**: Exportação de relatórios detalhados para **PDF e Excel**.
- **RESTful API com Documentação Swagger**: Interface documentada que facilita a integração com outras aplicações.

### Construído com

![badge-dot-net]
![badge-windows]
![badge-visual-studio]
![badge-mysql]
![badge-swagger]

## Getting Started

Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos

* Visual Studio versão 2022+ ou Visual Studio Code
* Windows 10+ ou Linux/MacOS com [.NET SDK][dot-net-sdk] instalado
* MySql Server

### Instalação

1. Clone o repositório:
    ```sh
    git clone https://github.com/Carloscavalcante97/BarberBoss
    ```

2. Preencha as informações no arquivo `appsettings.Development.json`.
3. Execute a API e aproveite o seu teste :)

<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

<!-- Images -->
[Example-Image]: Images/Example.png

<!-- Badges -->
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-windows]: https://img.shields.io/badge/Windows-0078D4?logo=windows&logoColor=fff&style=for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=fff&style=for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge
