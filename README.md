# SpaceAces
Case Técnico - SpaceAces

# Requisitos técnicos
- Para executar o projeto é necessário ter uma instância do banco de dados relacional MySQL (Pode ser uma imagem docker).
- É possível criar a instância do Mysql usando docker atráves do arquivo pré-configurado no projeto: docker-compose.yaml (Execute o comando docker-compose up na raíz do projeto com seu docker em execução)
- O script de criação do database suas tabelas encontra-se no projeto com o nome dump-spacecaps-202404082144.sql

# Collection
- A collection com as requets pré configuradas podem ser importadas para sua ferramenta de preferência através do arquivo: SpaceCaps.postman_collection.json
- É exposto uma rota de documentação das rotas através da url ${localhost}/swagger/index.html -> Example: http://localhost:5002/swagger/index.html

## Projeto 
- Apenas a rota de criação de usuário não precisa de autenticação de um token JWT para ser executada. Nesse sentido é obrigatório que crie-se um usuário para que possa executar a rota de login, obter o seu token JWT e a partir desse momento conseguir utilizar as outras rotas da solução.

### Níver de usuário
- Atualmente foi configurado apenas 2 níveis de usuário:
 - 1 : ADMINISTRADOR
 - 2 : COMUM
 
Esses níveis de usuários são criados através do script de criação do banco de dados: dump-spacecaps-202404082144.sql
Dessa forma é obrigatório a execução do banco de dados antes da aplicação.

-------------------------------------------------------------------------------------------------------------------	
# Controller de Login

Esta é a controller responsável pela autenticação de usuários na API.

## Endpoints

### Validação de Login

- **URL:** `POST /api/Login/valida`
- **Descrição:** Este endpoint valida as credenciais do usuário e retorna um token de acesso se as credenciais forem válidas.
- **Corpo da Requisição:**
  ```json
  {
    "usuario": "string",
    "senha": "string"
  }```
  
- **Resposta de Sucesso:** Retorna um código de status HTTP 200 OK junto com um token de acesso válido.
- **Resposta de Erro:** Retorna um código de status HTTP 401 Unauthorized se as credenciais forem inválidas.
- **Parâmetros**
	- usuario (string): Nome de usuário.
	- senha (string): Senha do usuário.

-------------------------------------------------------------------------------------------------------------------	
# Controller de Usuário

Esta é a controller responsável por lidar com operações relacionadas aos usuários na API.

## Endpoints

### Obter Usuário por ID

- **URL:** `GET /api/Usuario/{id}`
- **Descrição:** Este endpoint retorna as informações de um usuário com o ID especificado.
- **Parâmetros de Requisição:**
  - `id` (int): O ID do usuário a ser obtido.
- **Cabeçalhos de Autorização:**
  - Este endpoint requer um token de acesso válido no cabeçalho de autorização.
- **Resposta de Sucesso:** Retorna um código de status HTTP 200 OK junto com as informações do usuário.
- **Resposta de Erro:** Retorna um código de status HTTP 400 Bad Request se o ID do solicitante não estiver presente nos cabeçalhos.

### Obter Todos os Usuários

- **URL:** `GET /api/Usuario`
- **Descrição:** Este endpoint retorna uma lista de todos os usuários cadastrados.
- **Cabeçalhos de Autorização:**
  - Este endpoint requer um token de acesso válido no cabeçalho de autorização.
- **Resposta de Sucesso:** Retorna um código de status HTTP 200 OK junto com a lista de usuários.
- **Resposta de Erro:** Retorna um código de status HTTP 400 Bad Request se o ID do solicitante não estiver presente nos cabeçalhos.

### Criar Usuário

- **URL:** `POST /api/Usuario/create`
- **Descrição:** Este endpoint cria um novo usuário com as informações fornecidas no corpo da requisição.
- **Corpo da Requisição:**
  ```json
  {
    "nome": "string",
    "email": "string",
    "senha": "string"
  }```
  
- **Resposta de Sucesso:** Retorna um código de status HTTP 200 OK junto com as informações do usuário recém-criado.
- **Resposta de Erro:** Retorna um código de status HTTP 400 Bad Request se ocorrer algum erro ao criar o usuário.
### Parâmetros
	- id (int): O ID do usuário a ser obtido.
	- nome (string): Nome do usuário.
	- email (string): Endereço de e-mail do usuário.
	- senha (string): Senha do usuário.
	- IdSolicitante (string): ID do solicitante presente nos cabeçalhos de autorização.

-------------------------------------------------------------------------------------------------------------------	

# Controller de Tarefa

Esta é a controller responsável por lidar com operações relacionadas às tarefas na API.

## Endpoints

### Criar Tarefa

- **URL:** `POST /api/Tarefa/create`
- **Descrição:** Este endpoint cria uma nova tarefa com as informações fornecidas no corpo da requisição.
- **Corpo da Requisição:**
  ```json
  {
    "descricao": "string",
    "status": "string"
  }
  
- **Cabeçalhos de Autorização:** Este endpoint requer um token de acesso válido no cabeçalho de autorização.
- **Resposta de Sucesso:** Retorna um código de status HTTP 200 OK junto com as informações da tarefa recém-criada.
- **Resposta de Erro:** Retorna um código de status HTTP 400 Bad Request se ocorrer algum erro ao criar a tarefa.

### Atualizar Tarefa
- **URL:** PUT /api/Tarefa/update
- **Descrição:** Este endpoint atualiza uma tarefa existente com as informações fornecidas no corpo da requisição.

Corpo da Requisição:
```json
{
  "id": "int",
  "descricao": "string",
  "status": "string"
}

- **Cabeçalhos de Autorização: Este endpoint requer um token de acesso válido no cabeçalho de autorização.
- **Resposta de Sucesso: Retorna um código de status HTTP 200 OK junto com as informações da tarefa atualizada.
- **Resposta de Erro: Retorna um código de status HTTP 400 Bad Request se ocorrer algum erro ao atualizar a tarefa.

### Apagar Tarefa

- **URL:** DELETE /api/Tarefa/{id}
- **Descrição:** Este endpoint exclui a tarefa com o ID especificado.
- **Parâmetros de Requisição:**
	- id (int): O ID da tarefa a ser excluída.
- ** Cabeçalhos de Autorização:** Este endpoint requer um token de acesso válido no cabeçalho de autorização.
- **Resposta de Sucesso:** Retorna um código de status HTTP 200 OK junto com uma mensagem indicando que a tarefa foi excluída com sucesso.
- **Resposta de Erro:** Retorna um código de status HTTP 400 Bad Request se ocorrer algum erro ao excluir a tarefa.


### Obter Todas as Tarefas
- **URL:** GET /api/Tarefa
- **Descrição:** Este endpoint retorna uma lista de todas as tarefas cadastradas.
- **Cabeçalhos de Autorização:** Este endpoint requer um token de acesso válido no cabeçalho de autorização.
- **Resposta de Sucesso:** Retorna um código de status HTTP 200 OK junto com a lista de tarefas.
- **Resposta de Erro:** Retorna um código de status HTTP 400 Bad Request se ocorrer algum erro ao obter as tarefas.


### Obter Tarefa por ID
- **URL:** GET /api/Tarefa/{id}
- **Descrição:** Este endpoint retorna as informações da tarefa com o ID especificado.
- **Parâmetros de Requisição:**
	- id (int): O ID da tarefa a ser obtida.
- **Cabeçalhos de Autorização:** Este endpoint requer um token de acesso válido no cabeçalho de autorização.
- **Resposta de Sucesso:** Retorna um código de status HTTP 200 OK junto com as informações da tarefa.
- **Resposta de Erro:** Retorna um código de status HTTP 400 Bad Request se ocorrer algum erro ao obter a tarefa.
- **Parâmetros**
	- id (int): O ID da tarefa a ser operada.
	- descricao (string): Descrição da tarefa.
	- status (string): Status da tarefa (por exemplo, "Em andamento", "Concluída").
	- IdSolicitante (string): ID do solicitante presente nos cabeçalhos de autorização.