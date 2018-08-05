using System;
using System.Collections.Generic;
using System.Linq;
using DddSob.Storage.Persistance.Nh.Settings.Abstraction;
using NHibernate.Cfg;

namespace DddSob.Storage.Persistance.Nh.Settings
{
    //public class Configurator : IConfigurator
    //{
    //    private const string ConfigurationFile = "nhibernate.cfg.xml";

    //    public Configuration CreateConfiguration<TDbInfo>() 
    //        where TDbInfo: DbInfo, new() =>
    //        CreateConfiguration(new TDbInfo());

    //    public Configuration CreateConfiguration(DbInfo dbInfo)
    //    {
    //        var manifestResourceNames = dbInfo.MappingsAssembly
    //            .GetManifestResourceNames();
    //        var cfg = ConfigureConnectionString(dbInfo, manifestResourceNames);
    //        ConfigureMappingFiles(manifestResourceNames, cfg, dbInfo);
    //        return cfg;
    //    }

    //    private Configuration ConfigureConnectionString(DbInfo dbInfo, IEnumerable<string> manifestResourceNames)
    //    {
    //        var configurationFileName = manifestResourceNames
    //                        .FirstOrDefault(s => s.Contains(ConfigurationFile));
    //        if (configurationFileName == null)
    //        {
    //            throw new Exception($"{ConfigurationFile} not found.");
    //        }
    //        var cfg = new Configuration().Configure(dbInfo.MappingsAssembly, configurationFileName);

    //        cfg.SetProperty("connection.connection_string", dbInfo.ConnectionString);
    //        return cfg;
    //    }

    //    private void ConfigureMappingFiles(IEnumerable<string> manifestResourceNames, Configuration cfg, DbInfo dbInfo)
    //    {
    //        var mappingFiles = manifestResourceNames
    //                        .Where(a => a.Contains(dbInfo.MappingNamespace) && a.EndsWith(".hbm.xml"))
    //                        .ToList();

    //        if (mappingFiles.Count > 0)
    //            cfg.AddResources(mappingFiles, dbInfo.MappingsAssembly);
    //    }
    //}
}