# ATM Simulation System

A console-based ATM simulation written in C# that demonstrates a layered, testable design using interfaces, domain models, service classes, and a small UI layer. This README gives a quick-start, usage examples, design notes, and development guidance.

## Quick start

1. Ensure .NET SDK 10.0 or later is installed.
2. From the project root, build and run:

```bash
dotnet build
dotnet run
```

The program runs as an interactive console application. Follow prompts to sign in and perform transactions.

## Features

- In-memory bank account and user models with PIN checks
- Transactions implemented as interchangeable strategies: Deposit, Withdraw, Transfer
- Simple console UI layer (`MenuDisplay`, `InputReader`) for user interaction
- Domain-specific exceptions (`InsufficientFundsException`, `InvalidPinException`)

## Requirements

- .NET SDK 10.0+ (project targets `net10.0`)

## Usage and examples

- Start the app: `dotnet run`.
- Authentication: supply the user ID and PIN when prompted.

Example flow (user input shown after >):

```text
Welcome to ATM
Enter user id: > 1001
Enter PIN: > 1234
1) Check balance
2) Deposit
3) Withdraw
4) Transfer
5) Exit
Choose: > 2
Enter amount to deposit: > 250.00
Deposit successful. New balance: 1250.00
```

Transactions validate inputs and throw domain exceptions for invalid operations. The engine catches and displays friendly messages for these exceptions.

## Design & architecture

- Layered structure: UI → Services (ATMEngine) → Domain models
- Open/Closed: transactions implement `ITransaction` so new types can be added without modifying engine logic
- Single Responsibility: models hold data/validation, services perform orchestration, UI handles rendering and input

### Key types

- `BankAccount` — holds account id, owner, balance, and PIN check logic
- `ITransaction` — contract for executing a transaction
- `ATMEngine` — manages session, authentication, and invoking transactions

## Error handling

- `InsufficientFundsException` is thrown when withdrawing/transferring more than the balance
- `InvalidPinException` is thrown for incorrect authentication

The `ATMEngine` or top-level UI should catch these and display user-friendly messages rather than crashing.

## Project structure

The repository layout (for quick reference):

```
ATM.ConsoleApp/
│
├── 📁 Models/                      --> Domain Data Classes (Encapsulation)
│   ├── BankAccount.cs              --> Account data, Balance, PIN checks
│   └── User.cs                     --> User profile details (Name, ID)
│
├── 📁 Interfaces/                  --> Architectural Contracts (Abstraction)
│   ├── ITransaction.cs             --> Execution contract for all transactions
│   └── IATMEngine.cs               --> Contract for ATM operations
│
├── 📁 Services/                    --> Core Logic & Polymorphism
│   ├── ATMEngine.cs                --> ATM lifecycle & user flow manager
│   └── Transactions/               --> Specific transaction strategies
│       ├── DepositTransaction.cs   --> Deposit implementation
│       ├── WithdrawTransaction.cs  --> Withdrawal implementation
│       └── TransferTransaction.cs  --> Account-to-Account transfer logic
│
├── 📁 UI/                          --> User Interaction Layer
│   ├── MenuDisplay.cs              --> Screen rendering & menu options
│   └── InputReader.cs              --> User inputs validation & reading
│
├── 📁 Exceptions/                  --> Custom Application Errors
│   ├── InsufficientFundsException.cs
│   └── InvalidPinException.cs
│
└── Program.cs                      --> Entry Point (App Bootstrapper)
```

## Development notes

- Add a new transaction:
  1.  Implement `ITransaction`.
  2.  Add the concrete class under `Services/Transactions`.
  3.  Register or instantiate it where the engine chooses transactions (search for transaction factory/selector in `ATMEngine`).

- Replace in-memory storage with persistence by introducing a repository interface (e.g., `IAccountRepository`) and swapping implementations for tests vs production.

## Testing

There are no tests included by default. To add tests, create an xUnit or NUnit test project and target the service classes (`ATMEngine`) and individual transaction implementations.

Example: create test project and run tests

```bash
dotnet new xunit -o tests/ATM.Tests
dotnet add tests/ATM.Tests reference ATM-Simulation-System.csproj
dotnet test
```

## Contributing

- Fork, create a topic branch, and open a pull request with a clear description.
- Add unit tests for new behavior and keep changes focused.

If you want, I can also:

- Add a sample seed data loader and quick-start accounts in `Program.cs`.
- Create a test project with unit tests for `ATMEngine` and transactions.
- Add a `Makefile` or PowerShell script for common development commands.

## License

This project does not include a license file. If you want one, I can add a permissive `MIT` license or another license you choose.
