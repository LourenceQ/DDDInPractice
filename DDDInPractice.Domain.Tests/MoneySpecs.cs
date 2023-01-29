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

    [Theory]
    [InlineData(-1, 0, 0, 0, 0, 0)]
    [InlineData(0, -2, 0, 0, 0, 0)]
    [InlineData(0, 0, -3, 0, 0, 0)]
    [InlineData(0, 0, 0, -4, 0, 0)]
    [InlineData(0, 0, 0, 0, -5, 0)]
    [InlineData(0, 0, 0, 0, 0, -6)]
    public void Cannot_create_money_with_negative_value(
        int oneCentCount,
        int tenCentCount,
        int quarterCentCount,
        int onDollarCount,
        int fiveDollarCount,
        int twentyDollarCount)
    {

        Action action = () => new Money(oneCentCount, tenCentCount, quarterCentCount, onDollarCount, fiveDollarCount, twentyDollarCount);

        action.Should().Throw<InvalidOperationException>();
    }

    [Theory]
    [InlineData(0, 0, 0, 0, 0, 0, 0)]
    [InlineData(1, 0, 0, 0, 0, 0, 0.01)]
    [InlineData(1, 2, 0, 0, 0, 0, 0.21)]
    [InlineData(1, 2, 3, 0, 0, 0, 0.96)]
    [InlineData(1, 2, 3, 4, 0, 0, 4.96)]
    [InlineData(1, 2, 3, 4, 5, 0, 29.96)]
    [InlineData(1, 2, 3, 4, 5, 6, 149.96)]
    [InlineData(11, 0, 0, 0, 0, 0, 0.11)]
    [InlineData(110, 0, 0, 0, 100, 0, 501.1)]
    public void Amount_is_calculated_corectly(
        int oneCentCount,
        int tenCentCount,
        int quarterCentCount,
        int onDollarCount,
        int fiveDollarCount,
        int twentyDollarCount,
        double expectedAmount)
    {
        Money money = new Money(oneCentCount, tenCentCount, quarterCentCount, onDollarCount, fiveDollarCount, twentyDollarCount);

        money.Amount.Should().Equals(expectedAmount);
    }

    [Fact]
    public void Subtraction_of_two_money_produce_corect_result()
    {
        Money money1 = new Money(10, 10, 10, 10, 10, 10);
        Money money2 = new Money(1, 2, 3, 4, 5, 6);

        Money res = money1 - money2;

        res.OneCentCount.Should().Be(9);
        res.TenCentCount.Should().Be(8);
        res.QuarterCentCount.Should().Be(7);
        res.OneDollarCount.Should().Be(6);
        res.FiveDollarCount.Should().Be(5);
        res.TwentyDollarCount.Should().Be(4);
    }

    [Fact]
    public void Cannot_subtracts_more_than_exists()
    {
        Money money1 = new Money(0, 1, 0, 0, 0, 0);
        Money money2 = new Money(1, 0, 0, 0, 0, 0);

        Action action = () =>
        {
            Money mony = money1 - money2;
        };

        action.Should().Throw<InvalidOperationException>();
    }

}