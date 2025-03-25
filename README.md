# 🧪 Projeto MyTestSales - Avaliação Técnica

Este projeto simula um sistema de controle de vendas e produtos, com foco em boas práticas de desenvolvimento backend, arquitetura em camadas e execução com Docker.

## 🚀 Tecnologias Utilizadas

- **.NET 8.0**
- **C#**
- **EF Core**
- **AutoMapper**
- **Ocelot**
- **Docker**
- **Docker Compose**
- **Jenkins** (opcional para CI/CD)

---

## ▶️ Como Executar

1. Crie a rede Docker (caso não exista):

```bash
docker network create evaluation-network
```

2. Suba os serviços com Docker Compose:

```bash
docker-compose up -d --build
```

> O sistema estará acessível via **Ocelot Gateway** na porta `7777`.

---

## 📦 Estrutura

```
MyTest/
├── docker-compose.yml
├── Jenkinsfile
├── MyTest.sln
├── src/
│   ├── Gateway/         # API Gateway com Ocelot
│   │   └── Dockerfile
│   └── SalesApi/        # API principal de vendas
│       └── Dockerfile
```

---

## 📌 Endpoints Requeridos

| Método | Endpoint         | Descrição                   |
|--------|------------------|-----------------------------|
| GET    | /products        | Lista produtos              |
| POST   | /products        | Cria um novo produto        |
| GET    | /sales           | Lista todas as vendas       |
| POST   | /sales           | Cria uma nova venda         |
| DELETE | /sales/{id}      | Cancela uma venda           |

Base URL: `http://ocelot-gateway:7777`

---

## 🧠 Regras de Negócio

- **4 a 9 itens iguais** → 10% de desconto
- **10 a 20 itens iguais** → 20% de desconto
- **Mais de 20** → Não é permitido
- **Menos de 4 itens** → Sem desconto

---

## 🛠️ CI/CD com Jenkins

Um `Jenkinsfile` está incluído com pipeline que:

- Clona o repositório
- Sobe o ambiente com Docker
- Executa os testes automatizados
- Derruba os containers

---

## ✅ Checklist

- [x] Docker funcional com `docker-compose up -d --build`
- [x] APIs REST com retorno padronizado
- [x] Aplicação das regras de desconto
- [x] Gateway configurado (porta 7777)
- [x] Jenkinsfile para CI (opcional)

---

## 📝 Licença

Este projeto é apenas para fins de avaliação técnica.