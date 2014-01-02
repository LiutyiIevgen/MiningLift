using ComCan;
using ML.AdvCan;
using ML.ConfigSettings.Services;
using ML.DataExchange;
using Ninject;
using Ninject.Parameters;
using ML.DataExchange.Interfaces;
using VisualizationSystem.Services;
using VisualizationSystem.View;
using VisualizationSystem.View.Forms;

namespace VisualizationSystem.Model
{
    public static class IoC
    {
        private static readonly IKernel _kernel = new StandardKernel();

        static IoC()
        {
            SetBindings();
        }

        public static void RegisterType<TInterface, TClass>() where TClass : TInterface
        {
            _kernel.Bind<TInterface>().To<TClass>();
        }

        public static void RegisterSingleton<TInterface, TClass>() where TClass : TInterface
        {
            _kernel.Bind<TInterface>().To<TClass>().InSingletonScope();
        }

        public static void RegisterInstance<TInterface, TClass>() where TClass : TInterface
        {
            _kernel.Bind<TInterface>().To<TClass>();
        }

        public static T Resolve<T>(params IParameter[] parameters)
        {
            return _kernel.Get<T>(parameters);
        }

        public static void SetBindings()
        {
            RegisterSingleton<IDataExchange, TransferOverFile>();
            RegisterSingleton<DataListener, DataListener>();
            RegisterSingleton<MineConfig, MineConfig>();
            RegisterSingleton<FormSettings, FormSettings>();
            RegisterSingleton<FormSettingsParol, FormSettingsParol>();
        }
    }
}
