using System;
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

        public string foodDescription { get; set; }
        public double amount { get; set; }
        public double calories { get; set; }
        public double fat { get; set; }
        public double protein { get; set; }
        public double carbohydrates { get; set; }
        
    }
}
