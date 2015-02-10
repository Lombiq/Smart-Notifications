using Lombiq.SmartNotifications;
using Orchard.Localization;

namespace Orchard.UI.Notify
{
    public static class NotifierExtensions
    {
        /// <summary>
        /// Adds a new UI notification of type Closable
        /// </summary>
        /// <seealso cref="INotifier.Add()"/>
        /// <param name="message">A localized message to display</param>
        /// <param name="type">The type of the notificaion.</param>
        public static void Closable(this INotifier notifier, LocalizedString message, NotifyType type)
        {
            message = new LocalizedString(Constants.Closable + message.ToString());
            notifier.Add(type, message);
        }

        /// <summary>
        /// Adds a new UI notification of type Fading
        /// </summary>
        /// <seealso cref="INotifier.Add()"/>
        /// <param name="message">A localized message to display</param>
        /// <param name="type">The type of the notificaion.</param>
        public static void Fading(this INotifier notifier, LocalizedString message, NotifyType type)
        {
            message = new LocalizedString(Constants.Fading + message.ToString());
            notifier.Add(type, message);
        }

        /// <summary>
        /// Adds a new UI notification of type Sticky
        /// </summary>
        /// <seealso cref="INotifier.Add()"/>
        /// <param name="message">A localized message to display</param>
        /// <param name="type">The type of the notificaion.</param>
        public static void Sticky(this INotifier notifier, LocalizedString message, NotifyType type)
        {
            message = new LocalizedString(Constants.Sticky + message.ToString());
            notifier.Add(type, message);
        }
    }
}