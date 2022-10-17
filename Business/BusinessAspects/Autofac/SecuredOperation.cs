using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //Yetkilendirme kontrolü yapacak class AOP ile
    //JWT için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        //JWT ile yapılan herbir kişiden gelen herbir istek için HttpContext/thread oluşur

        public SecuredOperation(string roles) //roller [SecuredOperation("Product.Add, admin)]
        {
            //metni belirtilen karaktere göre ayırıp array'e atar. Yukarıdaki Product.Add, admin mesela
            _roles = roles.Split(',');
            //ServiceTool kullanılarak ASP.net ve API göremez dependency'leri yakalayabilmek için yazıldı
            //Injection altyapısını okumaya yarar
            //Autofac'de injection değerlerini alır IProductService vb.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        //uygulama öncesi rolleri gez eğer rolleri varsa return;
        //Eğer rolleri yoksa return exception
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
