using Box.V2;
using Box.V2.Auth;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace boxApp
{
    class Program
    {
        static void test_app_myapp0926()
        {
            var config = new BoxConfig("ol91r17fhsvzdsnny8xgkaiy5jkgxfw8", "956pFqJsfy1Nn7yAajRhIn6eHc2eidMa", new Uri("http://localhost"));
            var session = new OAuthSession("nHe4pvCa3BXqnVbXnjOI4xnfCjpkobBj", "NOT_NEEDED", 3600, "bearer");
            var client = new BoxClient(config, session);
            var user_info = client.UsersManager.GetCurrentUserInformationAsync().Result;
            var items = client.FoldersManager.GetFolderItemsAsync("0", 100).Result;
        }

        static void test_app_mycapp()
        {
            var config = new BoxConfig("m4i3pi5dpz0wbanc2fm8m0ir66qyr4dh", "zCvs6w94X8tgkFce1d5RbGbiudYjfylK", new Uri("http://localhost"));
            var session = new OAuthSession("O35fialsYuSQH1vblbaYR0K6oBY0gwK0", "NOT_NEEDED", 3600, "bearer");
            var client = new BoxClient(config, session);
            var user_info = client.UsersManager.GetCurrentUserInformationAsync().Result;
            var items = client.FoldersManager.GetFolderItemsAsync("0", 100).Result;
        }

        static void test_app_mycapp_2()
        {
            IBoxConfig config = null;
            using (FileStream fs = new FileStream("87881712_nqkf95rj_config.json", FileMode.Open))
            {
                config = BoxConfig.CreateFromJsonFile(fs);
            }

            var boxJWT = new BoxJWTAuth(config);

            var adminToken = boxJWT.AdminToken();
            var adminClient = boxJWT.AdminClient(adminToken);
            var user_info = adminClient.UsersManager.GetCurrentUserInformationAsync().Result;
            var items = adminClient.FoldersManager.GetFolderItemsAsync("0", 100).Result;
            var users = adminClient.UsersManager.GetEnterpriseUsersAsync().Result;
            user_info = adminClient.UsersManager.GetUserInformationAsync("224172711").Result;

            var client_token = boxJWT.UserToken("224172711");
            var client = boxJWT.UserClient(client_token, "224172711");
            items = client.FoldersManager.GetFolderItemsAsync("0", 100).Result;
        }

        static JObject test_json()
        {
            JObject ret = null;
            string s = System.IO.File.ReadAllText("87881712_6vcvibrd_config.json");
            try
            {
                ret = JObject.Parse(s);
            }
            catch (Exception) { }
            return ret;
        }

        static void Main(string[] args)
        {
            test_app_mycapp_2();
            //test_json();
        }
    }
}
