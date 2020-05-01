CREATE TABLE [dbo].[Categorias] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Nome]           NVARCHAR (MAX) NULL,
    [Slug]           NVARCHAR (MAX) NULL,
    [CategoriaPaiId] INT            NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Categorias_Categorias_CategoriaPaiId] FOREIGN KEY ([CategoriaPaiId]) REFERENCES [dbo].[Categorias] ([Id])
);

SET IDENTITY_INSERT [dbo].[Categorias] ON
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (1, N'Informática', N'informatica', NULL)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (2, N'Teclado', N'teclado', 1)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (3, N'Teclado Gamer', N'teclado-gamer', 2)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (4, N'Teclado sem fio', N'teclado-sem-fio', 2)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (5, N'Teclado com fio', N'teclado-com-fio', 2)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (6, N'Mouse', N'mouse', 1)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (7, N'Mouse Gamer', N'mouse-gamer', 6)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (8, N'Mouse sem fio', N'mouse-sem-fio', 6)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (9, N'Mouse com fio', N'mouse-com-fio', 6)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (10, N'WebCam', N'webcam', 1)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (1002, N'Notebook', N'notebook', 1)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (1003, N'Notebook Gamer', N'notebook-gamer', 1002)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (2002, N'Ultrabook', N'ultrabook', 1002)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (6004, N'Headset', N'headset', 1)
INSERT INTO [dbo].[Categorias] ([Id], [Nome], [Slug], [CategoriaPaiId]) VALUES (6005, N'Headset Gamer', N'headset-gamer', 6004)
SET IDENTITY_INSERT [dbo].[Categorias] OFF

CREATE TABLE [dbo].[Clientes] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (MAX) NOT NULL,
    [Nascimento]  DATETIME2 (7)  NOT NULL,
    [Sexo]        NVARCHAR (MAX) NOT NULL,
    [CPF]         NVARCHAR (MAX) NOT NULL,
    [Telefone]    NVARCHAR (MAX) NOT NULL,
    [Email]       NVARCHAR (MAX) NOT NULL,
    [Senha]       NVARCHAR (MAX) NOT NULL,
    [Status]      VARCHAR (1)    CONSTRAINT [df_Clientes] DEFAULT ('A') NULL,
    [CEP]         VARCHAR (9)    NULL,
    [Numero]      INT            NULL,
    [Rua]         VARCHAR (MAX)  NULL,
    [Cidade]      VARCHAR (MAX)  NULL,
    [Bairro]      VARCHAR (MAX)  NULL,
    [Complemento] VARCHAR (MAX)  NULL,
    [Estado]      VARCHAR (2)    NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Status]='A' OR [Status]='D')
);

SET IDENTITY_INSERT [dbo].[Clientes] ON
INSERT INTO [dbo].[Clientes] ([Id], [Nome], [Nascimento], [Sexo], [CPF], [Telefone], [Email], [Senha], [Status], [CEP], [Numero], [Rua], [Cidade], [Bairro], [Complemento], [Estado]) VALUES (4023, N'Joana Freitas Melo', N'1980-11-20 00:00:00', N'F', N'390.943.360-06', N'(11) 6554-4354', N'joana@gmail.com', N'12345678', N'A', N'05675-000', 564, N'Rua dos Nenúfares', N'São Paulo', N'Cidade Jardim', N'Apt. 287 Videiras', N'SP')
INSERT INTO [dbo].[Clientes] ([Id], [Nome], [Nascimento], [Sexo], [CPF], [Telefone], [Email], [Senha], [Status], [CEP], [Numero], [Rua], [Cidade], [Bairro], [Complemento], [Estado]) VALUES (6023, N'Lucas Eduardo', N'2001-07-10 00:00:00', N'M', N'220.525.700-55', N'(11) 4432-59700', N'lucaseduardoormond@gmail.com', N'123123', N'A', N'04657-000', 123, N'Avenida Yervant Kissajikian', N'São Paulo', N'Vila Constança', N'Apt. 287 Videiras', N'SP')
SET IDENTITY_INSERT [dbo].[Clientes] OFF

CREATE TABLE [dbo].[Colaboradores] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Nome]  NVARCHAR (MAX) NULL,
    [Email] NVARCHAR (MAX) NULL,
    [Senha] NVARCHAR (MAX) NULL,
    [Tipo]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Colaboradores] PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT [dbo].[Colaboradores] ON
INSERT INTO [dbo].[Colaboradores] ([Id], [Nome], [Email], [Senha], [Tipo]) VALUES (1, N'Colaborador', N'colaborador@gmail.com', N'123456', N'G')
INSERT INTO [dbo].[Colaboradores] ([Id], [Nome], [Email], [Senha], [Tipo]) VALUES (2, N'Lucas Eduardo', N'lucaseduardoormond@gmail.com', N'12345678', N'C')
SET IDENTITY_INSERT [dbo].[Colaboradores] OFF

CREATE TABLE [dbo].[EnderecosEntrega] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (MAX) NULL,
    [CEP]         VARCHAR (MAX) NULL,
    [Rua]         VARCHAR (MAX) NULL,
    [Cidade]      VARCHAR (MAX) NULL,
    [Bairro]      VARCHAR (MAX) NULL,
    [Complemento] VARCHAR (MAX) NULL,
    [Numero]      INT           NULL,
    [Estado]      VARCHAR (2)   NULL,
    [ClienteId]   INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([Id])
);

SET IDENTITY_INSERT [dbo].[EnderecosEntrega] ON
INSERT INTO [dbo].[EnderecosEntrega] ([Id], [Nome], [CEP], [Rua], [Cidade], [Bairro], [Complemento], [Numero], [Estado], [ClienteId]) VALUES (1, N'Casa mãe', N'04657-000', N'Avenida Yervant Kissajikian', N'São Paulo', N'Vila Constança', N'Apt. 16B', 299, N'SP', 4023)
INSERT INTO [dbo].[EnderecosEntrega] ([Id], [Nome], [CEP], [Rua], [Cidade], [Bairro], [Complemento], [Numero], [Estado], [ClienteId]) VALUES (2, N'Casa tia', N'54780-000', N'Rua Monteiro', N'Camaragibe', N'São João e São Paulo', NULL, 987, N'PE', 4023)
SET IDENTITY_INSERT [dbo].[EnderecosEntrega] OFF

CREATE TABLE [dbo].[Produtos] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (MAX)   NOT NULL,
    [Descricao]   VARCHAR (MAX)   NULL,
    [Valor]       DECIMAL (18, 2) NOT NULL,
    [Quantidade]  INT             NOT NULL,
    [Peso]        DECIMAL (18, 3) NOT NULL,
    [Largura]     INT             NOT NULL,
    [Altura]      INT             NOT NULL,
    [Comprimento] INT             NOT NULL,
    [CategoriaId] INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[Categorias] ([Id])
);

SET IDENTITY_INSERT [dbo].[Produtos] ON
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (1, N'Computador Dell', N'i5, 8gb RAM e HD de 500gb. Perfeito para uso', CAST(2000.00 AS Decimal(18, 2)), 7, CAST(7.000 AS Decimal(18, 3)), 15, 3, 30, 1002)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (1004, N'Teclado Razer', N'Teclado mecânico com excelente durabilidade e perfeito para jogos', CAST(300.00 AS Decimal(18, 2)), 0, CAST(0.200 AS Decimal(18, 3)), 11, 3, 40, 3)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (6004, N'Mouse', N'Mouse bom', CAST(300.00 AS Decimal(18, 2)), 1, CAST(0.180 AS Decimal(18, 3)), 20, 20, 20, 7)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (8004, N'Cadeira DXRacer', N'Cadeira boa', CAST(550.55 AS Decimal(18, 2)), 0, CAST(0.500 AS Decimal(18, 3)), 20, 20, 20, 1)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (9004, N'Webcam', N'Webcam boa', CAST(100.00 AS Decimal(18, 2)), 14, CAST(0.100 AS Decimal(18, 3)), 11, 11, 20, 10)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (9005, N'Webcam FDH', N'Webcam boladona', CAST(250.00 AS Decimal(18, 2)), 9, CAST(0.100 AS Decimal(18, 3)), 11, 11, 20, 10)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (9006, N'Webcam 4k', N'Webcam mega boladassa', CAST(300.00 AS Decimal(18, 2)), 10, CAST(0.100 AS Decimal(18, 3)), 11, 11, 20, 10)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (9007, N'Webcam Samsung', N'Webcam samsung boa', CAST(150.00 AS Decimal(18, 2)), 9, CAST(0.100 AS Decimal(18, 3)), 11, 11, 17, 10)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (9008, N'Computador AMD', N'Computador bom', CAST(2100.00 AS Decimal(18, 2)), 3, CAST(6.500 AS Decimal(18, 3)), 20, 20, 20, 1002)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (9009, N'Computador Apple', N'Computador desnecessariamente caro', CAST(7000.00 AS Decimal(18, 2)), 4, CAST(6.000 AS Decimal(18, 3)), 20, 20, 20, 1002)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (9010, N'Mouse Gamer', N'Mouse bom demais', CAST(270.00 AS Decimal(18, 2)), 8, CAST(0.150 AS Decimal(18, 3)), 11, 11, 20, 7)
INSERT INTO [dbo].[Produtos] ([Id], [Nome], [Descricao], [Valor], [Quantidade], [Peso], [Largura], [Altura], [Comprimento], [CategoriaId]) VALUES (9011, N'Mousepad', N'Mousepad bom', CAST(60.00 AS Decimal(18, 2)), 20, CAST(0.020 AS Decimal(18, 3)), 11, 11, 17, 1)
SET IDENTITY_INSERT [dbo].[Produtos] OFF

CREATE TABLE [dbo].[ImagensProdutos] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Caminho]   VARCHAR (MAX) NOT NULL,
    [ProdutoId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produtos] ([Id])
);

SET IDENTITY_INSERT [dbo].[ImagensProdutos] ON
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (7004, N'\uploads\1004\teclado02.jpg', 1004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (7005, N'\uploads\1004\teclado01.jpg', 1004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (7006, N'\uploads\1004\teclado03.jpg', 1004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (8002, N'\uploads\6004\mouse03.jpg', 6004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (8003, N'\uploads\6004\mouse01.jfif', 6004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (8004, N'\uploads\6004\mouse04.jpg', 6004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (8005, N'\uploads\6004\mouse02.jfif', 6004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (8006, N'\uploads\6004\mouse05.jpg', 6004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9002, N'\uploads\9011\mousepad01.jfif', 9011)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9003, N'\uploads\8004\cadeira03.jpg', 8004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9004, N'\uploads\8004\cadeira02.jpg', 8004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9005, N'\uploads\8004\cadeira04.jpg', 8004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9006, N'\uploads\1\pcdell01.jpg', 1)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9007, N'\uploads\9004\webcam01.jpg', 9004)
INSERT INTO [dbo].[ImagensProdutos] ([Id], [Caminho], [ProdutoId]) VALUES (9008, N'\uploads\9009\pcapple01.jpg', 9009)
SET IDENTITY_INSERT [dbo].[ImagensProdutos] OFF

CREATE TABLE [dbo].[NewsletterEmails] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Email] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_NewsletterEmails] PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT [dbo].[NewsletterEmails] ON
INSERT INTO [dbo].[NewsletterEmails] ([Id], [Email]) VALUES (1, N'lucas@gmail.com')
INSERT INTO [dbo].[NewsletterEmails] ([Id], [Email]) VALUES (2, N'teste@gmail.com')
INSERT INTO [dbo].[NewsletterEmails] ([Id], [Email]) VALUES (1002, N'teste1@gmail.com')
INSERT INTO [dbo].[NewsletterEmails] ([Id], [Email]) VALUES (2002, N'teste2@gmail.com')
INSERT INTO [dbo].[NewsletterEmails] ([Id], [Email]) VALUES (3002, N'maria10@gmail.com')
SET IDENTITY_INSERT [dbo].[NewsletterEmails] OFF

CREATE TABLE [dbo].[Pedidos] (
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [ClienteId]            INT             NULL,
    [TransactionId]        VARCHAR (MAX)   NOT NULL,
    [FreteEmpresa]         VARCHAR (MAX)   NOT NULL,
    [FreteCodRastreamento] VARCHAR (MAX)   NULL,
    [FormaPagamento]       VARCHAR (MAX)   NOT NULL,
    [ValorTotal]           DECIMAL (18, 2) NOT NULL,
    [DadosTransaction]     VARCHAR (MAX)   NOT NULL,
    [DadosProdutos]        VARCHAR (MAX)   NOT NULL,
    [DataRegistro]         DATETIME        NOT NULL,
    [Situacao]             VARCHAR (MAX)   NOT NULL,
    [NFE]                  VARCHAR (MAX)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([Id])
);

SET IDENTITY_INSERT [dbo].[Pedidos] ON
INSERT INTO [dbo].[Pedidos] ([Id], [ClienteId], [TransactionId], [FreteEmpresa], [FreteCodRastreamento], [FormaPagamento], [ValorTotal], [DadosTransaction], [DadosProdutos], [DataRegistro], [Situacao], [NFE]) VALUES (8004, 4023, N'8334963', N'ECT - CORREIOS', N'PU302215682BR', N'BOLETO', CAST(121.00 AS Decimal(18, 2)), N'{"Id":"8334963","Installments":1,"Cost":0,"CardHolderName":null,"CardCvv":null,"CardLastDigits":null,"CardFirstDigits":null,"CardEmvResponse":null,"PostbackUrl":null,"PaymentMethod":1,"AntifraudScore":null,"BoletoUrl":"https://pagar.me","BoletoInstructions":null,"BoletoExpirationDate":"2020-04-27T03:00:00Z","BoletoBarcode":"1234 5678","Referer":"api_key","IP":"189.100.101.39","ShouldCapture":false,"Async":false,"LocalTime":null,"Metadata":{"Loaded":true},"Billing":null,"Shipping":{"Id":"953281","Name":"Endereço do cliente(JOANA FREITAS MELO)","Fee":2100,"DeliveryDate":"2020-04-30","Expedited":false,"Address":{"Id":"2759235","Street":"Rua dos Nenúfares","Complementary":"Apt. 287 Videiras","StreetNumber":"564","Neighborhood":"Cidade Jardim","City":"São Paulo","State":"SP","Zipcode":"05675000","Country":"br","Loaded":true},"Loaded":true},"Item":[{"Id":"9004","Title":"Webcam","UnitPrice":10000,"Quantity":1,"Tangible":true,"Date":null,"Venue":null,"Loaded":true}],"Events":null,"Payables":null,"Amount":12100,"Nsu":null,"Tid":null,"RefuseReason":null,"Card":null,"Customer":{"DocumentNumber":null,"DocumentType":0,"Name":"Joana Freitas Melo","Email":"joana@gmail.com","BornAt":null,"Gender":1,"Addresses":null,"Address":null,"Phones":null,"Phone":null,"ExternalId":"4023","Type":0,"Country":"br","Documents":[{"Type":0,"Number":"390.943.36006","Loaded":true}],"PhoneNumbers":["+551165544354"],"Birthday":"1980-11-20","Id":"2885873","DateCreated":"2020-04-25T17:22:43.421Z","DateUpdated":null,"Loaded":true},"AntifraudAnalysis":null,"Phone":null,"Status":4,"AuthorizationAmount":12100,"PaidAmount":0,"Address":null,"CardHash":null,"RefundedAmount":0,"SoftDescriptor":null,"AuthorizationCode":null,"AcquirerName":"pagarme","Postbacks":null,"StatusReason":"acquirer","CardExpirationDate":null,"CardNumber":null,"AcquirerResponseCode":null}', N'[{"QuantidadeCarrinhoProduto":1,"Id":9004,"Nome":"Webcam","Descricao":"Webcam boa","Valor":100.00,"Quantidade":14,"Peso":0.100,"Largura":11,"Altura":11,"Comprimento":20,"CategoriaId":10,"Categoria":null,"ImagemProduto":[{"Id":9007,"Caminho":"\\uploads\\9004\\webcam01.jpg","ProdutoId":9004,"ProdutoImagem":{"Id":9004,"Nome":"Webcam","Descricao":"Webcam boa","Valor":100.00,"Quantidade":14,"Peso":0.100,"Largura":11,"Altura":11,"Comprimento":20,"CategoriaId":10,"Categoria":null,"ImagemProduto":[]}}]}]', N'2020-04-25 14:21:51', N'DEVOLUÇÃO ACEITA', N'http://www.africau.edu/images/default/sample.pdf')
INSERT INTO [dbo].[Pedidos] ([Id], [ClienteId], [TransactionId], [FreteEmpresa], [FreteCodRastreamento], [FormaPagamento], [ValorTotal], [DadosTransaction], [DadosProdutos], [DataRegistro], [Situacao], [NFE]) VALUES (9004, 6023, N'8344425', N'ECT - CORREIOS', N'PU302215682BR', N'BOLETO', CAST(121.00 AS Decimal(18, 2)), N'{"Id":"8344425","Installments":1,"Cost":0,"CardHolderName":null,"CardCvv":null,"CardLastDigits":null,"CardFirstDigits":null,"CardEmvResponse":null,"PostbackUrl":null,"PaymentMethod":1,"AntifraudScore":null,"BoletoUrl":"https://pagar.me","BoletoInstructions":null,"BoletoExpirationDate":"2020-04-29T03:00:00Z","BoletoBarcode":"1234 5678","Referer":"api_key","IP":"189.100.101.39","ShouldCapture":false,"Async":false,"LocalTime":null,"Metadata":{"Loaded":true},"Billing":null,"Shipping":{"Id":"953974","Name":"Endereço do cliente(LUCAS EDUARDO)","Fee":2100,"DeliveryDate":"2020-05-03","Expedited":false,"Address":{"Id":"2762033","Street":"Avenida Yervant Kissajikian","Complementary":"Apt. 287 Videiras","StreetNumber":"123","Neighborhood":"Vila Constança","City":"São Paulo","State":"SP","Zipcode":"04657000","Country":"br","Loaded":true},"Loaded":true},"Item":[{"Id":"9004","Title":"Webcam","UnitPrice":10000,"Quantity":1,"Tangible":true,"Date":null,"Venue":null,"Loaded":true}],"Events":null,"Payables":null,"Amount":12100,"Nsu":null,"Tid":null,"RefuseReason":null,"Card":null,"Customer":{"DocumentNumber":null,"DocumentType":0,"Name":"Lucas Eduardo","Email":"lucaseduardoormond@gmail.com","BornAt":null,"Gender":0,"Addresses":null,"Address":null,"Phones":null,"Phone":null,"ExternalId":"6023","Type":0,"Country":"br","Documents":[{"Type":0,"Number":"220.525.70055","Loaded":true}],"PhoneNumbers":["+5511443259700"],"Birthday":"2001-07-10","Id":"2889478","DateCreated":"2020-04-27T20:34:38.568Z","DateUpdated":null,"Loaded":true},"AntifraudAnalysis":null,"Phone":null,"Status":4,"AuthorizationAmount":12100,"PaidAmount":0,"Address":null,"CardHash":null,"RefundedAmount":0,"SoftDescriptor":null,"AuthorizationCode":null,"AcquirerName":"pagarme","Postbacks":null,"StatusReason":"acquirer","CardExpirationDate":null,"CardNumber":null,"AcquirerResponseCode":null}', N'[{"QuantidadeCarrinhoProduto":1,"Id":9004,"Nome":"Webcam","Descricao":"Webcam boa","Valor":100.00,"Quantidade":15,"Peso":0.100,"Largura":11,"Altura":11,"Comprimento":20,"CategoriaId":10,"Categoria":null,"ImagemProduto":[{"Id":9007,"Caminho":"\\uploads\\9004\\webcam01.jpg","ProdutoId":9004,"ProdutoImagem":{"Id":9004,"Nome":"Webcam","Descricao":"Webcam boa","Valor":100.00,"Quantidade":15,"Peso":0.100,"Largura":11,"Altura":11,"Comprimento":20,"CategoriaId":10,"Categoria":null,"ImagemProduto":[]}}]}]', N'2020-04-27 17:33:45', N'DEVOLVER (EM TRANSPORTE)', N'http://www.africau.edu/images/default/sample.pdf')
INSERT INTO [dbo].[Pedidos] ([Id], [ClienteId], [TransactionId], [FreteEmpresa], [FreteCodRastreamento], [FormaPagamento], [ValorTotal], [DadosTransaction], [DadosProdutos], [DataRegistro], [Situacao], [NFE]) VALUES (9005, 4023, N'8344526', N'ECT - CORREIOS', NULL, N'BOLETO', CAST(2034.20 AS Decimal(18, 2)), N'{"Id":"8344526","Installments":1,"Cost":0,"CardHolderName":null,"CardCvv":null,"CardLastDigits":null,"CardFirstDigits":null,"CardEmvResponse":null,"PostbackUrl":null,"PaymentMethod":1,"AntifraudScore":null,"BoletoUrl":"https://pagar.me","BoletoInstructions":null,"BoletoExpirationDate":"2020-04-29T03:00:00Z","BoletoBarcode":"1234 5678","Referer":"api_key","IP":"189.100.101.39","ShouldCapture":false,"Async":false,"LocalTime":null,"Metadata":{"Loaded":true},"Billing":null,"Shipping":{"Id":"953978","Name":"Casa mãe","Fee":3420,"DeliveryDate":"2020-05-08","Expedited":false,"Address":{"Id":"2762061","Street":"Avenida Yervant Kissajikian","Complementary":"Apt. 16B","StreetNumber":"299","Neighborhood":"Vila Constança","City":"São Paulo","State":"SP","Zipcode":"04657000","Country":"br","Loaded":true},"Loaded":true},"Item":[{"Id":"1","Title":"Computador Dell","UnitPrice":200000,"Quantity":1,"Tangible":true,"Date":null,"Venue":null,"Loaded":true}],"Events":null,"Payables":null,"Amount":203420,"Nsu":null,"Tid":null,"RefuseReason":null,"Card":null,"Customer":{"DocumentNumber":null,"DocumentType":0,"Name":"Joana Freitas Melo","Email":"joana@gmail.com","BornAt":null,"Gender":1,"Addresses":null,"Address":null,"Phones":null,"Phone":null,"ExternalId":"4023","Type":0,"Country":"br","Documents":[{"Type":0,"Number":"390.943.36006","Loaded":true}],"PhoneNumbers":["+551165544354"],"Birthday":"1980-11-20","Id":"2889514","DateCreated":"2020-04-27T20:46:15.61Z","DateUpdated":null,"Loaded":true},"AntifraudAnalysis":null,"Phone":null,"Status":4,"AuthorizationAmount":203420,"PaidAmount":0,"Address":null,"CardHash":null,"RefundedAmount":0,"SoftDescriptor":null,"AuthorizationCode":null,"AcquirerName":"pagarme","Postbacks":null,"StatusReason":"acquirer","CardExpirationDate":null,"CardNumber":null,"AcquirerResponseCode":null}', N'[{"QuantidadeCarrinhoProduto":1,"Id":1,"Nome":"Computador Dell","Descricao":"i5, 8gb RAM e HD de 500gb. Perfeito para uso","Valor":2000.00,"Quantidade":8,"Peso":7.000,"Largura":15,"Altura":3,"Comprimento":30,"CategoriaId":1002,"Categoria":null,"ImagemProduto":[{"Id":9006,"Caminho":"\\uploads\\1\\pcdell01.jpg","ProdutoId":1,"ProdutoImagem":{"Id":1,"Nome":"Computador Dell","Descricao":"i5, 8gb RAM e HD de 500gb. Perfeito para uso","Valor":2000.00,"Quantidade":8,"Peso":7.000,"Largura":15,"Altura":3,"Comprimento":30,"CategoriaId":1002,"Categoria":null,"ImagemProduto":[]}}]}]', N'2020-04-27 17:45:22', N'ESTORNADO', NULL)
SET IDENTITY_INSERT [dbo].[Pedidos] OFF

CREATE TABLE [dbo].[PedidosSituacao] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [PedidoId] INT           NULL,
    [Data]     DATETIME      NOT NULL,
    [Situacao] VARCHAR (MAX) NOT NULL,
    [Dados]    VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedidos] ([Id])
);

SET IDENTITY_INSERT [dbo].[PedidosSituacao] ON
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (10002, 8004, N'2020-04-25 14:21:51', N'AGUARDANDO PAGAMENTO', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (10003, 8004, N'2020-04-25 17:23:57', N'PAGAMENTO APROVADO', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (10004, 8004, N'2020-04-25 14:23:51', N'NF EMITIDA', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (10005, 8004, N'2020-04-25 14:23:57', N'EM TRANSPORTE', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (10006, 8004, N'2020-04-25 14:21:51', N'ENTREGUE', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (10007, 8004, N'2020-04-25 14:28:28', N'DEVOLVER (EM TRANSPORTE)', N'{"Motivo":"desistencia","CodRastreamento":"PU33464563BR"}')
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (10008, 8004, N'2020-04-25 14:28:28', N'DEVOLVER (ENTREGUE)', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (11002, 8004, N'2020-04-26 21:43:15', N'DEVOLUÇÃO ACEITA', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (11003, 8004, N'2020-04-26 21:43:15', N'DEVOLVER (ESTORNADO)', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (12002, 9004, N'2020-04-27 17:33:46', N'AGUARDANDO PAGAMENTO', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (12003, 9004, N'2020-04-27 20:37:07', N'PAGAMENTO APROVADO', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (12004, 9004, N'2020-04-27 17:36:55', N'NF EMITIDA', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (12005, 9004, N'2020-04-27 17:37:05', N'EM TRANSPORTE', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (12006, 9004, N'2020-04-27 17:37:05', N'ENTREGUE', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (12007, 9004, N'2020-04-27 17:44:34', N'DEVOLVER (EM TRANSPORTE)', N'{"Motivo":"hrhtrh","CodRastreamento":"PU33464563BR"}')
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (12008, 9005, N'2020-04-27 17:45:22', N'AGUARDANDO PAGAMENTO', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (12009, 9005, N'2020-04-27 20:46:36', N'PAGAMENTO APROVADO', NULL)
INSERT INTO [dbo].[PedidosSituacao] ([Id], [PedidoId], [Data], [Situacao], [Dados]) VALUES (12010, 9005, N'2020-04-27 17:47:19', N'ESTORNADO', N'{"Motivo":"treyt534","FormaPagamento":"BOLETO","BancoCodigo":"001","Agencia":"2888","AgenciaDV":"8","Conta":"28889","ContaDV":"2","CPF":"509.217.928-75","Nome":"ELIAS"}')
SET IDENTITY_INSERT [dbo].[PedidosSituacao] OFF

CREATE TABLE [dbo].[RecuperacaoSenhas] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [Data]          DATETIME NOT NULL,
    [Chave]         INT      NOT NULL,
    [ClienteId]     INT      NULL,
    [ColaboradorId] INT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([Id]),
    FOREIGN KEY ([ColaboradorId]) REFERENCES [dbo].[Colaboradores] ([Id])
);
