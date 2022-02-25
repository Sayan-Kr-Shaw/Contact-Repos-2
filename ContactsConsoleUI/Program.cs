// See https://aka.ms/new-console-template for more information
using System;
using ContactsDAL;
using ContactsDAL.Models;
using System.ComponentModel.DataAnnotations;


namespace ContactsConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactsRepository repository = new ContactsRepository();

            // 1. Get All Contacts
            
            //var contacts = repository.GetAllContacts();
            //Console.WriteLine("----------------------------------");
            //Console.WriteLine("ContactId\tName");
            //Console.WriteLine("----------------------------------");
            //foreach (var contact in contacts)
            //{
            //    Console.WriteLine("{0}\t\t{1}", contact.ContactId, contact.Name);
            //}


            // 2. Search for contacts
            
            //string ContactId = "1";
            ///*List<ContactDetails> lstContacts = */repository.GetContactById(ContactId);


            //    if (lstContacts.Count == 0)
            //    {
            //        Console.WriteLine("No contacts available under the contactId = " + ContactId);
            //    }
            //    else
            //    {
            //        Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ContactId", "Name", "Birth Date", "Marriage Anniversary ", "EmailID");
            //        Console.WriteLine("---------------------------------------------------------------------------------------");
            //        foreach (var contact in lstContacts)
            //        {
            //            Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", contact.ContactId,contact.Name,contact.Birthday,contact.MarriageAnniversary,contact.EmailId1);
            //        }
            //}


            // 3. Create contact
           
            //bool result = repository.AddContacts("5");
            //if (result)
            //{
            //    Console.WriteLine("New contact added successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong. Try again!");
            //}

            
            //Contact contactctOne = new Contact();
            //contactctOne.ContactId = "7";
            //contactctOne.Name = "Aron";
            //DateTime birthday = new DateTime(1977, 2, 27);
            //contactctOne.Birthday = birthday;
            //DateTime marriageAnniversary = new DateTime(2012, 1, 7);
            //contactctOne.MarriageAnniversary = marriageAnniversary;
            //contactctOne.Notes = "NA";

            //bool result = repository.AddContactsUsingAddRange(contactctOne);
            //if (result)
            //{
            //    Console.WriteLine("Product details added successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!!");
            //}


            //bool status = repository.AddContacts("8","ABC",new DateTime(1980,01,01),new DateTime(2012,03,02),"NA");
            //if (status)
            //{
            //    Console.WriteLine("Contact added succesfully");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred");
            //}

            //4.Update Contact
            
            bool result = repository.UpdateContact("8", "New Name");
            if (result)
            {
                Console.WriteLine("Contact details updated successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong. Try again!");
            }

            // 5. Delete Contact
            //ContactsRepository repository = new ContactsRepository();
            //bool status = repository.DeleteContact("5");
            //if (status)
            //{
            //    Console.WriteLine("Contact details deleted successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!!");
            //}
        }
    }
}
