using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class vmMovies
    {
        private String title;
        private int iD;
        private DateTime date;
        private String country;
        private String language;
        private String production;

        public string Title { get => title; set => title = value; }
        public int ID { get => iD; set => iD = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Country { get => country; set => country = value; }
        public string Language { get => language; set => language = value; }
        public string Production { get => production; set => production = value; }
    }
}