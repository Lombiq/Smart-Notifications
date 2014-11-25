using Orchard.Localization;

namespace Orchard.UI.Notify
{
    public static class NotifierExtensions
    {
        /// <summary>
        /// Adds a new UI notification of type Closable
        /// </summary>
        /// <seealso cref="Orchard.UI.Notify.INotifier.Add()"/>
        /// <param name="notifier"></param>
        /// <param name="message">A localized message to display</param>
        public static void Closable(this INotifier notifier, LocalizedString message)
        {
            notifier.Add(NotifyType.Information, message);
        }

        /// <summary>
        /// Adds a new UI notification of type Fading
        /// </summary>
        /// <seealso cref="Orchard.UI.Notify.INotifier.Add()"/>
        /// <param name="notifier"></param>
        /// <param name="message">A localized message to display</param>
        public static void Fading(this INotifier notifier, LocalizedString message)
        {
            notifier.Add(NotifyType.Information, message);
        }
    }
}