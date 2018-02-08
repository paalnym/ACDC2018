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
        public static void ProvisionArtifacts(string url, string username)
        {            
            using (var context = new ClientContext(url))
            {
                var password = new SecureString();

                SecureString passWord = new SecureString();
                foreach (char c in "Rap80436".ToCharArray()) passWord.AppendChar(c);
                context.Credentials = new SharePointOnlineCredentials(username, passWord);

                var web = context.Web;
                //context.Load(web);
                context.Load(web, w => w.Title);
                context.ExecuteQuery();

                var provider = new XMLFileSystemTemplateProvider(String.Format(@"{0}\..\..\", AppDomain.CurrentDomain.BaseDirectory), string.Empty);
                var template = provider.GetTemplate("Template.xml");
                
                web.ApplyProvisioningTemplate(template);
            }
        }
    }
}
