﻿namespace People
{
    /// <summary>
    /// Simple class to represent an address.
    /// Copied from the Simple Bank Part 1 tutorial.
    /// Demonstrates, 
    /// <list type="bullet">
    /// <item>Properties</item>
    /// <item>constants</item>
    /// <item>nullable string?</item>
    /// </list>
    /// </summary>
    public class Address
    {
        /// <summary>
        /// If a field is unknown then this value will be used instead. A const is by default 
        /// static so doesn't need to be declared as such.
        /// </summary>
        public const string DEFAULT_UNKNOWN = "unknown";

        //instance variables/fields
        private string? _street;
        private string? _town;
        private string? _postcode;
       

        /// <summary>
        /// public properties to get and set the Street class attribute. Data encapsulsation.
        /// </summary>
        public string? Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
            }
        }
        /// <summary>
        /// public properties to get and set the Town class attribute. Data encapsulsation.
        /// </summary>
        public string? Town
        {
            get
            {
                return _town;
            }
            set
            {
                _town = value;
            }
        }
        /// <summary>
        /// public properties to get and set the Postcode class attribute. Data encapsulsation.
        /// This property was auto generated by Visual Studio, the format is slightly different but
        /// it does the same.
        /// </summary>
        public string? Postcode { get => _postcode; set => _postcode = value; }

        /// <summary>
        /// Override standard ToString. Uses the properties to get the class attributes, could use
        /// the attribute directly with no side effect.
        /// </summary>
        /// <returns>String representation of object</returns>    
        public override string ToString()
        {
            string output = Street + "\n" + Town + "\n" + Postcode + "\n";
            return output;
        }
    }

}