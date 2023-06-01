using Autofac;
using Logics.UserLogic;
using Repositories.Repositories.UserRepository;

namespace MotelDotNetCore;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserLogic>().As<IUserLogic>().SingleInstance();
        builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
    }
}