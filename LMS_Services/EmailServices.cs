using LMS_DL;
using LoggerLibrary;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace LMS_Services
{
    public static class EmailServices
    {
        public static bool SendEmailMailKit(string email_otp, string EmailTo, string EmailToName, string EmailBody, SMTP sMTP)
        {
            string EmailSubject = sMTP?.EmailSubject?.ToString();
            string EmailCC = sMTP?.EmailCC?.ToString();
            string EmailCCName = sMTP?.EmailCCName?.ToString();
            EmailBody = EmailBody.ToString();
            if (sMTP.Product == "JC")
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress(sMTP.EmailName, sMTP.Email));
                if (!string.IsNullOrEmpty(EmailTo))
                {
                    email.To.Add(new MailboxAddress(EmailToName, EmailTo));
                }
                if (!string.IsNullOrEmpty(EmailCC))
                {
                    email.Cc.Add(new MailboxAddress(EmailCCName, EmailCC));
                }
                email.Subject = EmailSubject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = EmailBody
                };
                try
                {
                   
                    using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                    {
                        smtp.Connect(sMTP.Host, sMTP.Port, sMTP.EnableSSL);
                        smtp.Authenticate(sMTP.Email, sMTP.Password);
                        smtp.Send(email);
                        smtp.Disconnect(true);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                var email = new MailMessage();
                email.From = new MailAddress(sMTP.Email,sMTP.EmailName);
                if (!string.IsNullOrEmpty(EmailTo))
                {
                    email.To.Add(new MailAddress(EmailTo, EmailToName));
                }
                if (!string.IsNullOrEmpty(EmailCC))
                {
                    email.CC.Add(new MailAddress(EmailCC, EmailCCName));
                }
                email.Subject = EmailSubject;
                email.Body = EmailBody;
                email.IsBodyHtml = true;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(sMTP.Host, sMTP.Port); // Update with your SMTP server and port
                smtp.Credentials = new NetworkCredential(sMTP.Email, sMTP.Password); // Use secure credentials
                smtp.EnableSsl = sMTP.EnableSSL;
                try
                {
                    smtp.Send(email);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }
        public static string SendEMail(string to, string _body, string subject, SMTP? sMTP, ILoggerManager _logger, string attachPath = "")
        {
            string functionReturnValue;
            string msg = "";

            try
            {
                var from = sMTP.Email;
                var emailPassword = sMTP.Password;
                var smtpHost = sMTP.Host;
                int smtpPort = Convert.ToInt32(sMTP.Port);
                var cc = sMTP.EmailCC;
                var bcc = "";
                var EnableSsl = true;

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress(from ?? "");
                //mail.From = new MailAddress("noreply@junooncapital.com", "no-reply");

                if (!string.IsNullOrWhiteSpace(to))
                    mail.To.Add(to);

                if (!string.IsNullOrWhiteSpace(cc))
                {
                    if (cc.Contains(","))
                    {
                        string[] ccArr = cc.Split(',');
                        foreach (string s in ccArr)
                        {
                            mail.CC.Add(s);
                        }
                    }
                    else
                    {
                        mail.CC.Add(cc);
                    }
                }

                if (!string.IsNullOrWhiteSpace(bcc) && bcc.ToLower() != "none")
                {
                    if (bcc.Contains(","))
                    {
                        string[] bccArr = bcc.Split(',');
                        foreach (string s in bccArr)
                        {
                            mail.Bcc.Add(s);
                        }
                    }
                    else
                    {
                        mail.Bcc.Add(bcc);
                    }
                }

                if (!string.IsNullOrEmpty(attachPath))
                    mail.Attachments.Add(new System.Net.Mail.Attachment(attachPath));

                mail.Subject = subject;
                mail.Body = _body;
                mail.IsBodyHtml = true;

                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(smtpHost, smtpPort);
                smtpClient.Credentials = new System.Net.NetworkCredential(from, emailPassword);
                smtpClient.EnableSsl = Convert.ToBoolean(EnableSsl);

                // Optionally handle SSL certificate validation
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                ServicePointManager.ServerCertificateValidationCallback =
                    new RemoteCertificateValidationCallback(ValidateServerCertificate);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

                smtpClient.Send(mail);

                functionReturnValue = "Sent";
                msg = $"Email sent successfully to {to}";
                _logger.LogInfo(msg);
                mail.Dispose();
            }
            catch (FormatException ex)
            {
                functionReturnValue = "FormatException: " + ex.Message + "Email- " + to + "";
                _logger.LogError(functionReturnValue);
            }
            catch (SmtpException ex)
            {
                functionReturnValue = "SmtpException: " + ex.Message + "Email- " + to + "";
                _logger.LogError(functionReturnValue);
            }
            catch (Exception ex)
            {
                functionReturnValue = "Exception: " + ex.Message + "Email- " + to + "";
                _logger.LogError(functionReturnValue);
            }

            return functionReturnValue;
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            else
                return true;
        }
    }
}
