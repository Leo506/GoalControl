using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ToDoList
{
    public class SaveLoad
    {
        public static void Save(List<SaveGoal> goals)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "control.data");
            Trace.WriteLine(path);

            using (FileStream fs = File.Create(path))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, goals);
            }
        }

        public static List<SaveGoal>? Load()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "control.data");

            if (!File.Exists(path))
                return null;

            List<SaveGoal> save;

            using(FileStream fs = File.OpenRead(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                save = formatter.Deserialize(fs) as List<SaveGoal>;
            }

            return save;
        }
    }
}
