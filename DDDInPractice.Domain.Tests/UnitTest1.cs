using DDDInPractice.Logic;
using FluentAssertions;

namespace DDDInPractice.Domain.Tests;

public class MoneySpecs
{
    [Fact]
    public void Sum_of_tow_moneys_produces_correct_result()
    {

        Money money1 = new Money(1, 2, 3, 4, 5, 6);
        Money money2 = new Money(1, 2, 3, 4, 5, 6);

        Money sum = money1 + money2;

        sum.OneCentCount.Should().Be(2);
        sum.TenCentCount.Should().Be(4);
        sum.QuarterCentCount.Should().Be(6);
        sum.OneDollarCount.Should().Be(8);
        sum.FiveDollarCount.Should().Be(10);
        sum.TwentyDollarCount.Should().Be(12);
    }

    [Fact]
    public void Twom_money_instances_equal_if_contain_the_same_mony_amount()
    {

        Money money1 = new Money(1, 2, 3, 4, 5, 6);
        Money money2 = new Money(1, 2, 3, 4, 5, 6);

        money1.Should().Be(money2);
        money1.GetHashCode().Should().Be(money2.GetHashCode());

    }

    [Fact]
    public void Tow_money_instances_do_not_equal_if_contain_different_money_amounts()
    {
        Money dollar = new Money(0, 0, 0, 1, 0, 0);
        Money hundrdCents = new Money(100, 0, 0, 0, 0, 0);

        dollar.Should().NotBe(hundrdCents);
        dollar.GetHashCode().Should().NotBe(hundrdCents.GetHashCode());
    }
}