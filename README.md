# 💰 Minhas Finanças - Backend & Core Domain

> Sistema de gestão financeira pessoal e familiar construído com foco em **Clean Architecture**, **Domain-Driven Design (DDD)** e boas práticas de engenharia de software em **.NET 8 / 9**.

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-blue?style=for-the-badge)
![Tests](https://img.shields.io/badge/Tests-xUnit-brightgreen?style=for-the-badge)

---

## 📌 Sobre o Projeto

O projeto nasceu de uma necessidade real: substituir uma planilha financeira complexa e manual utilizada diariamente por mim e minha esposa por um ecossistema completo, confiável e automatizado.

O principal objetivo técnico deste repositório é servir como base sólida para uma aplicação escalável, aplicando os princípios do livro **"Clean Architecture" (Robert C. Martin - Uncle Bob)** e conceitos táticos do **DDD (Domain-Driven Design)**, garantindo que o núcleo de regras financeiras seja completamente desacoplado de frameworks, bibliotecas externas e banco de dados.

---

## 🏛️ Arquitetura e Estrutura da Solução

A solução segue a divisão clássica em camadas concêntricas, onde a dependência aponta sempre **de fora para dentro**:

```text
MinhasFinancas/
│
├── 🧠 MinhasFinancas.Dominio/          # O coração do negócio (Sem dependências externas)
│   ├── Entidades/                     # Entidades ricas com encapsulamento de regras
│   │   ├── CartaoCredito.cs           # Controle de limites e faturas
│   │   ├── Conta.cs                   # Saldos, débitos e créditos
│   │   ├── Transacao.cs               # Registro imutável de movimentações
│   │   ├── Divida.cs                  # Amortização e cálculo de saldo devedor
│   │   └── Investimento.cs            # Aportes, retiradas e rendimentos
│   ├── ObjetosValor/                  # Value Objects (Imutabilidade e auto-validação)
│   │   ├── ValorMonetario.cs          # Evita primitive obsession e valores negativos inválidos
│   │   ├── Texto.cs                   # Regras de tamanho e sanitização
│   │   └── DiaMes.cs                  # Validação de dias válidos para vencimentos
│   └── Servicos/                      # Serviços de domínio puros
│       └── CalculadoraFinanceira.cs   # Cálculo de patrimônio e saldo livre real
│
├── ⚙️ MinhasFinancas.Aplicacao/        # Casos de Uso (Orquestração do fluxo)
│   ├── CasosDeUso/                    # Implementação direta de Use Cases isolados
│   │   ├── RegistrarDespesaNoDebito/
│   │   ├── RegistrarGastoNoCartao/
│   │   ├── RealizarTransferencia/
│   │   ├── ListarTransacoesDoMes/
│   │   └── ObterResumoMensal/
│   └── Interfaces/                    # Contratos de repositórios (DIP - Dependency Inversion)
│
├── 🌐 MinhasFinancas.Api/              # Camada de Apresentação (ASP.NET Core Web API)
│   ├── Controllers/                   # Endpoints RESTful enxutos delegando para os Casos de Uso
│   └── Fakes/                         # Implementações em memória para testes e prototipação rápida
│
├── 💾 MinhasFinancas.Infraestrutura/   # (Em desenvolvimento) Persistência com EF Core / APIs bancárias
│
└── 🧪 MinhasFinancas.Teste/            # Testes Unitários de Domínio e Casos de Uso com xUnit
