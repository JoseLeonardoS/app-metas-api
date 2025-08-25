# 🎯 App Metas API

Backend da aplicação **Goals & Tasks**, desenvolvida em **ASP.NET Core** com **Entity Framework Core InMemory**.  
Esta API fornece endpoints para gerenciamento de **Metas (Goals)** e **Tarefas (Tasks)**, consumidos por um frontend em React.

---

## 🚀 Tecnologias Utilizadas
- **ASP.NET Core 8**
- **Entity Framework Core InMemory**
- **C#**
- **REST API**
- **Render** (deploy do backend)

---

## 🔗 Links Importantes
- 📂 **Repositorio Frontend:** [Clique aqui](https://github.com/JoseLeonardoS/app_metas_react)
- 🌐 **Live Demo (Fullstack):** [Acesse aqui](https://joseleonardos.github.io/app_metas_react)

---

## 📌 Funcionalidades
- ✅ Criar, listar, atualizar e deletar **Metas**  
- ✅ Marcar metas como concluídas  
- ✅ Criar, listar, atualizar e deletar **Tarefas**  
- ✅ Vincular tarefas a metas específicas  
- ✅ API simples, ideal para estudo de integração **React + .NET**  

---

## ⚙️ Instalação e Execução Local

### 1. Clone o repositório
```bash
git clone https://github.com/usuario/backend-repo.git
cd backend-repo
```

### 2. Restaure os pacotes
```bash
dotnet restore
```

### 3. Execute o projeto
```bash
dotnet run
```

### A API será executada em:
```bash
http://localhost:7062
```

## 📖 Documentação dos Endpoints

### 📌 Goals (Metas)

| Método | Rota                       | Descrição                   |
|--------|----------------------------|-----------------------------|
| GET    | `/api/goals/listar`        | Lista todas as metas        |
| GET    | `/api/goals/{id}`          | Busca meta por ID           |
| POST   | `/api/goals/criar`         | Cria uma nova meta          |
| PUT    | `/api/goals/check`         | Marca meta como concluída   |
| PUT    | `/api/goals/atualizar`     | Atualiza uma meta existente |
| DELETE | `/api/goals/deletar/{id}`  | Remove uma meta             |

### 📌 Tasks (Tarefas)

| Método | Rota                                | Descrição                          |
|--------|-------------------------------------|------------------------------------|
| GET    | `/api/task/listar`                  | Lista todas as tarefas             |
| GET    | `/api/task/listar-meta-Id/{goalId}` | Lista tarefas de uma meta específica |
| GET    | `/api/task/{id}`                    | Busca tarefa por ID                |
| POST   | `/api/task/criar`                   | Cria uma nova tarefa               |
| PUT    | `/api/task/check`                   | Marca tarefa como concluída        |
| PUT    | `/api/task/atualizar`               | Atualiza uma tarefa existente      |
| DELETE | `/api/task/deletar/{id}`            | Remove uma tarefa                  |


## 📂 Estrutura de Resposta Padrão

Todos os endpoints retornam a seguinte estrutura:

```bash
{
  "data": {...},
  "message": "Menssagem de sucesso",
  "status": true
}
```


Exemplo:

```bash
{
  "data": {
    "id": 1,
    "title": "Estudar ASP.NET",
    "description": "Praticar criando uma API",
    "isCompleted": false,
    "tasks": null,
    "createdAt": "2025-08-25T03:35:11.5837577Z",
    "updatedAt": "2025-08-25T03:35:11.5837983Z",
    "dueDate": "2025-08-24T12:00:00"
  },
  "message": "Tarefa criada com sucesso.",
  "status": true
}
```

## 🌐 Deploy

O backend está hospedado no **Render**.

O frontend está hospedado em **Github Pages**.

## ✨ Autor
👤 Desenvolvido por **José Leonardo**  

🔗 [LinkedIn](https://www.linkedin.com/in/josé-l-67243b252)
