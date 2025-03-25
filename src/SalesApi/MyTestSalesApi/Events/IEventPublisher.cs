namespace SalesApi.Events
{
    /// <summary>
    /// Interface para publicação de eventos.
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Publica um evento.
        /// </summary>
        /// <param name="eventName">Nome do evento.</param>
        /// <param name="payload">Dados do evento.</param>
        void Publish(string eventName, object payload);
    }
}
