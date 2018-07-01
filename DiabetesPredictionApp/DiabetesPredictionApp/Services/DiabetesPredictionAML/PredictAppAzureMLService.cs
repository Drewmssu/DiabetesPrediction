using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DiabetesPredictionApp.Services.DiabetesPredictionAML
{
    public class PredictAppAzureMLService
    {
        public class StringTable
        {
            public string[] ColumnNames { get; set; }
            public string[,] Values { get; set; }
        }


        public async Task<string> Consume(string[,] values)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"TimesPregnant", "PlasmaGlucoseConcentrationFor2Hours", "DistolicBbloodPressure", "TricepsSkinfoldThickness", "HourSerumInsulin2Hour", "BodyMassIndex", "DiabetesPedigreeFunction", "Age", "HasDiabetes"},
                                Values = values
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "C5RVQMKypu/fM4rgdW0LNebYBrFf2x9NIz9ZVMIKDkq6ZSsDKY3Z44Sg+yVMMBLefde4KS+W+y8qYK+2kSfl8A=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/a301f818130d454cb1d76534d891309f/services/74891e3ad934498795e3009a3288e9cd/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);

                    throw new HttpRequestException(string.Format("The request failed with status code: {0}", response.StatusCode));
                }
            }
        }
    }
}