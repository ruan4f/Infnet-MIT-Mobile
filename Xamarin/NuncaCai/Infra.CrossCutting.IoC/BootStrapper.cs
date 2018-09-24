using DomainModel.Interfaces.Repositories;
using DomainModel.Interfaces.Services;
using DomainService.Services;
using Infra.Data.SQLServer.Context;
using Infra.Data.SQLServer.Repository;
using NuncaCai.Application.Interfaces;
using NuncaCai.Application.Services;
using SimpleInjector;

namespace Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // App
            container.Register<IPlayerAppService, PlayerAppService>();
            container.Register<IMatchAppService, MatchAppService>();

            // Domain
            container.Register<IPlayerService, PlayerService>();
            container.Register<IMatchService, MatchService>();

            // Infra Dados
            container.Register<IPlayerRepository, PlayerRepository>();
            container.Register<IMatchRepository, MatchRepository>();
            container.Register<EntitySQLContext>();

        }
    }
}
