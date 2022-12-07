using Infrastructure.ServiceApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Tools.General;
using System.Linq;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;
using Ionic.Zip;
using System.IO.Compression;

namespace Infrastructure.ServiceApi
{
    public class Worker : BackgroundService
    {
        //private readonly ILogger<Worker> _logger;
        //private readonly IConfiguration configuration;
        //private readonly INotification not;
        string getRequestUrl = @"http://api.yaadamooz.com/FileInsertRequest/List";

        [Obsolete]
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;

        [Obsolete]
        public Worker(ILogger<Worker> logger, IServiceScopeFactory nikoSingle, IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting            )
        {
            //_logger = logger;
            //this.configuration = configuration;
            var scope = nikoSingle.CreateScope();
            this.hosting = hosting;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //ServerHandler server = new ServerHandler();
            //server.Initial(configuration.BindSection<SocketParameters>());
            while (true)
            {
                try
                {
                    MainLoop();
                    Thread.Sleep(5000000);
                }
                catch (Exception e1)
                {

                    Agent.FileLogger(@"C:\Test\ServiceLog.txt", e1.ToString());
                }
            }
        }

        private void MainLoop()
        {


            var request = GetRequests(getRequestUrl);



            if (request.@object.Count >= 1)
            {
                request.@object.ForEach(p =>
                {
                    Console.WriteLine("here");



                    string zipPath = @"./wwwroot/9d5175dc-7de1-436a-b451-2c880805b0c9.zip";

                    string extractPath = "./wwwroot/";

                    // Normalizes the path.
                    extractPath = Path.GetFullPath(extractPath);
                    string fu = Path.GetFullPath(zipPath);

                    Console.WriteLine(extractPath);
                    Console.WriteLine(fu);


                    // Ensures that the last character on the extraction path
                    // is the directory separator char.
                    // Without this, a malicious zip file could try to traverse outside of the expected
                    // extraction path.
                    if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                        extractPath += Path.DirectorySeparatorChar;

                    using (ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(zipPath))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            Console.WriteLine(entry);
                            if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                            {
                                // Gets the full path to ensure that relative segments are removed.
                                string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

                                // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                                // are case-insensitive.
                                if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
                                    entry.ExtractToFile(destinationPath);
                            }
                        }
                    }











                });

            }

        }


        private async Task<string> ChangeOrderPrintStatusAsync(string changeStatusUri, ChangeStausObject changeStausObject)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 10);
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.DefaultRequestHeaders.Clear();

                    var uri = new Uri(changeStatusUri);

                    var httpRequestMessage = new HttpRequestMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(changeStausObject), Encoding.UTF8, "application/json")
                    };

                    httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsync(uri, httpRequestMessage.Content);//new StringContent(JSON, Encoding.UTF8, "application/json")

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                        return response.StatusCode.ToString();

                }

            }
            catch (Exception e2)
            {

                return e2.Message;
            }


        }

        private DateTime GetDateByUnix(long createdAt)
        {

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(createdAt).ToLocalTime();
            return dtDateTime;
        }

        private Requests GetRequests(string uri)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var str = reader.ReadToEnd();
                Console.WriteLine(str);
                return JsonConvert.DeserializeObject<Requests>(str);

            }
        }




    }

}