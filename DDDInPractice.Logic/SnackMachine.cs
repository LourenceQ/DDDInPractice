namespace DDDInPractice.Logic;

public class SnackMachine : Entity
{
    public virtual Money MoneyInside { get; protected set; }
    public virtual Money MoneyInTransaction { get; protected set; }
    public void InsertMoney(Money money)
    {
        /*Money[] coinsAndNotes =
        {
            Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
        };
        if (!coinsAndNotes.Contains(money))
            throw new InvalidOperationException();*/

        MoneyInTransaction += money;
    }
    
    public void ReturnMoney()
    {
        //MoneyInTransaction = 0;
    }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransaction;
        
        //MoneyInTransaction = 0;
    }
}
