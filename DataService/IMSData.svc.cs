using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using IMS.DataAccess;
namespace DataService
{
    public class IMSData : DataService<IMSORMModelContainer>
    {
        // Diese Methode wird nur einmal aufgerufen, um dienstweite Richtlinien zu initialisieren.
        public static void InitializeService(DataServiceConfiguration config)
        {
			config.SetEntitySetAccessRule("*", EntitySetRights.All);
			config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
}
