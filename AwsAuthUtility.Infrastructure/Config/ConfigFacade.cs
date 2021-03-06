﻿using System;
using System.IO;


namespace AwsAuthUtility.Infrastructure.Config
{
    class ConfigFacade
    {
     
        private readonly FileIniReader _fileINIReader;

        public ConfigFacade()
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + @"account.ini";

            if (!File.Exists(configPath))
                throw new FileNotFoundException("Can't found ini file configuration");

            _fileINIReader = new FileIniReader(configPath);
        }


        public string LoadAuthToken()
        {
            return _fileINIReader.ReadSection("TwilioProfile", "AuthToken");
        }


        public string LoadAccountSID()
        {
            return _fileINIReader.ReadSection("TwilioProfile", "AccountSID");
        }

        public string LoadPhoneTo()
        {
            return _fileINIReader.ReadSection("TwilioProfile", "PhoneTo");
        }


        public string LoadAwsEmail()
        {
            return _fileINIReader.ReadSection("AwsProfile", "Email");
        }


        public string LoadAwsPass()
        {
            return _fileINIReader.ReadSection("AwsProfile", "Password");
        }
    }
}
