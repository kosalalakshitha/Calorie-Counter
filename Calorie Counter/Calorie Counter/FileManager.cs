using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Calorie_Counter
{
    static class FileManager
    {
        public const string JSONFILENAME = "dailyCalories.json";


        public static async Task writeXMLAsync()
        {
            var seriealizer = new DataContractJsonSerializer(typeof(List<DailyCalorie>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(JSONFILENAME, CreationCollisionOption.ReplaceExisting))
            {
                seriealizer.WriteObject(stream, GlobalData.dailyCalories);
            }
        }

        public static async Task readXMLAsync()
        {
            var jasonSerializer = new DataContractJsonSerializer(typeof(List<DailyCalorie>));
            var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
            GlobalData.dailyCalories = (List<DailyCalorie>)jasonSerializer.ReadObject(stream);

            //string content = string.Empty;

            //var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(XMLFILENAME);
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    content = await reader.ReadToEndAsync();
            //}
        }
    }
}
