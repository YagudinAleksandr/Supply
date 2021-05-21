using Supply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Файл структур и классов для общей работы
 */
namespace Supply.Libs
{
    public enum PaymentsTypes
    {
        Month,
        Day,
        Year
    }

    public class PaymentMethods
    {
        public static int PaymentCreation(Payment payment,PaymentsTypes paymentsTypes)
        {
            if(paymentsTypes==PaymentsTypes.Day)
            {
                if(payment.PaymentType=="День")
                {
                    return int.Parse(payment.Rent.ToString());
                }
                else if(payment.PaymentType=="Месяц")
                {
                    return int.Parse((payment.Rent / 30).ToString());
                }
            }
            return int.MinValue;
        }
    }
}
