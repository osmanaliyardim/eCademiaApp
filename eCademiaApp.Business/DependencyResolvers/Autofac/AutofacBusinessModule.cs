using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.Concrete;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.DataAccess.Concrete.EntityFramework;
using Autofac;
using Module = Autofac.Module;

namespace eCademiaApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseManager>().As<ICourseService>().SingleInstance();
            builder.RegisterType<EfCourseDal>().As<ICourseDal>().SingleInstance();
        }
    }
}
