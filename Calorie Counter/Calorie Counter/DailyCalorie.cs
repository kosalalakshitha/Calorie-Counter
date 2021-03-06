﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calorie_Counter
{
    public class DailyCalorie
    {
        public DailyCalorie()
        {
            foodDescription = "";
            amount = 0;
            calories = 0;
            fat = 0;
            protein = 0;
            carbohydrates = 0;
        }
        public DailyCalorie(string foodDesc, double amount, double calories, double fat, double protein, double carbohydrates)
        {
            foodDescription = foodDesc;
            this.amount = amount;
            this.calories = calories;
            this.fat = fat;
            this.protein = protein;
            this.carbohydrates = carbohydrates;
        }

        public string foodDescription { get; set; }
        public double amount { get; set; }
        public double calories { get; set; }
        public double fat { get; set; }
        public double protein { get; set; }
        public double carbohydrates { get; set; }
        public DateTime dateTime { get; set; }

        public override string ToString()
        {
            return foodDescription + " contained " + amount + " in amount, " + calories + " in calorie, " + protein + " in protein, " + fat + " in fat and " + carbohydrates + " in carbohydrates.  ______________________________________________________________________________________________________________________________________________";
        }
    }
}
