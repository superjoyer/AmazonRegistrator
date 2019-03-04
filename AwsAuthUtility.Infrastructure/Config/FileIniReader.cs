using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AwsAuthUtility.Infrastructure.Config
{
    public class FileIniReader
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, 
            StringBuilder retVal, int size, string filePath);

        private static Int32 _capacity = 1024;
        private readonly string _filePath;


        public FileIniReader(string filePath)
        {
            _filePath = filePath;
        }

        public string ReadSection(string section, string key)
        {
            StringBuilder stringBuilder = new StringBuilder(_capacity);
            Int32 i = GetPrivateProfileString(section, key, "", stringBuilder, _capacity, _filePath);
            return stringBuilder.ToString();
        }
    }
}
