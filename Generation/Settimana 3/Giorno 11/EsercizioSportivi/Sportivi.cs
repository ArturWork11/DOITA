using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioSportivi
{
    public class SoccerPlayer
    {
        string sport;
        string name;
        string surname;
        double age;
        int numberShirt;
        string role;
        string team;

        public SoccerPlayer (string sport,string name,string surname, double age, int numberShirt, string role,string team)
        {
            this.sport = sport;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.numberShirt = numberShirt;
            this.role = role;
            this.team = team;
        }

        public string Card()
        {
            string result = "";
            result = $"Sport:{sport} \nName: {name} \nSurname {surname} \nAge: {age} \nShirt number: {numberShirt} \nRole: {role} \nTeam: {team}";
            return result ;
        }

    }
    public class TennisPlayer
    {
        string sport;
        string name;
        string surname;
        double age;
        string sponsor;
        string leftRight;

        public TennisPlayer(string sport, string name, string surname, double age, string sponsor, string leftRight)
        {
            this.sport = sport;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.sponsor = sponsor;
            this.leftRight = bool.Parse(leftRight) ? "left" : "right";
        }

        public string Card()
        {
            string result = "";
            result = $"Sport:{sport} \nName: {name} \nSurname {surname} \nAge: {age} \nSponsor: {sponsor} \nHand: {leftRight}";
            return result;
        }
    }
    public class Swimmer
    {

        string sport;
        string name;
        string surname;
        double age;
        string prefferedStyle;

        public Swimmer(string sport, string name, string surname, double age, string prefferedStyle)
        {
            this.sport = sport;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.prefferedStyle = prefferedStyle;
        }

        public string Card()
        {
            string result = "";
            result = $"Sport:{sport} \nName: {name} \nSurname {surname} \nAge: {age} \nFavourite style: {prefferedStyle}";
            return result;
        }
    }
    public class Boxer
    {
        string sport;
        string name;
        string surname;
        double age;
        double weight;

        public Boxer(string sport, string name, string surname, double age, double weight)
        {
            this.sport = sport;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.weight = weight;
        }

        public string Card()
        {
            string result = "";
            result = $"Sport:{sport} \nName: {name} \nSurname {surname} \nAge: {age} \nWeight: {weight}";
            return result;
        }

    }
    public class Rider
    {
        string sport;
        string name;
        string surname;
        double age;
        string vehicle;
        string team;


        public Rider(string sport, string name, string surname, double age, string vehicle, string team)
        {
            this.sport = sport;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.vehicle = vehicle;
            this.team = team;
        }

        public string Card()
        {
            string result = "";
            result = $"Sport:{sport} \nName: {name} \nSurname {surname} \nAge: {age} \nVehicle: {vehicle} \nTeam: {team}";
            return result;
        }
    }

   
}

