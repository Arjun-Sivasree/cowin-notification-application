using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace cowinNotification
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        const int retryTimeInSeconds = 20;
        const int minimumEligibleAge = 18;
        const int districtCode = 307; //307 ernakulam, 296 tvm

        public static async Task Main(string[] args)
        {
            Console.WriteLine("***********************");
            Console.WriteLine($"checking vaccine availability for center code {districtCode} for age {minimumEligibleAge}");
            Console.WriteLine("You will hear continuous beeps when vaccine slot is available");
            //Console.WriteLine("for Changing center and age criteria, change in appsettings.json");
            Console.WriteLine("***********************");

            for (int times = 0; times < 5000; times++)
            {
                await stepToNotification();
                Console.WriteLine(DateTime.Now);
                await Task.Delay(retryTimeInSeconds * 1000);
            }
        }

        public static async Task<Boolean> stepToNotification()
        {
            string responseBody = await checkSlotByUrl();
            Boolean status = slotAvailabilityFor18Plus(responseBody);
            if (status == true)
            {
                beepAlert();
            }
            return true;
        }

        public static async Task<string> checkSlotByUrl()
        {
            string responseString = null;
            try
            {
                DateTime today = DateTime.Today;

                string dateToday = today.ToString("d");
                string url = $"https://cdn-api.co-vin.in/api/v2/appointment/sessions/calendarByDistrict?district_id={districtCode}&date={dateToday}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                responseString = responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return responseString;
        }

        public static Boolean slotAvailabilityFor18Plus(string inputData)
        {
            Boolean status = false;

            //convert to json object
            cowinNotification.MasterData masterData = MasterData.FromJson(inputData);

            var centerData = masterData.Centers;

            foreach (var singleCenter in centerData)
            {
                var center = singleCenter.Name;
                foreach (var singleSession in singleCenter.Sessions)
                {
                    if (singleSession.MinAgeLimit == minimumEligibleAge && singleSession.AvailableCapacity > 0)
                    {
                        Console.WriteLine("**********please book************");
                        Console.WriteLine($"*******available on {singleSession.Date} at {center} for age: {singleSession.MinAgeLimit}, available: {singleSession.AvailableCapacity} *********");
                        status = true;
                    }
                }
            }
            return status;
        }

        public static void beepAlert()
        {
            int frequency = 600;
            int timeInterval = 500; //milliseconds
            int beepTimes = 50;

            for (int beepCounter = 0; beepCounter < beepTimes; beepCounter++)
            {
                Console.Beep(frequency, timeInterval);
            }

        }
    }
}
