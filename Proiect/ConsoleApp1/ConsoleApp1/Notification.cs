using System;

namespace Proiect
{
    public class NewNotificationEventArgs : EventArgs
    {
        public NewNotificationEventArgs(string from, string title, string subject, string body)
        {
            this.from = from;
            this.subject = subject;
            this.body = body;
            this.title = title;
            dateTime = DateTime.Now;
        }
        public readonly string from, subject, body, title;
        public readonly DateTime dateTime;
    }
    public class NotificationManager
    {
        public EventHandler<NewNotificationEventArgs> NewNotification;
        protected virtual void OnNewNotification(NewNotificationEventArgs e)
        {
            NewNotification?.Invoke(this, e);
        }
        public void CreateMessage(string from, string title, string subject, string body)
        {
            NewNotificationEventArgs e = new NewNotificationEventArgs(from, title, subject, body);
            OnNewNotification(e);
        }
    }
    public class SMS
    {
        public void OnNewNotification(object sender, NewNotificationEventArgs e)
        {
            Console.WriteLine("SMS message:");
            Console.WriteLine($"   From: {e.from}\n   Title: {e.title}\n   Subject: {e.subject}\n   Body: {e.body} Date: {e.dateTime}\n");
        }
    }
    public class Email
    {
        public void OnNewNotification(object sender, NewNotificationEventArgs e)
        {
            Console.WriteLine("Email message:");
            Console.WriteLine($"   From: {e.from}\n   Title: {e.title}\n   Subject: {e.subject}\n   Body: {e.body} Date: {e.dateTime}\n");
        }
    }
    public class Push
    {
        public void OnNewNotification(object sender, NewNotificationEventArgs e)
        {
            Console.WriteLine("Push notification:");
            Console.WriteLine($"   From: {e.from}\n   Title: {e.title}\n   Subject: {e.subject}\n   Body: {e.body} Date: {e.dateTime}\n");
        }
    }
    public class Notification
    {
        string Title;
        DateTime DateTime;
        string Text;
        string Author;
    }
}