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