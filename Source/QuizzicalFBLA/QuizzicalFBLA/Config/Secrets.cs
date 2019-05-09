using System;
using System.Collections.Generic;
using System.Text;
using GameSparks.NET.Infrastructure.Settings;
using GameSparks.NET.Services;
using GameSparks.NET.Services.Authentication.Requests;
using GameSparks.NET.Services.Leaderboards.Requests;

namespace QuizzicalFBLA.Config
{
    // IF NOT FOR FBLA SUBMISSION THIS FILE IS USUALLY OMITTED FROM VERSION CONTROL
    public static class Secrets
    {
        // Auth0 credentials
        public const string Auth0Domain = "quizzical.auth0.com"; // Domain from Auth0 portal
        public const string Auth0ClientId = "NXTKxB8y78J54vqos2tFDhHt6ieXjCOO"; // ClientId from Auth0 portal
        public const string Auth0Audience = "https://quizzical.auth0.com/api/v2/"; // Audience from Auth0 portal

        // GameSparks credentials
        public const string GameSparksApiKey = "i380156WslTv";
        public const string GameSparksCredentials = "device";
        public const string GameSparksSecret = "tS1ucsVn8pPct7FkSs30xdFV1uDCogfL";
       
        // Visual Studio app center credentials
        public const string VSAppCenterAndroid = "android=b07e290b-6de6-47ba-96ee-b126f75815b5";
        public const string VSAppCenterUWP = "uwp=ac278b47-a061-44e5-96c0-389f70f445b8";
        public const string VSAppCenterIOS = "ios=74f30c0c-ab9a-480a-a785-d69ac8bd4283";
    }
}
