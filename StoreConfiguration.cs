using System;
using FluentNHibernate.Automapping;

namespace fluent
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "fluent.Entities";
        }
    }
}