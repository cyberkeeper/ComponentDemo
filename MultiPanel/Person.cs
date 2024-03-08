namespace People
{
    /// <summary>
    /// Simple class to represent a Person.
    /// Copied from the Simple Bank Part 1 tutorial.
    /// Demonstrates, 
    /// <list type="bullet">
    /// <item>Multiple constructors</item>
    /// <item>Chaining constructors</item>
    /// <item>Properties</item>
    /// <item>constants</item>
    /// </list>
    /// </summary>
    /// 
    public class Person
    {
        // Declare the default name to be used if nothing is supplied. The const keyword shows that
        // the value must be known at compile time and can not be changed.
        private const String DEFAULT_NAME = "Student";

        //instance variables (attributes)
        private string _name;
        private int _yearOfBirth;
        private Address _address;

        /// <summary>
        /// public properties for getting and setting Name attribute. The set is actioned by using the
        /// SetName method which adds some extra logic.
        /// </summary>
        public String Name { get => _name; set => SetName(value); }

        /// <summary>
        /// public properties for getting and setting Year atribute.
        /// </summary>
        public int Year
        {
            get { return _yearOfBirth; }
            set { _yearOfBirth = value; }
        }
        /// <summary>
        /// public properties for getting Address atribute. MyAddress is used as the name of the Property to avoid
        /// confusion with the data type called Address.
        /// </summary>
        public Address MyAddress
        {
            get { return _address; }
        }

        /// <summary>
        /// Default constructor. Creates a person who has no name, 0 age and no address.
        /// </summary>
        public Person()
        {
            _address = new Address();
            SetAddress(Address.DEFAULT_UNKNOWN, Address.DEFAULT_UNKNOWN, Address.DEFAULT_UNKNOWN);
            Year = 0;
            Name = DEFAULT_NAME;
        }

        /// <summary>
        /// constructor1, only the name is supplied. The default constructor is called to initialise
        /// the other fields.
        /// </summary>
        /// <param name="name"></param>
        public Person(String name) : this()
        {
            //comment out the next three lines as they are the same as in the base constructor.
            //address = new Address();
            //setAddress("unkown", "unknown", "unknown");
            //Year = 0;
            Name = name;
        }

        /// <summary>
        /// constructor2, set the name and date of birth. The constructor1 which takes the name parameter
        /// is called to initialise the other fields.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="yr"></param>
        public Person(String name, int yr) : this(name)
        {
            //comment out the three lines that are duplicated in the chained constructors.
            //address = new Address();
            //setAddress("unkown", "unknown", "unknown");
            Year = yr;
            //Name = name;
        }

        /// <summary>
        /// constructor, sets name, date of birth and all address fields. the constructor2 is called to
        /// initialised name and year attributes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="street"></param>
        /// <param name="town"></param>
        /// <param name="pc"></param>
        /// <param name="yr"></param>
        public Person(String name, string street, string town, string pc, int yr) : this(name, yr)
        {
            _address = new Address();
            SetAddress(street, town, pc);
            //Year = yr;
            //Name = name;
        }

        /// <summary>
        /// Used to validate the input for the name field. If the input value is null then the 
        /// name is set to default value. 
        /// </summary>
        /// <param name="name"></param>
        public void SetName(String name)
        {
            if (name != null)
                _name = name;
            else
                _name = DEFAULT_NAME;
        }

        /// <summary>
        /// Set the address of this person
        /// </summary>
        /// <param name="street"></param>
        /// <param name="town"></param>
        /// <param name="pc"></param>
        public void SetAddress(string street, string town, string pc)
        {
            _address.Street = street;
            _address.Town = town;
            _address.Postcode = pc;
        }

        /// <summary>
        /// Override standard ToString method with how we want to the instance to be represented.
        /// The string output from this will be used to display in various WPF components
        /// </summary>
        /// <returns>String representation of object</returns> 
        public override string ToString()
        {
            string output = Name;
            return output;
        }

        public string Print()
        {
            String output = String.Format("{0}\n{1}\n{2}\n{3}\n", Name, Year, MyAddress.Street, MyAddress.Town);            return output;
        }
    }
}
