using System;
using System.Collections.Generic;

namespace Joistick
{
    /// <summary>
    /// Implementa IServiceProvider per l'applicazione. Questo tipo viene esposto tramite la proprietà App.Services
    /// e può essere utilizzato per ContentManagers o altri tipi che richiedono l'accesso a IServiceProvider.
    /// </summary>
    public class AppServiceProvider : IServiceProvider
    {
        // Mappa del tipo di servizio per i servizi stessi
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        /// <summary>
        /// Aggiunge un nuovo servizio al provider di servizi.
        /// </summary>
        /// <param name="serviceType">Tipo di servizio da aggiungere.</param>
        /// <param name="service">Oggetto servizio stesso.</param>
        public void AddService(Type serviceType, object service)
        {
            // Convalidare l'input
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");
            if (service == null)
                throw new ArgumentNullException("service");
            if (!serviceType.IsAssignableFrom(service.GetType()))
                throw new ArgumentException("service does not match the specified serviceType");

            // Aggiungere il servizio al dizionario
            services.Add(serviceType, service);
        }

        /// <summary>
        /// Ottiene un servizio dal provider di servizi.
        /// </summary>
        /// <param name="serviceType">Tipo di servizio da recuperare.</param>
        /// <returns>Oggetto servizio registrato per il tipo specificato.</returns>
        public object GetService(Type serviceType)
        {
            // Convalidare l'input
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            // Recuperare il servizio dal dizionario
            return services[serviceType];
        }

        /// <summary>
        /// Rimuove un servizio dal provider di servizi.
        /// </summary>
        /// <param name="serviceType">Tipo di servizio da rimuovere.</param>
        public void RemoveService(Type serviceType)
        {
            // Convalidare l'input
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            // Rimuovere il servizio dal dizionario
            services.Remove(serviceType);
        }
    }
}
