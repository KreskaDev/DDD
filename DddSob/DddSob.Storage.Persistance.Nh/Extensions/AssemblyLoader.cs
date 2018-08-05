using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DddSob.Storage.Persistance.Nh.Extensions
{
    public interface IAssemblyLoader
    {
        //void LoadAssemblies();
        Assembly[] GetAppDomainAssembly(Func<Assembly, int, bool> selector);
    }

    public class AssemblyLoader : IAssemblyLoader
    {
        //private readonly ILocalStorageSettings _localStorageSettings;

        //public AssemblyLoader(ILocalStorageSettings localStorageSettings)
        //{
        //    _localStorageSettings = localStorageSettings;
        //}

        //public void LoadAssemblies() // Should return result<>
        //{
        //    //Load all assembiles into domain for full generic autofac type registration
        //    foreach (var filePath in Directory.GetFiles(_localStorageSettings.LocalStoragePath, "*.dll"))
        //    {
        //        AppDomain.CurrentDomain.Load(Path.GetFileNameWithoutExtension(filePath));
        //    }
        //}

        public Assembly[] GetAppDomainAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName.StartsWith(name))
                .ToArray();
        }

        public Assembly[] GetAppDomainAssembly(Func<Assembly, int, bool> selector)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(selector)
                .ToArray();
        }
    }
}