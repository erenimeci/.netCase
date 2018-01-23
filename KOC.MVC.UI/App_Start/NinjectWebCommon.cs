[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(KOC.MVC.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(KOC.MVC.UI.App_Start.NinjectWebCommon), "Stop")]

namespace KOC.MVC.UI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using KOC.DataAccess.Abstract.Login;
    using KOC.Business.Abstract.Login;
    using KOC.Business.Concrete.Login;
    using KOC.DataAccess.Concrete.Login;
    using KOC.DataAccess.Abstract.Other;
    using KOC.DataAccess.Abstract.Test;
    using KOC.DataAccess.Concrete.Test;
    using KOC.DataAccess.Concrete.Other;
    using KOC.Business.Abstract.Other;
    using KOC.Business.Abstract.Test;
    using KOC.Business.Concrete.Test;
    using KOC.Business.Concrete.Other;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserDAL>().To<EFUserDAL>();
            kernel.Bind<IArticleDAL>().To<EFArticleDAL>();
            kernel.Bind<IExamDAL>().To<EFExamDAL>();
            kernel.Bind<IQuestionDAL>().To<EFQuestionDAL>();

            kernel.Bind<IUserService>().To<UserManagement>();
            kernel.Bind<IArticleService>().To<ArticleManagement>();
            kernel.Bind<IExamService>().To<ExamManagement>();
            kernel.Bind<IQuestionService>().To<QuestionManagement>();

        }        
    }
}
