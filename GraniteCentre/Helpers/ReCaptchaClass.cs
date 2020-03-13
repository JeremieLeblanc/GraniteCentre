﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteCentre.Helpers
{
    public class ReCaptchaClass
    {
        public static bool Validate(string EncodedResponse)
        {
            var client = new System.Net.WebClient();

            string SecretKey = "6LdMe0UUAAAAAPgrgva2cCTglHa9qDEmkwTMoMOY";

            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", SecretKey, EncodedResponse));

            var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaClass>(GoogleReply);

            return (captchaResponse.Success == "true" ? true : false);
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        public List<string> m_ErrorCodes;
    }
}
