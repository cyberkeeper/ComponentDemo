using People;
using System.Windows;


namespace MultiPanel
{

    /// <summary>
    /// Interaction logic for Second.xaml
    /// </summary>
    public partial class Second : Window
    {
        private string toBeReturnedData;

        public string ToBeReturnedData { get => toBeReturnedData; set => toBeReturnedData = value; }

        public Second()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Use this to set the data that will be shown in this window
        /// </summary>
        /// <param name="fruit"></param>
        /// <param name="person"></param>
        public void SetData(string fruit, Person person)
        {
            if (person == null)
            {
                txtPerson.Text = "No person selected";
            }
            else
            {
                txtPerson.Text = person.Print();
            }

            if (fruit == null)
            {
                txtFruit.Text = "No fruit selected";
            }
            else
            {
                txtFruit.Text = fruit;
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ReturnPreviousScr();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ReturnPreviousScr();
        }

        /// <summary>
        /// close window and show the Owning screen.
        /// </summary>
        private void ReturnPreviousScr()
        {
            //set ToBeReturnedData to "nothing" if there is no text in the TextField else use the supplied text.
            ToBeReturnedData = (txtBackMain.Text.Length == 0) ? "nothing" : txtBackMain.Text;

            Owner.Show();
            this.Close();
        }
    }
}
