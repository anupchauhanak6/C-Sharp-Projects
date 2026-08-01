# ATM Simulation System

![.NET](https://img.shields.io/badge/.NET-net10.0-blue)
![App Type](https://img.shields.io/badge/App-Console-success)

A clean, console-based ATM simulator built in C#.  
It demonstrates core object-oriented design principles with a layered architecture, transaction strategy pattern, and friendly terminal interaction.

## Overview

This project simulates a basic ATM workflow:

- Authenticate with account number and PIN
- Check account balance
- Deposit money
- Withdraw money
- Exit safely

The implementation is intentionally simple and in-memory, making it easy to understand, extend, and test.

## Features

- Layered design: **UI → Services → Domain Models**
- Strategy-based transactions via `ITransaction`
- In-memory seeded accounts for quick local runs
- Input validation and custom exception handling
- Clear separation of responsibilities across folders

## Prerequisites

- .NET SDK **10.0+**
  - Project target framework: `net10.0`

## Quick Start

From `/ATM-Simulation-System`:

```bash
dotnet build
dotnet run
```

When prompted, sign in using one of the seeded accounts:

- `ACC1001` / `1234`
- `ACC1002` / `4321`

## Setup

1. Clone the repository.
2. Open a terminal in:
   `/ATM-Simulation-System`
3. Run:

```bash
dotnet build
dotnet run
```

## Usage

After login, choose from the main menu:

1. Check Balance
2. Deposit Money
3. Withdraw Money
4. Exit

### Example Session

```text
========================================
    WELCOME TO ATM SIMULATION SYSTEM
========================================

Enter Account Number: ACC1001
Enter 4-Digit pin: 1234

1. Check Balance
2. Deposit Money
3. Withdraw Money
4. Exit
```

## Architecture

The project follows a modular structure:

- **Models** store domain data (`BankAccount`, `User`)
- **Interfaces** define contracts (`IATMEngine`, `ITransaction`)
- **Services** orchestrate application flow (`ATMEngine`)
- **Transactions** encapsulate operation logic (deposit, withdraw, transfer)
- **UI** handles console output/input (`MenuDisplay`, `InputReader`)
- **Exceptions** define domain-specific errors

### Key Design Choices

- **Open/Closed Principle:** add new transaction types by implementing `ITransaction`
- **Single Responsibility Principle:** each layer has a focused role
- **Graceful error handling:** transaction failures are caught and shown as user-friendly messages

## Project Structure

```text
ATM-Simulation-System/
├── Exceptions/
│   ├── InsufficientFundsException.cs
│   └── InvalidPinException.cs
├── Interfaces/
│   ├── IATMEngine.cs
│   └── ITransaction.cs
├── Models/
│   ├── BankAccount.cs
│   └── User.cs
├── Services/
│   ├── ATMEngine.cs
│   └── Transactions/
│       ├── DepositTransaction.cs
│       ├── TransferTransaction.cs
│       └── WithdrawTransaction.cs
├── UI/
│   ├── InputReader.cs
│   └── MenuDisplay.cs
├── Program.cs
└── ATM-Simulation-System.csproj
```

## Testing

There is currently no test project in this repository.

If you want to add tests, a typical setup is:

```bash
dotnet new xunit -o tests/ATM.Tests
dotnet add tests/ATM.Tests reference ATM-Simulation-System.csproj
dotnet test
```

Recommended test focus:

- `ATMEngine` authentication and menu flow
- Deposit/withdraw transaction behavior
- Exception paths (e.g., insufficient funds)

## Contributing

Contributions are welcome. Please keep PRs focused and easy to review:

1. Fork the repository
2. Create a feature branch
3. Make focused changes with clear commit messages
4. Add tests for behavior changes where possible
5. Open a pull request with a concise summary

## License / Status

No license file is currently present in this project.
