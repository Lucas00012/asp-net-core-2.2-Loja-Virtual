# asp-net-core-2.2-Loja-Virtual
Projeto desenvolvido durante o curso "ASP.NET Core 2.2 - Aprenda construindo uma Loja Virtual" ministrado pelo Elias Costa.

Nele utilizamos diversos recursos do ASP NET CORE (ViewComponent, Middlewares, Cookie, Sessões, Filtros,
validações customizadas, area, layout e importações, TAG helper, HTML helper), e realizamos integrações com diversos sistemas/bibliotecas (Correios, Jquery, Bootstrap, PagarMe, Sheduler (coravel), AutoMapper, registros de log (Serilog)). 

*O projeto foi desenvolvido utilizando o padrão MVC, repository e DI.

*Banco de dados utilizado: SQL SERVER

*ORM utilizado: Entity Framework Core

# Executando o projeto

*Instale Visual Studio Community


Pacotes necessários


->ASP.NET e desenvolvimento Web


->Processamento e armazenamento de dados

*Instale o .net core sdk 2.2

# Observações

Primeiramente é necessário incluir a string de conexão do seu banco de dados no arquivo 'appsettings.Development.json', e executar em seu banco todo 
o código contido no arquivo 'QueryPrincipal.sql'.

Para testar o formulário de contato e a recuperação de senha, será necessário preencher o arquivo 'appsettings.Development.json'
com as credenciais de uma conta Google (lá você tembém pode reconfigurar o smtp para outro provedor).
Caso essas funcionalidades ainda não estejam funcionando, será necessário ativar a opção 'Acesso a app menos seguro' encontrada
nas configurações de sua conta G-mail.

O acesso ao painel administrativo se dá pela URL /colaborador/home/login. Há uma conta padrão cadastrada com o
e-mail 'colaborador@gmail.com' e senha '123456' para testes.

# Preview do projeto

![header](https://user-images.githubusercontent.com/51132386/80565443-d3503380-89c6-11ea-9906-dea05cb03789.png)

![kart](https://user-images.githubusercontent.com/51132386/80565601-46f24080-89c7-11ea-95ff-c8fd93c1c2b1.png)

![account](https://user-images.githubusercontent.com/51132386/80565722-959fda80-89c7-11ea-9099-7dc9d63e9630.png)

![control-panel](https://user-images.githubusercontent.com/51132386/80565838-e0b9ed80-89c7-11ea-80df-0194509ae04a.png)

![buy](https://user-images.githubusercontent.com/51132386/80566211-d3e9c980-89c8-11ea-8da4-ecb14fc4bf3e.png)
