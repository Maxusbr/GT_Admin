using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Getticket.Web.API.Models.Concerts
{
    /// <summary>
    /// Превью расписания концерта
    /// </summary>
    public class PreviewScheduleModel
    {
        public string Dates { get; set; } 
        public IEnumerable<string> Range { get; set; } 

        public IEnumerable<string> Times { get; set; } 
        
    }
}
