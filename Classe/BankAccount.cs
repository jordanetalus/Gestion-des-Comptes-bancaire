namespace Classe;

public class BankAccount
{
  private static int s_accountNumberSeed=0123456789;
    public string Number {get;}
    public string Owner{ get;set;}
    public decimal Balance {
      get{
        decimal balance = 0;
        foreach (var item in _allTransactions)
        {
          balance+=item.Amount;
        }
        return balance;
      }
    }

    public BankAccount(string name,decimal initialBalance)
    {
      Number = s_accountNumberSeed.ToString();
      s_accountNumberSeed++;
      Owner=name;
      MakeDeposit(initialBalance, DateTime.Now, "Initial balance");

    }

    private List<Transaction> _allTransactions = new List<Transaction>();
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
      if(amount<=0)
      {
        Console.WriteLine("la valeur à déposer doit être positif ");
        return;
      }
      var deposit=new Transaction(amount,date,note);
      _allTransactions.Add(deposit);
      
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
      if(amount<=0)
      {
        Console.WriteLine("le montant du retrait doit être positif ");
        return;
      }
      if(Balance-amount<0)
      {
        Console.WriteLine("vous n'avez pas assez de fond pour effectuer ce retrait");
      }
      var withdrawal=new Transaction(-amount,date,note);
      _allTransactions.Add(withdrawal);
    }

    public string GetAccountHistory()
{
    var report = new System.Text.StringBuilder();

    decimal balance = 0;
    report.AppendLine("Date\t\tAmount\tBalance\tNote");
    foreach (var item in _allTransactions)
    {
        balance += item.Amount;
        report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
    }

    return report.ToString();
}

}