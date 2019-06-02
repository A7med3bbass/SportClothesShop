using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Net;
using System.Text;
using System.Diagnostics;

namespace FifaShop.DataContext
{
    public class EmailSetting
    {
        public string MailTo = "ahmedrm.ar39@gmail.com";   // Admin mail
        public string MailFrom = "ahmed.ramadan.abbass@gmail.com"; //Sender mail
        public bool SSL = true;
        public string username = "ahmed.ramadan.abbass@gmail.com";
        public string PassKey = "amrdBass67Kkkks76yuerhhfsfhj438";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"C:\OrderToProducts";
    }

    public class OrderProccessorEmail : IOrderToProduct  
    {
        private EmailSetting _em;
        public OrderProccessorEmail(EmailSetting Em) 
        {
            _em = Em;
        }
        public void OrderProduct(MainClasses.Cart car, MainClasses.ShipDetails Ship)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _em.SSL;
                smtpClient.Host = _em.ServerName;
                smtpClient.Port = _em.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_em.username, _em.PassKey);
                if (_em.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _em.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder msgBuild = new StringBuilder()
                    .AppendLine("New Order Has Been Submited")
                    .AppendLine("----------------------------------------")
                    .AppendLine("Product : ");
                foreach (var item in car.GetAllCart)
                {
                    var SubTotal = item.products.pro_price * item.Quantitty;
                    msgBuild.AppendFormat("{0} X {1}(SubTotal : ${2})",item.Quantitty,item.products.pro_name,SubTotal);
                }
                msgBuild.AppendFormat("total Order :${0}", car.TotalValue())
                    .AppendLine("----------------------------------------")
                    .Append("Ship To")
                    .Append(Ship.Name)
                    .Append(Ship.AddressA)
                    .Append(Ship.AddressB)
                    .Append(Ship.Country)
                    .Append(Ship.City)
                    .Append(Ship.State)
                    .AppendLine("----------------------------------------")
                    .AppendFormat("Gift :{0}", Ship.Gift ? "Yes" : "No");

                MailMessage mailmsg = new MailMessage(_em.MailFrom,_em.MailTo,"New Order Submited",msgBuild.ToString());
                if (_em.WriteAsFile)
                {
                    mailmsg.HeadersEncoding = Encoding.ASCII;
                    try
                    {
                        smtpClient.Send(mailmsg);
                    }
                    catch (Exception ex)
                    {
                        Debug.Print("<<<< "+ ex.Message +" >>>>");
                    }
                }
                
            }
        }
    }
}