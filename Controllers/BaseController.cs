using iGPS_Help_Desk.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using iGPS_Help_Desk.Repositories;
using System.Configuration;
using Serilog;
using iGPS_Help_Desk.Views;
using System.Runtime.Serialization;
using System;

namespace iGPS_Help_Desk.Controllers
{
    public class BaseController
    {
        
        /// <summary>
        /// Concatenates single quotes around each string in a list
        /// mainly used for SQL IN functions
        /// </summary>
        /// <param name="listOfString"></param>
        /// <returns>String of each item in the list with
        /// a single quote and a comma between each</returns>
        public string ConcatStringFromList(List<string> listOfString)
        {
            if (listOfString.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }


            listOfString.ForEach(x =>
            {
                x.Trim();
            });
            
            return string.Join(",", listOfString.Select(i => $"'{i}'"));
        }
    }
}