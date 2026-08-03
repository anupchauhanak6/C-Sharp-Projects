# ATM Simulation System

A clean, console-based ATM application in C# focused on object-oriented design, maintainability, and extensibility.

## Why this project is strong

- Layered design: **UI -> Service -> Domain**
- Clear abstraction for transactions via `ITransaction`
- Input validation at UI and transaction boundaries
- Domain-specific error handling (`InsufficientFundsException`)
- Easy path to add new transaction types

## Tech stack

| Item | Value |
| --- | --- |
| Language | C# |
| Runtime | .NET 10 |
| Project type | Console App |
| Target framework | `net10.0` |

## Quick start

```bash
dotnet build
dotnet run
```

## Demo accounts

The app starts with in-memory seeded accounts in `ATMEngine`:

| Account Number | PIN | Account Holder |
| --- | --- | --- |
| `ACC1001` | `1234` | Rahul Sharma |
| `ACC1002` | `4321` | Priya Verma |

## Available operations

- Authenticate with account number and PIN
- Check balance
- Deposit money
- Withdraw money
- Exit session

`TransferTransaction` is implemented in `Services/Transactions/TransferTransaction.cs`, but it is not currently connected to the main menu flow.

## Example run

```text
========================================
    WELCOME TO ATM SIMULATION SYSTEM
========================================

Enter Account Number: ACC1001
Enter 4-Digit pin: 1234

----------------------------------------
              MAIN MENU
----------------------------------------
1. Check Balance
2. Deposit Money
3. Withdraw Money
4. Exit
----------------------------------------
```

## Architecture overview

```text
Program.cs
  -> ATMEngine (service orchestration)
      -> MenuDisplay + InputReader (UI)
      -> BankAccount + User (domain models)
      -> ITransaction implementations (business actions)
```

### Core components

- `Program.cs`: application entry point
- `Services/ATMEngine.cs`: authentication, menu loop, transaction execution
- `Models/BankAccount.cs`: PIN validation, debit/credit, balance state
- `Models/User.cs`: account holder identity data
- `Interfaces/ITransaction.cs`: transaction contract (`Execute`)
- `Services/Transactions/*`: deposit, withdraw, transfer strategies
- `UI/MenuDisplay.cs`: menu and styled messages
- `UI/InputReader.cs`: safe console input parsing
- `Exceptions/InsufficientFundsException.cs`: domain error for invalid withdrawal/transfer balance

## Project structure

```text
ATM-Simulation-System/
├── 📁 Exceptions/
│   └── InsufficientFundsException.cs
├── 📁 Interfaces/
│   ├── IATMEngine.cs
│   └── ITransaction.cs
├── 📁 Models/
│   ├── BankAccount.cs
│   └── User.cs
├── 📁 Services/
│   ├── ATMEngine.cs
│   └── Transactions/
│       ├── DepositTransaction.cs
│       ├── TransferTransaction.cs
│       └── WithdrawTransaction.cs
├── 📁 UI/
|   ├── InputReader.cs
|   └── MenuDisplay.cs
├── ATM-Simulation-System.csproj
└── Program.cs
```

## Extend the system

To add a new transaction:

1. Create a class under `Services/Transactions/` implementing `ITransaction`.
2. Add validation and account logic inside `Execute(...)`.
3. Add a menu option in `ATMEngine.ShowMenu()` and call `ProcessTransaction(...)`.

## Testing status

There is no automated test project yet. A practical next step is adding xUnit tests for:

- `ATMEngine` authentication and menu-driven flows
- Transaction classes (`DepositTransaction`, `WithdrawTransaction`, `TransferTransaction`)
- `BankAccount` debit/credit behavior and edge cases

## ATM Simulation System
```
+-----------------------------------------------------------------------------------+
|                                 APPLICATION ENTRY                                 |
+-----------------------------------------------------------------------------------+
|                                     Program                                       |
|                                 + Main(string[])                                  |
+-----------------------------------------------------------------------------------+
                                         |
                                         v
+-----------------------------------------------------------------------------------+
|                                  CORE SERVICE                                     |
+-----------------------------------------------------------------------------------+
|  <<interface>>                                                                    |
|  IATMEngine <------------------------------------+                                |
|       ^                                          |                                |
|       | Implements                               | Uses                           |
|  ATMEngine                                       |                                |
|  - _accounts: BankAccount[]                      |                                |
|  - _currentAccount: BankAccount?                 |                                |
|  - _menuDisplay: MenuDisplay                     |                                |
|  - _inputReader: InputReader                     v                                |
+-----------------------------------------------------------------------------------+
        |                                 TRANSACTIONS                              |
        |                         +-------------------------------------------------+
        |                         |  <<interface>>                                  |
        |                         |  ITransaction                                   |
        |                         |  + Execute(BankAccount): bool                   |
        |                         +-------------------------------------------------+
        |                                  ^               ^               ^        |
        |                      Implements  |               |               |        |
        |                         +--------+               |               |        |
        |                         |                        |               |        |
        |            DepositTransaction  WithdrawTransaction  TransferTransaction   |
        |            + Amount            + Amount             + Amount              |
        |                                                     + TargetAccount       |
        |                                                                           |
        v                                                                           v
+-----------------------------------+             +---------------------------------+
|            UI HELPERS             |             |          DATA MODELS            |
+-----------------------------------+             +---------------------------------+
|  MenuDisplay      InputReader     |             |  User          BankAccount      |
|  + ShowWelcome()  + ReadString()  |             |  + UserId      + AccountNumber  |
|  + ShowMainMenu() + ReadInt()     |             |  + Name        - _balance       |
|  + ShowMessage()  + ReadDecimal() |             |  + Phone       - _atmPin        |
|  + ShowSuccess()                  |             |                + AccountHolder  |
|  + ShowError()                    |             |                                 |
+-----------------------------------+             +---------------------------------+
                                                           |
                                                           v
                                                  +---------------------------------+
                                                  |        CUSTOM EXCEPTIONS        |
                                                  +---------------------------------+
                                                  |  InsufficientFundsException     |
                                                  +---------------------------------+
```

## System Sequence Diagram (Withdrawal Execution Flow)
```
User          InputReader          ATMEngine         WithdrawTransaction       BankAccount
 |                 |                   |                      |                     |
 |-- Choose (3) -->|                   |                      |                     |
 |-- Enter 500 --->|                   |                      |                     |
 |                 |--- Return 500 --->|                      |                     |
 |                 |                   |-- Create Object ---->|                     |
 |                 |                   |-- ProcessTrans() --->|                     |
 |                 |                   |                      |-- GetBalance() ---->|
 |                 |                   |                      |<-- Balance (10000) -|
 |                 |                   |                      |-- Debit(500) ------>|
 |                 |                   |                      |<-- True ------------|
 |                 |                   |<-- Return True ------|                     |
 |<-- Success Msg -|-------------------|                      |                     |
 ```
