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
            message = new LocalizedString("\\CLO:\\" + message.ToString());
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
            message = new LocalizedString("\\FAD:\\" + message.ToString());
            notifier.Add(NotifyType.Information, message);
        }

        /// <summary>
        /// Adds a new UI notification of type Sticky
        /// </summary>
        /// <seealso cref="Orchard.UI.Notify.INotifier.Add()"/>
        /// <param name="notifier"></param>
        /// <param name="message">A localized message to display</param>
        public static void Sticky(this INotifier notifier, LocalizedString message)
        {
            message = new LocalizedString("\\STI:\\" + message.ToString());
            notifier.Add(NotifyType.Information, message);
        }
    }
}