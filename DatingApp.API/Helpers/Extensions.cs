using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages){
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
        
        //This is a extension metod to the date time object
        public static int CatculateAge(this DateTime theDateTime){
            var age = DateTime.Today.Year - theDateTime.Year;
            if(theDateTime.AddYears(age) > DateTime.Today)
                age--;
            if(age <= -1)
                age = 0;

            return age;
        }
    }
}