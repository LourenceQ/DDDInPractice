using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using System.Reflection;

namespace DDDInPractice.Logic;

internal static class SessionFactory
{
    public static ISessionFactory _factory;

    internal static ISession OpenSession()
    {
        return _factory.OpenSession();
    }

    public static void Init(string connectionString)
    {
        _factory = BuilderSessionFactory(connectionString);
    }

    public static ISessionFactory BuilderSessionFactory(string connectionString)
    {
        FluentConfiguration configuration = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
            .Mappings(mbox => mbox.FluentMappings
                .AddFromAssembly(Assembly.GetExecutingAssembly())
                .Conventions.Add(ForeignKey.EndsWith("ID"),
                ConventionBuilder.Property
                    .When(criteria => criteria.Expect(x => x.Nullable, Is.Not.Set), x => x.Not.Nullable()))
                .Conventions.Add<TableNameConvention>()
                .Conventions.Add<HiLoConvention>());

        return configuration.BuildSessionFactory();
    }
}
