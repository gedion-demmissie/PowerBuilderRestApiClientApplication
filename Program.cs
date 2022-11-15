using Microsoft.Extensions.Configuration;
using SimpleRestApiClientApplication.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace SimpleRestApiClientApplication
{
    /// <summary>
    /// Program to drive the SimpleRestApi service
    /// </summary>
    class Program
    {        
        private static IConfigurationBuilder builder = new ConfigurationBuilder()
                                                          .SetBasePath(Directory.GetCurrentDirectory())
                                                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                          .AddEnvironmentVariables();
        public static void  Main(string[] args)
        {
            var restApiClientConfig = new RestApiClientConfig();
            builder.Build().GetSection("RestApiClient").Bind(restApiClientConfig);

            var studentsPayload =  RestApiClient<List<StudentPayload>>.Get(url:restApiClientConfig.EndPointUrl, contentType:restApiClientConfig.ContentType , userAgent:restApiClientConfig.UserAgent).Result;
            foreach (var  studentPayload in studentsPayload)
            {
                Console.WriteLine($"Name: {studentPayload.name}.");
                Console.WriteLine($"Street: {studentPayload.street}.");
                Console.WriteLine($"City: {studentPayload.city}.");
                Console.WriteLine($"State: {studentPayload.state}.");
                Console.WriteLine($"Zip: {studentPayload.zip}.");
                Console.WriteLine();

            }
            
            Console.ReadKey();
        }       
    }
}
