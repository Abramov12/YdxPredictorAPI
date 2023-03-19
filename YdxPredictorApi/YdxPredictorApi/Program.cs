using System;
using System.IO;
using System.Net;


namespace MyApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string Request = Console.ReadLine();
            WebRequest reqGET = WebRequest.Create(@"https://predictor.yandex.net/api/v1/predict/complete?key=YourPrivateKey" + Request + "&lang=en");
            WebResponse resp = reqGET.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string s = sr.ReadToEnd().Substring(98, 10);
            char[] result = s.ToCharArray();
            string res = "";
            for (int i = 0; i < result.Length; i++)
            {

                if (result[i] != '<')
                {
                    res += result[i];
                }
                else break;

            }

            Console.WriteLine(res);
        }
    }
}