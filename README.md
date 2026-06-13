# Banking-API
API REST para gerenciamento de contas bancárias, permitindo consulta de saldo, depósitos, saques e transferências entre contas.

## Tecnologias 
.NET 10
ASP.NET Core Web API
xUnit

## Como executar
dotnet run --project Banking_API

## Executar testes
dotnet test

## Endpoints
POST /reset - Reseta o estado do sistema.
GET /balance?account_id={id} - Consulta o saldo da conta.
POST /event - Processa um evento.

Exemplo de payload para /event:
```json
{
  "type": "deposit",
  "destination": "100",
  "amount": 10
}
```

## Decisões de implementação
- Armazenamento em memória.
- AccountService registrado como Singleton.
- Regras de negócio concentradas na camada de serviço.
- Testes unitários para os principais cenários.