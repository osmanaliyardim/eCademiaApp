using Castle.DynamicProxy;
using eCademiaApp.Business.Constants;
using eCademiaApp.Core.Extensions;
using eCademiaApp.Core.Utilities.Interceptors;
using eCademiaApp.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace eCademiaApp.Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string[] _roles;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
                if (roleClaims.Contains(role))
                    return;
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
