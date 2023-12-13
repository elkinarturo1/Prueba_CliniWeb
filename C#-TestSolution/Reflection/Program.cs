using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflection
{
    /*
     * Imagine we need to fill a dropdown with all the properties of the Contact class.
     * We need to define an order and a display name for each one of the Contact class properties (FirstName, LastName, etc).
     * The goal is to implement this logic in a way I can add new properties (or change the sort order or display name for existing ones) without the need to change any main logic
     * 
     * For example we may want to display the Contact class properties like this:
     * 
     * 1) Phone 
     * 2) First Name
     * 3) Last Name
     * 4) Address 
     * 
     * Notice that the display name for each property is different than the property name. Notice that the order is also different.
     * Notice that we want to display the properties of the model class, not the values of the properties for a specific instance of the model class
     */
    public class Program
    {
        static void Main(string[] args)
        {
            // As we do not have a UI, we will just get the list of properties here

            Contact contact = new Contact();
            contact.Phone = "123546899";
            contact.Address = "avenida siempre viva";
            contact.FirstName = "Homero";
            contact.LastName = "simpson";

            var modelProperties = GetContactClassProperties(contact);

            foreach (var modelProperty in modelProperties)
            {
                Console.WriteLine("PropertyName: {0}, DisplayName: {1}, Order: {2}", modelProperty.PropertyName, modelProperty.DisplayName, modelProperty.Order);
            }

            Console.ReadKey();
        }

        public static List<DropdownItem> GetContactClassProperties(object obj)
        {
            var result = new List<DropdownItem>();

            // TODO: Implement the logic here to get the Contact class properties as dropdown items


            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            int contador = 0;
            foreach (PropertyInfo property in properties)
            {
                DropdownItem dropdownItem = new DropdownItem();
                dropdownItem.Order = contador;
                dropdownItem.PropertyName = "Orden - " + contador.ToString();
                dropdownItem.DisplayName = property.Name;

                contador++;

                result.Add(dropdownItem);

            }         

            return result;

        }
    }
}
