# Sistema de Gestão de Colaboradores e Unidades em C# com PostgreSQL

Este é um projeto de backend que implementa um Sistema de Gestão de Colaboradores e Unidades, utilizando o PostgreSQL como banco de dados.

## **Funcionalidades**
* Cadastro de Unidades: O sistema permite o cadastro de unidades, associando um ID único e um nome à unidade.
* Atualização de Unidades: As unidades podem ser inativadas, e quando inativadas não podem permitir a inclusão de novos colaboradores.
* Cadastro de Colaboradores: Os colaboradores podem ser cadastrados com um código único, nome e relacionados a uma unidade específica.
* Atualização de Informações: É possível atualizar as informações de colaboradores, incluindo o nome e a unidade à qual estão associados.
* Remoção de Colaboradores: Os colaboradores podem ser removidos do sistema.
* Listagem de Colaboradores: O sistema oferece a funcionalidade de listar todos os colaboradores cadastrados, exibindo seus códigos, nomes e unidades associadas.

## **Diferenciais**
* Utilização do Docker para criação do banco de dados.

## Passos para envio da avaliação
* Crie uma nova branch a partir da master (com seu nome do git e data, ex.: feature/devrte-20231220).
* Envie um PR para branch principal para sabermos que sua avaliação foi finalizada. **Obs.: só será aceito o commit do primeiro PR**.
