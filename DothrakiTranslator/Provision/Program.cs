using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace Provision
{
    class Program
    {
        static void Main(string[] args)
        {
            var adminTenantUrl = args[0];
            var url = args[1];
            var userName = args[2];
            var password = args[3];

            Provision.CreateSiteCollection(adminTenantUrl, userName, password, url);
            Provision.ProvisionArtifacts(url, userName, password);
        }

     
       

        #region: testing purpose 
        //private static void CreateSiteCollection()
        //{         
        //    //Open the Tenant Administration Context with the Tenant Admin Url
        //    using (ClientContext tenantContext = new ClientContext("https://acdc1802-admin.sharepoint.com"))
        //    {
        //        //Authenticate with a Tenant Administrator
        //        SecureString passWord = new SecureString();
        //        foreach (char c in "".ToCharArray()) passWord.AppendChar(c);
        //        tenantContext.Credentials = new SharePointOnlineCredentials("adeel@ACDC1802.onmicrosoft.com", passWord);

        //        var tenant = new Tenant(tenantContext);

        //        //Properties of the New SiteCollection
        //        var siteCreationProperties = new SiteCreationProperties();

        //        //New SiteCollection Url
        //        siteCreationProperties.Url = "https://acdc1802.sharepoint.com/sites/Test3";

        //        //Title of the Root Site
        //        siteCreationProperties.Title = "Site Created from Code";

        //        //Email of Owner
        //        siteCreationProperties.Owner = "adeel@ACDC1802.onmicrosoft.com";

        //        //Template of the Root Site. Using Team Site for now.
        //        siteCreationProperties.Template = "STS#0";

        //        //Storage Limit in MB
        //        siteCreationProperties.StorageMaximumLevel = 100;

        //        //UserCode Resource Points Allowed
        //        siteCreationProperties.UserCodeMaximumLevel = 50;

        //        //Create the SiteCollection
        //        SpoOperation spo = tenant.CreateSite(siteCreationProperties);

        //        tenantContext.Load(tenant);

        //        //We will need the IsComplete property to check if the provisioning of the Site Collection is complete.
        //        tenantContext.Load(spo, i => i.IsComplete);

        //        tenantContext.ExecuteQuery();

        //        //Check if provisioning of the SiteCollection is complete.
        //        while (!spo.IsComplete)
        //        {
        //            //Wait for 30 seconds and then try again
        //            System.Threading.Thread.Sleep(30000);
        //            spo.RefreshLoad();
        //            tenantContext.ExecuteQuery();
        //        }

        //        Console.WriteLine("SiteCollection Created.");
        //    }
        //}
        #endregion: testing purpose


    }
}

