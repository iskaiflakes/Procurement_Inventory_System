using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    public class EmailSender
    {
        // Properties for SMTP settings
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public SecureSocketOptions SslOptions { get; set; }

        // Constructor to initialize the SMTP settings
        public EmailSender(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword, SecureSocketOptions sslOptions)
        {
            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
            SmtpUsername = smtpUsername;
            SmtpPassword = smtpPassword;
            SslOptions = sslOptions;
        }

        public async Task<string> SendEmail(string fromAddress, string fromName, string toName, string toAddress, string subject, string htmlTable)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromName, fromAddress));
                message.To.Add(new MailboxAddress(toName, toAddress));
                message.Subject = subject;

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"<html><body>{htmlTable}</body></html>"
                };
                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(SmtpHost, SmtpPort, SslOptions);
                    await client.AuthenticateAsync(SmtpUsername, SmtpPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                return "Email sent successfully.";
            }
            catch (Exception ex)
            {
                return "Error sending email: " + ex.Message;
            }
        }
    }

    public class EmailBuilder
    {
        public static string TableHeaders(List<string> headers, string field = "")
        {
            if (headers.Count != 0)
            {
                field += $"<th>{headers[0]}</th>";
                return TableHeaders(headers.GetRange(1, headers.Count - 1), field);
            }
            return field;
        }

        public static string TableRow(List<string> row, string field = "")
        {
            if (row.Count != 0)
            {
                field += $"<td>{row[0]}</td>";
                return TableRow(row.GetRange(1, row.Count - 1), field);
            }
            return field;
        }

        private static string TableBuilder(string header, string[] body)
        {
            string table = "<table border='1'>";
            table += $"<tr>{header}</tr>";
            foreach (string row in body)
            {
                table += $"<tr>{row}</tr>"; ;
            }
            return $"{table}</table>";
        }

        public static string ContentBuilder(string requestID, string Receiver, string Sender, string UserAction, string TypeOfRequest, string TableTitle = null, string Header = null, string[] Body = null)
        {
            string extension = " and is awaiting for ";

            switch (UserAction)
            {
                case "SUBMITTED":
                    extension += "APPROVAL";
                    break;
                case "APPROVED":
                    extension += "RELEASE";
                    break;
                case "REJECTED":
                    extension += "REVIEW";
                    break;
                case "RELEASED":
                    extension = ". Kindly check if there are missing or defected items.";
                    break;
                case "ADDED QUOTATION":
                    extension += "APPROVAL";
                    break;
                case "CREATED":
                    extension += "QUOTATION";
                    break;
                case "APPROVED FOR PURCHASE":
                    extension += "PROCUREMENT";
                    break;
                case "UPDATED":
                    extension += "your review.";
                    break;
                default:
                    extension = "";
                    break;
            }

            string emailContent = @"
                    <p>Dear {receiver},</p><br>

                    <p>We hope this email finds you well.</p>
                    <p>This is to inform you that a <strong>{Type} [{RequestID}]</strong> has been <strong>{action}</strong>{extension}.</p>

                    <h3>{TableTitle}</h3>
                    {Table}
                    <br>
                    <br><b>Date of Request: {DateTime}</b>

                    <p>Best regards,</p>
                    <p>{sender}</p>
                    <br>
                    <hr>
                    <p><mark><i>This is a system generated email. Please do not reply to this message.</i></mark></p>";
            try
            {
                emailContent = emailContent.Replace("{receiver}", Receiver)
                                            .Replace("{sender}", Sender)
                                            .Replace("{action}", UserAction)
                                            .Replace("{Type}", TypeOfRequest)
                                            .Replace("{extension}", extension)
                                            .Replace("{RequestID}", requestID)
                                            .Replace("{DateTime}", DateTime.Now.ToString("F"))
                                            .Replace("{Table}", TableBuilder(Header, Body))
                                            .Replace("{TableTitle}", TableTitle);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                emailContent = emailContent.Replace("{Table}", "")
                                           .Replace("{DateTime}", "")
                                           .Replace("{TableTitle}", "");
            }
            return emailContent;

        }
    }
}
