using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale
{
    internal class Item
    {
        //feilds
        string _name;
        string _description;
        bool _highImportance;
        bool _timeSensitive;
        bool _isCompleted;

        // Constructor
        public Item(string name, string description, bool highImportance, bool timeSensitive)
        {
            _name = name;
            _description = description;
            _highImportance = highImportance;
            _timeSensitive = timeSensitive;
            _isCompleted = false;
        }


        //properties and get sets
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public bool HighImportance { get => _highImportance; set => _highImportance = value; }
        public bool TimeSensitive { get => _timeSensitive; set => _timeSensitive = value; }
        public bool IsCompleted { get => _isCompleted; set => _isCompleted = value; }


        //now methods
        public string DisplayInformation()
        {
            //return a string with the instanced items informstion
            string fullDisplay = "";

            fullDisplay += $"Name: {_name}\n";
            fullDisplay += $"Description: {_description}\n";
            fullDisplay += $"High Importance: {_highImportance}\n";
            fullDisplay += $"Time Sensitive: {_timeSensitive}\n";
            fullDisplay += $"Is Completed: { _isCompleted}";

            return fullDisplay;

        }//string DisplayInromation()

        public void AssignmentCompleted()
        {
            //assign true to the isCompleted 
            _isCompleted = true;

            //append Task Completed to the description
            _description += "\nTask Completed";

        }//void AssigmentCompleted()



    } //class

} //namespace
