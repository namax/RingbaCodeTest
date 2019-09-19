using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace RingbaCodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string downloadUrl = "https://ringba-test-html.s3-us-west-1.amazonaws.com/TestQuestions/output.txt";
            using (var client = new WebClient())
            {
                client.DownloadFile(new System.Uri(downloadUrl), "output.txt");
            }
            var stat = new TextStatistic();

            using (var streamReader = new StreamReader(@"output.txt"))
            {
                while (streamReader.Peek() >= 0)
                {
                    stat.AddNextChar(Convert.ToChar(streamReader.Read()));
                }
            }

            var render = new StatisticRenderer();
            render.renderInConsole(stat);
        }
    }
}
