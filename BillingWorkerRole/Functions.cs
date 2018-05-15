using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goval.FacturaDigital.DataContracts.MobileModel;
using Goval.FacturaDigital.DataModel;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace BillingWorkerRole
{
    public class Functions
    {
        public static void MakeCallToHacienda([TimerTrigger("*/5 *  * * * *", RunOnStartup = true)] TimerInfo timerInfo, TraceWriter log)
        {
            string vLogInformation = string.Empty;
            try
            {
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vBillList = vContext.Bill.AsQueryable();
                    if (vBillList != null)
                    {
                        var vBillsToProcess = vBillList.Where<BillEntity>(x => x.Status.Equals(BillStatus.Processing.ToString()));
                        if (vBillsToProcess != null && vBillsToProcess.Any())
                        {
                            vLogInformation = "El conteo de facturas es de "+vBillsToProcess.Count();
                        }
                        else
                        {
                            vLogInformation = "No existen facturas en estado processing";
                        }

                    }
                    else
                    {
                        vLogInformation = "El resultado del billQueryable es null";
                    }

                    vContext.Database.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                vLogInformation = ex.ToString();
            }
            log.Info(vLogInformation +" at "+ DateTime.Now);
            Console.WriteLine(vLogInformation + " at " + DateTime.Now);
        }

    }
}
