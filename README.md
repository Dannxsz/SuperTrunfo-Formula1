# Super Trunfo - Fórmula 1

Aplicação Console em C# com tema de Fórmula 1, criada para trabalho acadêmico de programação.

## Requisitos atendidos

- Aplicação Console em C#.
- Classes separadas por responsabilidade.
- Tratamento de exceções com `try/catch`.
- Exceções personalizadas.
- Testes de unidade com xUnit.
- Solução organizada em `ConsoleApp`, `Core` e `Tests`.
- Tema: pilotos e equipes da Fórmula 1.

## Pré-requisito

Instalar o **.NET 8 SDK**.

Confirme no terminal:

```powershell
dotnet --version
```

## Estrutura

```text
SuperTrunfo_Formula1/
├── src/
│   ├── SuperTrunfo.ConsoleApp/
│   └── SuperTrunfo.Core/
├── tests/
│   └── SuperTrunfo.Tests/
├── SuperTrunfo.sln
├── ROTEIRO_DEFESA.md
├── PASSO_A_PASSO_APRESENTACAO.md
├── CHECKLIST_RUBRICA.md
└── GITHUB_COMO_PUBLICAR.md
```

## Executar o jogo

Na pasta raiz do projeto:

```powershell
dotnet restore
dotnet run --project src/SuperTrunfo.ConsoleApp/SuperTrunfo.ConsoleApp.csproj
```

## Executar os testes

```powershell
dotnet test tests/SuperTrunfo.Tests/SuperTrunfo.Tests.csproj
```

## Link do GitHub

Depois de publicar, substitua o link abaixo pelo repositório real:

```text
https://github.com/SEU-USUARIO/SuperTrunfo-Formula1
```

## Observação sobre os dados das cartas

Os valores usados nas cartas são **didáticos e aproximados**. Eles servem para demonstrar a lógica de comparação do jogo e não devem ser tratados como uma base oficial de estatísticas da temporada de 2026.
