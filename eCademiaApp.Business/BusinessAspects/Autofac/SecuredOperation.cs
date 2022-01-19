using Castle.DynamicProxy;
using eCademiaApp.Business.Constants;
using eCademiaApp.Core.Extensions;
using eCademiaApp.Core.Utilities.Interceptors;
using eCademiaApp.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace eCademiaApp.Business.BusinessAspects.Autofac
{
    // User authentication operations (roles check)
    public class SecuredOperation : MethodInterception
    {
        // Injectable services
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string[] _roles;

        // Injecting our services to establish a loosely coupled connection
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        /// <summary>This method checks user has a permisson before methods are executed.</summary>
        /// <param name="invocation">running method</param>
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
                if (roleClaims.Contains(role))
                    return;
            _httpContextAccessor.HttpContext.Response.StatusCode = 401;
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
