using System;
using System.Collections.Generic;
using Autofac;

namespace DddSob.Persistance.LocalDb.Helpers
{
    public class ModuleSubstitute<TModule> : Module where TModule : Module, new()
    {
        private readonly IDictionary<Type, object> _overrides;

        public ModuleSubstitute()
        {
            _overrides = new Dictionary<Type, object>();
        }

        public ModuleSubstitute<TModule> OverrideDependency<TDType>(TDType dependency)
        {
            _overrides.Add(typeof(TDType), dependency);
            return this;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<TModule>();

            foreach (var overrideObject in _overrides)
            {
                builder.Register(context => overrideObject.Value).As(overrideObject.Key);
            }

            base.Load(builder);
        }
    }
}