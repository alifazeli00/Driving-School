using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dates
{
    public class DatesTeory
    {
    public int Id { get; set; }
    //public DateTime Date { get; set; }// tarikh
    //public DateTime Start { get; set; }//sat shoro
    //public DateTime End { get; set; }// sat payan
    //public string NameTeacher { get; set; }
    //public Subject Subject { get; set; }
    //    public ICollection<DatesTeory> ChildDatesTeory { get; set; } 

    //    public DatesTeory ParentDatesTeory { get; set; }
    //public int? ParentDatesTeoryId { get; set; }
    public ICollection<Users> users { get; set; }   

       
    
        public ICollection<ListDatesTeory> ListDatesTeory { get; set; }



    }
    public class ListDatesTeory
    {
        
        public int Id { get; set; }
        public DateTime Date { get; set; }// tarikh
        public DateTime Start { get; set; }//sat shoro
        public DateTime End { get; set; }// sat payan
        public string NameTeacher { get; set; }
        public Subject Subject { get; set; }
        public int? DatesTeoryId { get; set; }
        public DatesTeory DatesTeory { get; set; }
    }

    public enum Subject
    {
        /// <summary>
        /// آیینامه
        /// </summary>
        Ainame = 0,
        /// <summary>
        /// فنی
        /// </summary>
        Fani = 1,
    }

}
