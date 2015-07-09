#language: pt-br

Funcionalidade: Cadastro de um novo produto
Cenário: Cadastrar um novo produto do zero
	Dado que eu estou na tela de listagem
	E eu sou um usuário com permissão para cadastrar
	Quando eu clicar no link de Novo Produto
	E preencher o nome do produto
	E preencher o preço do produto
	E clicar no botão create
	Então deve direcionar para a tela de listagem com o produto cadastrado

Cenário: Cadastrar um produto que já existe
	Dado que eu estou na tela de listagem
	E eu sou um usuário com permissão para cadastrar
	Quando eu clicar no link de Novo Produto
	E preencher o nome do produto
	E preencher o preço do produto
	E clicar no botão create
	Entao deve mostrar uma mensagem de erro "Produto já existe"