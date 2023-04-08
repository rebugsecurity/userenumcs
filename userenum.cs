using System;
using System.Collections.Generic;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        List<string> usernames = new List<string>{"admin", "user1", "administrator", "test123", "root"};
        string urlTemplate = "https://example.com/users/{0}";

        foreach (string username in usernames)
        {
            string url = String.Format(urlTemplate, username);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine(username + ": exists");
                }
                else
                {
                    Console.WriteLine(username + ": not found");
                }
                response.Close();
            }
            catch (WebException ex)
            {
                Console.WriteLine(username + ": not found");
                continue;
            }
        }
    }
}