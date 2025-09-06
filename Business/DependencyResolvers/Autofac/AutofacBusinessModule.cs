using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EFDALs;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
   


        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EfUserDal>().As<IUserDal>();

        builder.RegisterType<FagManager>().As<IFagService>();
        builder.RegisterType<EFFagDal>().As<IFagDal>();

        builder.RegisterType<EventManager>().As<IEventService>();
        builder.RegisterType<EFEventDal>().As<IEventDal>();


        builder.RegisterType<EventContentManager>().As<IEventContentService>();
        builder.RegisterType<EFEventContentDal>().As<IEventContentDal>();

        builder.RegisterType<BlogManager>().As<IBlogService>();
        builder.RegisterType<EFBlogdal>().As<IBlogDal>();


        builder.RegisterType<ContactBlockManager>().As<IContactBlockService>();
        builder.RegisterType<EFContactBlockDal>().As<IContactBlockDal>();

        builder.RegisterType<ContactMessageManager>().As<IContactMessageService>();
        builder.RegisterType<EFContactMessageDal>().As<IContactMessageDal>();

        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<FileManager>().As<IFileService>();
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();


        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}
