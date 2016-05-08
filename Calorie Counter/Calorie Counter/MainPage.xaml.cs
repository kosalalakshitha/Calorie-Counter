using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Calorie_Counter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.
            DailyCalorie data = e.Parameter as DailyCalorie;
            if (data != null)
                setFeilds(data);
            else
                ClearAll();

            if (GlobalData.dayData.Count == 0)
                await FileManager.readJsonAsync();

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void setFeilds(DailyCalorie data)
        {
            tbFoodDesc.Text = data.foodDescription;
            tbAmount.Text = data.amount.ToString();
            tbCalories.Text = data.calories.ToString();
            tbCarbohydrates.Text = data.carbohydrates.ToString();
            tbFat.Text = data.fat.ToString();
            tbProtein.Text = data.protein.ToString();
            btnSave.IsEnabled = false;
        }

        private void ClearAll()
        {
            tbFoodDesc.Text = "";
            tbAmount.Text = "0";
            tbCalories.Text = "0";
            tbCarbohydrates.Text = "0";
            tbFat.Text = "0";
            tbProtein.Text = "0";
            btnSave.IsEnabled = true;
        }

        private void tbAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            tbAmount.SelectAll();
        }

        private void tbCalories_GotFocus(object sender, RoutedEventArgs e)
        {
            tbCalories.SelectAll();
        }

        private void tbFat_GotFocus(object sender, RoutedEventArgs e)
        {
            tbFat.SelectAll();
        }

        private void tbProtein_GotFocus(object sender, RoutedEventArgs e)
        {
            tbProtein.SelectAll();
        }

        private void tbCarbohydrates_GotFocus(object sender, RoutedEventArgs e)
        {
            tbCarbohydrates.SelectAll();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DailyCalorie data = new DailyCalorie();
            double result;
            bool invalidInputs = false;
            bool found = false;

            if (tbFoodDesc.Text == "")
            {
                MessageDialog errorMessage = new MessageDialog("Please enter food description before proceed!");
                await errorMessage.ShowAsync();
                return;
            }
            data.foodDescription = tbFoodDesc.Text;
            invalidInputs = !double.TryParse(tbAmount.Text, out result);
            data.amount = result;
            invalidInputs = invalidInputs || !double.TryParse(tbCalories.Text, out result);
            data.calories = result;
            invalidInputs = invalidInputs || !double.TryParse(tbFat.Text, out result);
            data.fat = result;
            invalidInputs = invalidInputs || !double.TryParse(tbProtein.Text, out result);
            data.protein = result;
            invalidInputs = invalidInputs || !double.TryParse(tbCarbohydrates.Text, out result);
            data.carbohydrates = result;
            data.dateTime = DateTime.Now;

            if (invalidInputs)
            {
                MessageDialog errorMessage = new MessageDialog("Amount, Calories, Grams of fat, Grams of protein and Grams of carbohydrates feilds can only take numeric values!");
                await errorMessage.ShowAsync();
                return;
            }
            DateTime now = DateTime.Now;
            if (GlobalData.dayData == null)
                GlobalData.dayData = new List<DayData>();

            foreach (DayData dayData in GlobalData.dayData)
            {
                if (dayData.date.Date == now.Date)
                {
                    dayData.dailyData.Add(data);
                    found = true;
                }
            }
            if (!found)
            {
                DayData newDay = new DayData();
                newDay.date = data.dateTime;
                newDay.dailyData.Add(data);
                GlobalData.dayData.Add(newDay);
            }
            await FileManager.writeXMLAsync();
            ClearAll();
        }

        private void btnDaily_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewDailyCalorie));
        }
    }
}
