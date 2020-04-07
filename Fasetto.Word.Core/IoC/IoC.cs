using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public static class IoC
    {
        // The kernal is where you get and bind all of the information in the whole of inject
        /// <summary>
        /// The kernal for IoC container
        /// 
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// Setup the IoC container, binds all of the information required and is ready for use
        /// NOTE: Must be called as soon as your application starts up to ensure all services can be found
        /// </summary>
        public static void SetUp()
        {
            // Bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // bind to a single instance of application view model
            // so now we can acces the 'ApplicationViewModel' anywherer in the application through 'Kernal.Get()'
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        /// <summary>
        /// Gets a service from the IoC of a specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
