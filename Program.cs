using Classe;
var account=new BankAccount("jordane",10000);
System.Console.WriteLine($"account{account.Number} was create for {account.Owner} with {account.Balance} innitial balance");

account.MakeDeposit(10000,DateTime.Now,"epargne en ligne ");
account.MakeDeposit(2000,DateTime.Now,"epargne en ligne ");
account.MakeWithdrawal(20000,DateTime.Now,"achat en ligne");
Console.WriteLine(account.Balance);
Console.WriteLine(account.GetAccountHistory());