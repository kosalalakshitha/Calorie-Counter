using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calorie_Counter
{
    public class DayData
    {
        public List<DailyCalorie> dailyData = new List<DailyCalorie>();
        public DateTime date { get; set; }

        public override string ToString()
        {
            double cal, amount, protien, carbohydrate, fat;
            cal = 0;
            amount = 0;
            protien = 0;
            carbohydrate = 0;
            fat = 0;
            foreach (DailyCalorie calorie in dailyData)
            {
                cal += calorie.calories;
                amount += calorie.amount;
                protien += calorie.protein;
                carbohydrate += calorie.carbohydrates;
                fat += calorie.fat;
            }

            return "Daily Consumption for Day " + date.ToString().Split(' ')[0] + " is " + amount + " in amount, " + cal + " in calorie, " + protien + " in protein, " + fat + " in fat and " + carbohydrate + " in carbohydrates.  ______________________________________________________________________________________________________________________________________________";
        }
    }
}
