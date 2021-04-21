using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class RESTFULexample
    {
        public static void Main()
        {
            Console.WriteLine("Enter URL to scan");
            string urltoscan = Console.ReadLine();
            WebRequest request = WebRequest.Create(urltoscan);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            var phrase = responseFromServer;
            //Console.WriteLine(phrase);
            Console.WriteLine("Enter topic to search");
            string testword = Console.ReadLine();
            int testsize = testword.Length;
            List<string> a = new List<string>();
            char firstletteru, firstletterl;
            firstletteru = Char.ToUpper(testword[0]);
            firstletterl = Char.ToLower(testword[0]);
            string testwordupper = testword.ToUpper();
            //Create linked list of strings of all possible matches of the keyword using length and first letter for search parameters.
            for (int i = 0; i < phrase.Length; i++)
            {

                if (phrase[i] == firstletteru || phrase[i] == firstletterl)
                {
                    a.Add(phrase.Substring(i, testsize));
                }
            }
            int counter = 0;
            string uppertester;
            //Scan created list for occurences of the topic regardless of case.
            foreach (string word in a)
            {
                // Console.WriteLine(word);
                uppertester = word.ToUpper();
                if (uppertester == testwordupper)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
            // Cleanup the streams and the response.

            reader.Close();
            dataStream.Close();
            response.Close();

        }
    }
}
