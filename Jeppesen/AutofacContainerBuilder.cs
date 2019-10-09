using Autofac;
using Jeppesen.Interfaces;
using Jeppesen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeppesen
{
    public class IoCBuilder
    {
        public ContainerBuilder Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RecordsService>().As<IRecordsService>().SingleInstance(); ;
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

            return builder;
        }
    }
}
