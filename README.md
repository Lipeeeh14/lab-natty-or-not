# Guia de Receitas

## 📒 Descrição
Esse projeto possibilita a geração de uma página simples indicando uma receita criada a partir de um ingrediente passado.

## 🤖 Tecnologias Utilizadas
### Back-end
Linguagem: C#
Framework: .NET 8

### Front-end
Linguagem: Typescript
Framework: Vue.js

## 🧐 Processo de Criação
Foi criado uma web API a partir do template abaixo e, com um endpoint post simples que recebe um campo string referente ao ingrediente,
é realizado a integração com a API da OpenIA para a geração do html contendo a receita.
Assim o front faz a requisição no endpoint dessa API enviando o ingrediente informado e exibe o resultado em tela   

Template: ASP.NET Core Web API

## 🚀 Resultados
O resultado possibilita a visualização de uma receita simples que pode ser utilizada para fazer algum prato a partir de um ingrediente.