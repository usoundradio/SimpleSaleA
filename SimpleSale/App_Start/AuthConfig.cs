using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using SimpleSale.Models;

namespace SimpleSale
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

           OAuthWebSecurity.RegisterFacebookClient(
              appId: "307527119354256",
            appSecret: "b1e9a3b80c6d15dac5913909d5ad8f5e");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
