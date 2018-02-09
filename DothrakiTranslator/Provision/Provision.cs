using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

// Provision modern team site
// Style the modern team site
// Prompt for url to provision on

namespace Provision
{
    public class Provision
    {

        public static void CreateSiteCollection(string adminTenantUrl, string userName, string password, string newSiteCollectionUrl)
        {
            ///TODO: Need to check if the site collection exists
            //Open the Tenant Administration Context with the Tenant Admin Url
            using (ClientContext tenantContext = new ClientContext(adminTenantUrl))
            {
                //Authenticate with a Tenant Administrator

                SecureString passWord = new SecureString();
                foreach (char c in password.ToCharArray()) passWord.AppendChar(c);
                tenantContext.Credentials = new SharePointOnlineCredentials(userName, passWord);
              
                var tenant = new Tenant(tenantContext);

                if (tenant.SiteExists(newSiteCollectionUrl))
                {
                    Console.WriteLine("Site collection " + newSiteCollectionUrl + " already provisioned." );
                    return;
                }

                var siteCreationProperties = new SiteCreationProperties()
                {
                    Url = newSiteCollectionUrl,
                    Title = "Dothraki translator",
                    Owner = userName,
                    Template = "STS#0",
                    StorageMaximumLevel = 100,
                    UserCodeMaximumLevel = 50
                };

                //Create the SiteCollection
                SpoOperation spo = tenant.CreateSite(siteCreationProperties);
                tenantContext.Load(tenant);

                //We will need the IsComplete property to check if the provisioning of the Site Collection is complete.
                tenantContext.Load(spo, i => i.IsComplete);
                tenantContext.ExecuteQuery();

                //Check if provisioning of the SiteCollection is complete.
                while (!spo.IsComplete)
                {
                    //Wait for 30 seconds and then try again
                    System.Threading.Thread.Sleep(30000);
                    spo.RefreshLoad();
                    tenantContext.ExecuteQuery();
                }

                Console.WriteLine("SiteCollection Created.");
            }
        }


        public static void ProvisionArtifacts(string url, string username, string password)
        {
            Console.WriteLine("Provisioning/updating articafacts at " + url );
            using (var context = new ClientContext(url))
            {
                var securedPassword = new SecureString();
               
                foreach (char c in password.ToCharArray()) securedPassword.AppendChar(c);
                context.Credentials = new SharePointOnlineCredentials(username, securedPassword);

                var web = context.Web;
                //context.Load(web);+
                context.Load(web, w => w.Title);
                context.ExecuteQuery();

                var provider = new XMLFileSystemTemplateProvider(String.Format(@"{0}\..\..\", AppDomain.CurrentDomain.BaseDirectory), string.Empty);
                var template = provider.GetTemplate("Template.xml");
                
                web.ApplyProvisioningTemplate(template);
                Console.WriteLine("Done.");
            }
        }
    }
}
