using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using fluent.Entities;

namespace fluent
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
		
        private static ISessionFactory SessionFactory { 
            get { 
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory; 
            } 
        }
   
        private static void InitializeSessionFactory() {
            var cfg = new StoreConfiguration();
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008 .ConnectionString(
                    @"Data Source=m-mohammadian;Initial Catalog=Test_DB;User ID=sa;Password=s@123456").ShowSql())
                .Mappings(m => m.AutoMappings
                    .Add(AutoMap.AssemblyOf<Customer>(cfg).Conventions.Add<LowercaseTableNameConvention>()))
                .ExposeConfiguration(conf => new SchemaExport(conf)
                    .Create(true, true)) 
                .BuildSessionFactory(); 
        }
		
        public static ISession OpenSession() { 
            return SessionFactory.OpenSession(); 
        }
    }
}
