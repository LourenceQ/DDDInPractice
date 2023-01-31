using DDDInPractice.Logic;

namespace DDDInPractice.Domain.Tests;

public class SnackMachineSpecs
{
    [Fact]
    public void Return_money_empties_money_in_tansaction()
    {
        var snackMachine = new SnackMachine();
        snackMachine.InsertMoney(new Money(0, 0, 0, 1, 0, 0));


    }
}
