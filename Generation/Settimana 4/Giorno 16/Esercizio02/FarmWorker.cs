using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio02
{
    internal class FarmWorker : Entity
    {
        double _workYears;
        double _hourlyRate;
        int _dailyHours;
        bool _boardLodging;

        public double WorkYears { get => _workYears; set => _workYears = value; }
        public double HourlyRate { get => _hourlyRate; set => _hourlyRate = value; }
        public int DailyHours { get => _dailyHours; set => _dailyHours = value; }
        public bool BoardLodging { get => _boardLodging; set => _boardLodging = value; }

        public FarmWorker() { }
        public FarmWorker(string[] row) : base(row)
        {
            WorkYears = double.Parse(row[3]);
            HourlyRate = double.Parse(row[4]);
            DailyHours = int.Parse(row[5]);
            BoardLodging = row[6] == "S" ? true : false;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nYears of work: {WorkYears} \nHourly Rate: {HourlyRate} \nDaily Hours: {DailyHours} \nBoard and Lodging: {BoardLodging} \nMonthly Cost: {MonthlyCost()}";
        }

        public override double MonthlyCost()
        {
            double Y = 0;
            if (BoardLodging)
            {
                Y = 10;
            }
            else
            {
                Y = 20;
            }
            double X = Y + (WorkYears / 10);
            double price = 0;
            price = HourlyRate * DailyHours * X;
            return price;
        }

     
    }
}
