# Projeto Pschool

## Descrição

O projeto Pschool é um sistema de gerenciamento de alunos e pais feito em blazor, desenvolvido para fornecer uma solução eficiente para o cadastro e administração de informações acadêmicas. O sistema permite a criação, edição e exclusão de alunos e pais, bem como o gerenciamento das associações entre eles.

## Funcionalidades

- **Cadastro e gerenciamento de alunos**: Adicione, edite e exclua informações de alunos.
- **Cadastro e gerenciamento de pais**: Adicione, edite e exclua informações de pais.
- **Associação entre alunos e pais**: Vincule alunos a pais e visualize essas associações.
- **Contagem de alunos por pai**: Visualize o número de alunos associados a cada pai.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construção de APIs e aplicações web.
- **Entity Framework Core**: ORM para acesso a dados e manipulação de banco de dados.
- **Blazor**: Framework para construção de interfaces ricas e interativas no lado do cliente.
- **SQL Server**: Banco de dados utilizado para persistência de dados.

## Padrões de Projeto

- **Relacionamento entre Alunos e Pais**: Implementado com comportamento de exclusão em cascata para garantir a integridade dos dados.
- **Migrations**: Utilizadas para atualizar o esquema do banco de dados conforme necessário.


Obrigado por utilizar o Pschool!
