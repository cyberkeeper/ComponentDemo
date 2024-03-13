using People;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MultiPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// List of Person instances used in this example
        /// </summary>
        public List<Person> personSource;

        private string _fruit;

        /// <summary>
        /// Get the selected favourite fruit
        /// </summary>
        public string Fruit { get => _fruit; }

        /// <summary>
        /// Main entry point
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //center the window
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //initialise the demo data
            InitDataValues();
            InitComponents();
            //set the navigation buttons
            SortNavigation();
        }

        /// <summary>
        /// Load in the initial data to be used
        /// </summary>
        private void InitDataValues()
        {
            //create new instance of List and populate with objects of type person
            personSource =
            [
                new Person("Ado", "Main St", "Anywhere", "PA121RF", 23),
                new Person("Bob", 32),
                new Person("Carol", 29),
                new Person("Diane", "High St", "Overton", "G452ED", 21),
                new Person("Edgar", 34),
                new Person("Fiona", 19),
            ];
        }

        /// <summary>
        /// Populate the Listbox and the combobox with the data setup in the InitDataValues method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            CbThings.Items.Clear();
            LbThings.Items.Clear();
            InitComponents();
        }

        /// <summary>
        /// populate the list and comboboc
        /// </summary>
        private void InitComponents()
        {
            //load the data in the combobox and the listbox
            foreach (Person person in personSource)
            {
                CbThings.Items.Add(person);
                LbThings.Items.Add(person);
            }

            //check that the both components contains something and then set first index to be selected
            if ((!CbThings.Items.IsEmpty) && (!LbThings.Items.IsEmpty))
            {
                //set the first index as selected
                CbThings.SelectedIndex = 0;
                LbThings.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Get what item was selected in the comboBox and the listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetSelectedData(object sender, RoutedEventArgs e)
        {
            int personIndex = CbThings.SelectedIndex;
            Person personObj = CbThings.SelectedItem as Person;

            TxtComboBoxIndex.Text = personIndex.ToString();
            TxtComboBoxObject.Text = personObj.Print();

            int personIndex2 = LbThings.SelectedIndex;
            Person personObj2 = LbThings.SelectedItem as Person;

            TxtListBoxIndex.Text = personIndex2.ToString();
            TxtListBoxObject.Text = personObj2.Print();
        }

        /// <summary>
        /// Called when the favourite fruit radio button is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFruitChecked(object sender, RoutedEventArgs e)
        {
            //cast the sender object to what we expect
            RadioButton rbFruit = (RadioButton)sender;
            txtFavouriteFruit.Text = $"Currently selected fruit: {rbFruit.Tag}";

            _fruit = rbFruit.Content as string;

        }

        /// <summary>
        /// set the content as the selected fruit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetSelectedFruit(object sender, RoutedEventArgs e)
        {
            txtSelectedFruit.Text = _fruit;
        }

        /// <summary>
        /// Move to the next tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextTab(object sender, RoutedEventArgs e)
        {
            // Check if there are more tabs
            if (Viewer.SelectedIndex < Viewer.Items.Count - 1)
            {
                // Select the next tab
                Viewer.SelectedIndex++;


            }
            //sort buttons
            SortNavigation();
        }

        /// <summary>
        /// Move to previous tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackTab(object sender, RoutedEventArgs e)
        {
            // Check if there are more tabs
            if (Viewer.SelectedIndex > 0)
            {
                // Select the next tab
                Viewer.SelectedIndex--;
            }
            //sort buttons
            SortNavigation();
        }

        /// <summary>
        /// Enable or disable next/back navigation buttons as required.
        /// </summary>
        private void SortNavigation()
        {
            //if at end disable button
            btnNext.IsEnabled = (Viewer.SelectedIndex >= Viewer.Items.Count - 1) ? false : true;
            //the following does the exact same as the above line
            /*if (Viewer.SelectedIndex >= Viewer.Items.Count - 1)
            {
                btnNext.IsEnabled = false;
            }
            else
            {
                btnNext.IsEnabled = true;
            }*/

            //Same as above but with the back button
            btnBack.IsEnabled = (Viewer.SelectedIndex == 0) ? false : true;
        }

        /// <summary>
        /// Show the selected data in a new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShare_Click(object sender, RoutedEventArgs e)
        {
            //get selected fruit
            String fruit = _fruit;

            //get selected person
            Person p = CbThings.SelectedItem as Person;

            Second anWindow = new Second();

            anWindow.SetData(fruit, p);
            anWindow.Owner = this;
            this.Hide();
            anWindow.Show();

            //registers an event handler for the Closed event of the anWindow 
            anWindow.Closed += anWindow_Closed;

        }

        /// <summary>
        /// Event handler for the Second window closed event. Retrieves the data which is stored in 
        /// the ReturnedData
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void anWindow_Closed(object sender, EventArgs e)
        {
            string receivedData = ((Second)sender).ToBeReturnedData;
            txtRetrieved.Text = receivedData;
        }

        /// <summary>
        /// When the selected tab is changed, ensure that the back and next buttons are enabled/disabled appropriately
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Viewer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortNavigation();
        }

        /// <summary>
        /// A single method that is used for both check boxes. Uses the component name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            string compName = cb.Name;

            txtCBNum.Text = compName + " is checked";
        }

        /// <summary>
        /// A single method that is used for both check boxes. Uses the component tag.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            string compTag = cb.Tag as string;

            txtCBNum.Text = compTag + " is unchecked";
        }

        /// <summary>
        /// check that the user really want to exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "MultiPanel", MessageBoxButton.OKCancel, MessageBoxImage.Hand) == MessageBoxResult.Cancel)
            {
                //cancel the close event
                e.Cancel = true;
            }

        }

        /// <summary>
        /// Populate the combobox when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComboPopulate_Click(object sender, RoutedEventArgs e)
        {
            cbPerson.Items.Clear();

            //use the existing List of Person instances
            //add one item at a time.
            //foreach (Person p in personSource)
            //{
            //    cbPerson.Items.Add(p);
            // }

            //or alternatively do it in one action.
            cbPerson.ItemsSource = personSource;

            //if you don't want to see the ToString output of Person in the combobox you could do to display Name
            cbPerson.DisplayMemberPath = "Name";

            //The value returned can be different from the selected item
            cbPerson.SelectedValuePath = "Year";

            //set the first item as selected
            cbPerson.SelectedIndex = 0;
        }

        /// <summary>
        /// Retrieve information from the combobox when pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComboGet_Click(object sender, RoutedEventArgs e)
        {
            if (cbPerson.SelectedIndex >= 0)
            {//get selected index
                txtCBIndex.Text = cbPerson.SelectedIndex.ToString();

                //get selected value. Returns the what was set in SelectedValuePath, if not set this will return
                //the same as SelectedItem.
                txtCBItem.Text = (cbPerson.SelectedValue).ToString();

                //get selected item.
                txtCBValue.Text = (cbPerson.SelectedItem).ToString();
            }
        }

        /// <summary>
        /// Show some results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            GenerateResults();
        }

        /// <summary>
        /// Get what was entered in the text fields
        /// </summary>
        private void GenerateResults()
        {
            String output = "";
            if (IsTextCharacters(txtCharacter.Text))
            {
                output = "Text field contains only alphabetic characters\n";
            }
            else
            {
                output = "Text field contains something that isn't a alphabetic characters\n";
            }

            output += txtNumber.Text;
            output += txtEnter.Text;

            txtFeedback.Text = output;
        }
        /// <summary>
        /// matches a string that starts (^) and ends ($) with one or more (+) occurrences of numbers/digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool IsTextNumeric(string text)
        {
            return Regex.IsMatch(text, @"^\d+$");
        }

        /// <summary>
        /// matches a string that starts (^) and ends ($) with one or more (+) occurrences of characters between
        /// lowercase a to z or uppercase A to Z.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool IsTextCharacters(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// check what the user entered before it is echoed to the textfield. If it isn't a number don't let it be entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumber_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!IsTextNumeric(e.Text))
            {
                e.Handled = true;
                txtFeedback.Text += "Sorry no non numbers allowed!";
            }
        }

        /// <summary>
        /// Detect if the enter key was pressed while the txtEnter textfield had focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEnter_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //call the method that we need
                GenerateResults();
            }
        }

        /// <summary>
        /// clear results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClear_Click(object sender, RoutedEventArgs e)
        {
            txtFeedback.Text = "";
        }

        /// <summary>
        /// activated when the user tried to leave the textfield without entering bob.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBlocker_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtFeedback.Text.Equals("bob"))
            {
                txtFeedback.Text = "Welcome bob";
            }
            else
            {
                //txtFeedback.Text = "You need to unblock bob!";
                MessageBox.Show("You need to enter bob!", "Where's bob?", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}