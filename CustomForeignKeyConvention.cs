using System;
using System.Reflection;
using FluentNHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace fluent
{
    public class LowercaseTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table("tbl_" + instance.EntityType.Name);
        }
    }
}