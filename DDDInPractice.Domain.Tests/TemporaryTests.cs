using NHibernate;
using Xunit;
using DDDInPractice.Logic;

namespace DDDInPractice.Domain.Tests;

public class TemporaryTests
{
    [Fact]
	public void Test()
	{
		SessionFactory.Init(@"Server=.;DddIniPractice;Truested_connection=true");

		using(ISession session = SessionFactory.OpenSession())
		{
			long id = 1;
			var snackMachine = session.Get<SnackMachine>(id);;
		}
	}
}
