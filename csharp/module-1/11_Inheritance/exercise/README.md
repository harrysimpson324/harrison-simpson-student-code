# Inheritance exercise

The purpose of this exercise is to practice writing code that uses the Object-Oriented Programming principle of inheritance.

## Learning objectives

After completing this exercise, you'll be able to:

* Describe the purpose and use of inheritance in an Object-Oriented Programming environment
* Define and use superclasses and subclasses in an inheritance hierarchy
* Identify superclasses and subclasses when viewing source code
* Define an IS-A relationship in reference to inheritance
* Define what overriding means in the context of inheritance
* Describe what's being inherited
* Describe how access modifiers work in an inheritance relationship
* Use superclass constructors in a subclass

## Evaluation criteria and functional requirements

* The project must not have any build errors.
* Code is presented in a clean, organized format.
* Code is appropriately encapsulated.
* Inheritance is used appropriately to avoid code duplication.
* The code meets the specifications defined in the remainder of this document.

### Bank teller application

**Notes for all classes**

- X in the set column indicates it *must have a `set` accessor*.
- Readonly attributes don't require a `set` accessor. They're set from the class's constructor.
- Private setters require the property to have `private set`.

#### Instructions

Create three new classes to represent a bank account, savings account, and a checking account. The curriculum team created the class files for you. You need to define the proper inheritance.

#### Step One: Implement the `BankAccount` class

The `BankAccount` class represents a basic checking or savings account at a bank.

| Constructor                                                  | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| BankAccount(string accountHolderName, string accountNumber)  | A new bank account requires an account holder name and account number. The balance defaults to a 0 dollar balance if not specified. |
| BankAccount(string accountHolderName, string accountNumber, decimal balance) | A new bank account requires an account holder name and account number. The balance is initialized to the dollar balance given. |



| Property Name     | Data Type | Get | Set     | Description                                                  |
| ----------------- | --------- | --- | ------- | ------------------------------------------------------------ |
| AccountHolderName | string    | X   | private | Returns the account holder name that the account belongs to. |
| AccountNumber     | string    | X   |         | Returns the account number that the account belongs to.      |
| Balance           | decimal   | X   | private | Returns the balance value of the bank account in USD.        |



| Method Name                        | Return Type | Description                                                                                             |
| ---------------------------------- | ----------- | ------------------------------------------------------------------------------------------------------- |
| Deposit(decimal amountToDeposit)   | decimal     | Adds `amountToDeposit` to the current balance, and returns the new balance of the bank account. `amountToDeposit` must be greater than zero.          |
| Withdraw(decimal amountToWithdraw) | decimal     | Subtracts `amountToWithdraw` from the current balance, and returns the new balance of the bank account. `amountToWithdraw` must be greater than zero. |

#### Step Two: Implement the `CheckingAccount` class

A `CheckingAccount` "is-a" `BankAccount`, but it also has some additional rules:

| Override Method | Description                                                                                                                                                             |
| --------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Withdraw        | If the balance falls below $0.00 but is still greater than -$100.00, a $10.00 overdraft fee is also charged against the account.         |
|        | A request to overdraw a checking account by $100.00 or more (before overdraft fee) fails and the balance remains the same.<br><br> For example, if the current balance is -$89.00, and the amount to withdraw is $10.00, the resulting balance is -$99.00. The withdrawal is permitted since the new balance is greater than -$100.00. The $10.00 overdraft fee is then charged against the account, resulting in a final balance of -$109.00.<br><br>A withdrawal of $11.00 in the same situation fails because the new balance would be -$100.00 which is equal to, *not greater than*, the lower limit of -$100.00. |

#### Step Three: Implement the `SavingsAccount` class

A `SavingsAccount` "is-a" `BankAccount`, but it also has some additional rules:

| Override Method | Description                                                                                                                              |
| --------------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| Withdraw        | If the remaining balance is less than $150.00 when a withdrawal is made, an additional $2.00 service charge is withdrawn from the account. |
|         | If a withdrawal is requested for more than the current balance, the withdrawal fails and balance remains the same. No fees are incurred. |


_Sample usage_
``` csharp
BankAccount checkingAccount = new CheckingAccount("Bernice", "CHK:1234");
BankAccount savingsAccount = new SavingsAccount("Bernice", "SAV:9876");

decimal amountToDeposit = 100.00M;
decimal newBalance = checkingAccount.Deposit(amountToDeposit);
```


