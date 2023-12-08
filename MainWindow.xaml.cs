using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Finale
{
    //Hafsa Mohamed
    //i didnt have enough time to finish i got work lol

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Category> _categories;

        Category selectedCategory;

        public MainWindow()
        {
            InitializeComponent();


            //preloading categories to combobox
            _categories = new List<Category>
            {
                new Category("Today"),
                new Category("Shopping"),
                new Category("Travel")
            };

            // Adding items to our Today category
            int index = 0;
            _categories[index].AddItemToCategory(new Item("Grocery Shopping", "Go to Fred Meyers", false, true));

            // Adding items to our Shopping category
            index = 1;
            _categories[index].AddItemToCategory(new Item("Pick up Cat Food", "Get Cuts", true, true));

            // Adding items to our Travel category
            index = 2;
            _categories[index].AddItemToCategory(new Item("Pick up travel adapter", "Make sure it covers the UK", true, true));

            //assign categories to your combobox itemsource
            cbToDo.ItemsSource = _categories;

            //set selected index of your combobox to 0 and ensure the first itme is selected
            cbToDo.SelectedIndex = 0;
            lvDisplayList.ItemsSource = _categories;

            

        } //mainwindow

        private void cbToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //when new category is sleected the items in _todoitemsincategory are displayed in listview
            selectedCategory = (Category)cbToDo.SelectedItem;

            //assign the categories name to the listview . itemsource
            lvDisplayList.ItemsSource = selectedCategory.ToDoItemsInCategory;

        } //cbToDo_SelectionChanged

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //add new category
            Category newCategory = new Category(txtNewCategory.Text);
            _categories.Add(newCategory);

            //refresh the combobox to show the nexr category
            cbToDo.Items.Refresh();
            

        } //btnAdd_Click

        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            //create new item and assign it to the curently selected category
            Item newItem = new Item(txtNewCategory.Text, rtbDescription.Text, chkHighImportance.IsChecked ?? false, chkTimeSensitive.IsChecked ?? false);
            selectedCategory.AddItemToCategory(newItem);

            //validation requires name and description. if either are empty display a messagebox saying "please enter name and description"



            //refresh the listveiw
            lvDisplayList.Items.Refresh();

        } //btnAddToList_Click

        private void btnUpdateSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            //when clicked the item seleted in the liost is updated with the info
            Item selectedItem = (Item)lvDisplayList.SelectedItem;
            selectedItem.Name = txtTask.Text;
            selectedItem.Description = rtbDescription.Text;
            selectedItem.HighImportance = chkHighImportance.IsChecked ?? false;
            selectedItem.TimeSensitive = chkTimeSensitive.IsChecked ?? false;

            //if completed radio button is selected then the selected items assignmentCompleted() methid ahould be called
            if (rbCompleted.IsChecked == true)
            {
                selectedItem.AssignmentCompleted();
            }


            //refresh the listview
            lvDisplayList.Items.Refresh();

        } //btnUpdateSelectedItem_Click

        private void btnClearBoxes_Click(object sender, RoutedEventArgs e)
        {
            //we clear all boxes and set the rb and chk back to default
            txtTask.Text = "";
            rtbDescription.Text = "";
            rtbDisplay.Text = "";
            chkHighImportance.IsChecked = false;
            chkTimeSensitive.IsChecked = false;
            rbNotCompleted.IsChecked = true;

            //set the selected index to -1 deselts everything from the listview
            lvDisplayList.SelectedIndex = -1;

        } //btnClearBoxes_Click

        private void lvDisplayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //The task TextBox, description RTB, two check boxes and the radio button are all updated with information from the selected item.

            //Item selectedItem = (Item)lvDisplayList.SelectedItem;

            //txtTask.Text = selectedItem.Name;
            //rtbDescription.Text= selectedItem.Description;
            //chkHighImportance.IsChecked = selectedItem.HighImportance;
            //chkTimeSensitive.IsChecked = selectedItem.TimeSensitive;
            //rbNotCompleted.IsChecked = selectedItem.IsCompleted;

            //rtbDisplay.AppendText(selectedTask.DisplayInformation());

        } //lvDisplayList_SelectionChanged


    }//class


} //namespace
