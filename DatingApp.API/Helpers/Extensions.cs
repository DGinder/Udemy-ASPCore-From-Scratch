using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    //this class holds the extension to pre written classes
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message){
            //this adds the message as a header to the http response
            response.Headers.Add("Application-Error", message);
            //these are cors headers to allow the message to be viewed by the spa
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}