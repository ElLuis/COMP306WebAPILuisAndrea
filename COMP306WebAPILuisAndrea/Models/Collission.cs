using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306WebAPILuisAndrea.Models
{
    public class Collission
    {
        [Key]
        public int ObjectId { get; set; }
        public int Year { get; set; }                   //
        public DateTime Date { get; set; }              //
        public String Street1 { get; set; }             //
        public String Street2 { get; set; }             //
        public String District { get; set; }            //
        public String NeighbID { get; set; }            //Neighbourhood ID
        public String NeighbName { get; set; }          //Neighbourhood Name
        public String RoadClassif { get; set; }         //Road Classification
        public String Latitude { get; set; }            //
        public String Longitude { get; set; }           //
        public String LocationCoord { get; set; }       // Location Coordinate
        public String TypeOfVehicle { get; set; }       //
    }
}
