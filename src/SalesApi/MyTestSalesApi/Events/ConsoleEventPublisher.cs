using Newtonsoft.Json;

namespace SalesApi.Events
{
    /// <summary>
    /// Implementação simples de IEventPublisher que loga o evento no console.
    /// </summary>
    public class ConsoleEventPublisher : IEventPublisher
    {
        /// <summary>
        /// Publica o evento escrevendo no console.
        /// </summary>
        public void Publish(string eventName, object payload)
        {
            Console.WriteLine($"Evento: {eventName} - Dados: {JsonConvert.SerializeObject(payload)}");
        }
    }
}
