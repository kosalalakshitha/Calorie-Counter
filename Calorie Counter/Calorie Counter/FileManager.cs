using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;

namespace Calorie_Counter
{
    static class FileManager
    {
        public const string JSONFILENAME = "dailyCalories.json";


        public static async Task writeXMLAsync()
        {
            var seriealizer = new DataContractJsonSerializer(typeof(List<DayData>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(JSONFILENAME, CreationCollisionOption.ReplaceExisting))
            {
                seriealizer.WriteObject(stream, GlobalData.dayData);
                MessageDialog success = new MessageDialog("Data saved!");
                await success.ShowAsync();
            }
        }

        public static async Task readJsonAsync()
        {
            try
            {
                var jasonSerializer = new DataContractJsonSerializer(typeof(List<DayData>));
                var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
                GlobalData.dayData = (List<DayData>)jasonSerializer.ReadObject(stream);
            }
            catch (Exception)
            {
            }

            //string content = string.Empty;

            //var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(XMLFILENAME);
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    content = await reader.ReadToEndAsync();
            //}
        }
    }
}
