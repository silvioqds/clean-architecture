# Projeto: Clean Architecture com CQRS, IoC, Padrão Repository, principios SOLID

Este projeto tem como objetivo demonstrar a criação de uma aplicação utilizando **Clean Architecture** e outros conceitos importantes, como **CQRS (Command Query Responsibility Segregation)**, **Inversão de Dependência** (Dependency Inversion Principle), **Injeção de Dependência** (Dependency Injection), e outras boas práticas no desenvolvimento de software.

## Arquitetura

A **Clean Architecture** é uma abordagem de design de software que promove a separação de responsabilidades e facilita a manutenção e escalabilidade de um sistema. A ideia principal é dividir a aplicação em camadas independentes, onde a lógica de negócios e as regras de domínio são isoladas de detalhes de infraestrutura, como banco de dados e frameworks.

### Camadas da Arquitetura:
- **Core / Domínio**: Contém as entidades do sistema e a lógica de negócios. Não deve depender de outras camadas.
- **Aplicação**: Contém casos de uso, que são responsáveis por orquestrar a lógica do negócio. Esta camada depende do domínio.
- **Infraestrutura**: Implementação de interfaces, como acesso a bancos de dados, APIs externas, etc. Depende das camadas acima.
- **Interface (ou Apresentação)**: Contém a interação com o usuário (ex: API REST, UI) e depende das camadas internas.

## Conceitos Implementados

### 1. **CQRS (Command Query Responsibility Segregation)**

CQRS é um padrão arquitetural que separa a leitura e escrita de dados em modelos diferentes. A ideia é que a escrita (comando) e a leitura (consulta) sejam tratadas de forma independente, podendo ter modelos de dados diferentes para cada operação. Isso ajuda a melhorar a performance, escalabilidade e manutenção.

No projeto, implementamos:
- **Comandos** (para modificações de dados).
- **Consultas** (para leituras de dados).

### 2. **Inversão de Dependência (Dependency Inversion Principle)**

O princípio da inversão de dependência diz que **módulos de alto nível não devem depender de módulos de baixo nível, mas sim de abstrações**. Dessa forma, as dependências são invertidas, promovendo flexibilidade e desacoplamento entre as camadas do sistema.

No projeto, usamos **interfaces e abstrações** para garantir que as camadas mais altas (como a camada de aplicação) não dependam diretamente de implementações específicas (como a camada de infraestrutura).

### 3. **Injeção de Dependência (Dependency Injection)**

A injeção de dependência é um padrão que visa reduzir o acoplamento entre as classes, fornecendo as dependências para um objeto no momento da sua criação, em vez de o próprio objeto criar ou gerenciar suas dependências.

Neste projeto, a **injeção de dependência** é usada para fornecer as implementações necessárias nas camadas, garantindo que a aplicação esteja flexível e testável.

## Estrutura de Pastas

A estrutura do projeto segue as boas práticas de Clean Architecture
