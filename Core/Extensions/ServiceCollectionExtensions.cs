using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //IServiceCollection ASP net uygulamamızın (API'de)  servis bağımlılıklarını eklediğimiz ve/veya
        //Araya girmesini istediğimiz servisleri eklediğimiz collection'dır
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
        //Core katmanı da dahil olmak üzere ICoreModule üzerinden eklenecek bütün injection'ları bir arada toplayabilen yapı
        //ICoreModule'a göre WebAPI'da instance'ı istenilen CoreModule array olarak parametre verilir
    }
}
