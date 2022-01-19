using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.Concrete;
using eCademiaApp.DataAccess.Concrete.EntityFramework;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Core.Utilities.Interceptors;
using eCademiaApp.Core.Utilities.Security.JWT;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;
using Castle.DynamicProxy;
using Autofac.Extras.DynamicProxy;
using eCademiaApp.Core.Utilities.Pagination;

namespace eCademiaApp.Business.DependencyResolvers.Autofac
{
    // Autofac implementation to resolve dependencies
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Setting a concrete class for each interface/abs class
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            
            builder.RegisterType<PaginationParameter>().As<PaginationParameters>().SingleInstance();

            builder.RegisterType<CourseManager>().As<ICourseService>().SingleInstance();
            builder.RegisterType<EfCourseDal>().As<ICourseDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<InstructorManager>().As<IInstructorService>().SingleInstance();
            builder.RegisterType<EfInstructorDal>().As<IInstructorDal>().SingleInstance();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() })
                .SingleInstance();
        }
    }
}
