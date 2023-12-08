using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale
{
    internal class Category
    {
        //feilds
        string _name;
        List<Item> _todoItemsInCategory;

        //constructor
        public Category(string name)
        {
            _name = name;
            _todoItemsInCategory = new List<Item>();
        }

        //properties and get sets
        public string Name { get => _name; set => _name = value; }
        public List<Item> ToDoItemsInCategory { get => _todoItemsInCategory; set => _todoItemsInCategory = value; }

        //methods
        public void AddItemToCategory(Item item)
        {
            //pass an item in to add it to our category to do list
            //helps readability
            _todoItemsInCategory.Add(item);
        }//void AddItemToCategory(Item item)

        public override string ToString()
        {
            //return the category name
            //this is used to easily display the category name to our combo Box
            return _name;
        }


    }//class



}//namespace
