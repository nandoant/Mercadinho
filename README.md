# Projeto Mercadinho
Este projeto simula um sistema de gestão intuitivo e fácil de usar, ideal para uso interno em pequenas lojas e comércios. Desenvolvido com <strong>C#(.NET)</strong> no backend, <strong>Windows Forms</strong> no frontend e banco de dados <strong>MySQL</strong>, o sistema demonstra a aplicação da arquitetura <strong>MVP (Model-View-Presenter)</strong> em um cenário prático. <br>
![image](https://github.com/nandoant/Mercadinho/blob/master/Mercadinho/prints/carrinho.png)
![image](https://github.com/nandoant/Mercadinho/blob/master/Mercadinho/prints/vendas.png)
![image](https://github.com/nandoant/Mercadinho/blob/master/Mercadinho/prints/clientes.png)
# Como Rodar o Projeto

Este guia contém os passos necessários para configurar e rodar o projeto.

## Pré-requisitos

Antes de começar, certifique-se de ter os seguintes programas instalados em sua máquina:
- [MySQL](https://dev.mysql.com/downloads/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)

## Configuração do Projeto

Siga as etapas abaixo para configurar e rodar o projeto:

### 1. Acesse o Diretório do Projeto
Navegue até o diretório `/Mercadinho` no seu sistema de arquivos.

### 2. Configure o Arquivo `App.config`
1. Abra o arquivo `App.config` no editor de sua preferência.
2. Localize o seguinte trecho de código no arquivo:
   ```xml
   <connectionStrings>
       <add name="MySQL" 
            connectionString="Server=localhost; Port=3306; Database=mercadinho; Uid=root; Pwd='root';" 
            providerName="MySql.Data.MySqlClient" />
   </connectionStrings>
### 3. Atualize as Credenciais de Conexão
1. Substitua `Uid=root` pelo login do seu MySQL.
2. Substitua `Pwd='root'` pela senha do seu MySQL.

### 4. Configure o Banco de Dados
1. Acesse o MySQL usando o terminal ou uma ferramenta gráfica, como o MySQL Workbench.
2. Crie um schema chamado `mercadinho` com o seguinte comando:
   ```sql
   CREATE SCHEMA mercadinho;
### 5. Rode o Projeto
1. Abra o projeto no Visual Studio 2022.
2. Compile e execute o programa diretamente no Visual Studio.
