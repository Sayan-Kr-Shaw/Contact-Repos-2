using ContactsDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;

namespace ContactsDAL
{
    public class ContactsRepository
    {
        ContactsDbContext context;
        public ContactsRepository()
        {
            context = new ContactsDbContext();
        }

        // 1. Get All Contacts
        public List<Contact> GetAllContacts()
        {
            var contactsList = (from contacts in context.Contacts
                                orderby contacts.ContactId
                                select contacts).ToList();
            return contactsList;
        }

        // 2. Search for contacts

        public Contact GetContactById(string contactId)
        {
            Contact contact = new Contact();
            try
            {
                contact = (from p in context.Contacts
                           where p.ContactId.Equals(contactId)
                           select p).FirstOrDefault();
            }
            catch (Exception)
            {
                contact = null;
            }
            return contact;
        }

        public void GetContactByContactId(string ContactId)
        {
           // List<ContactDetails> lstContacts = null;
            
           
               var lstContacts = context.Contacts.Join(context.EmailIds, p=>p.ContactId, c => c.ContactId, (x, y) => new {x,y }).
                    Select(r => new {r.x.ContactId,r.x.Name,r.x.Birthday,r.x.MarriageAnniversary,r.y.EmailId1 }).ToList();

            Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ContactId", "Name", "Birth Date", "Marriage Anniversary ", "EmailID");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            foreach (var contact in lstContacts)
            {
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", contact.ContactId, contact.Name, contact.Birthday, contact.MarriageAnniversary, contact.EmailId1);
            }



            //return lstContacts;
        }

        // 3. Add contact
        public bool AddContacts(string ContactId,string Name,DateTime Birthday, DateTime MarriageAnniversay, string Notes)                          // 3.1
        {

            bool status = false;
            Contact contact = new Contact();
            contact.ContactId = ContactId;
            contact.Name = Name;
            contact.Notes = Notes;
            contact.Birthday = Birthday;
            contact.MarriageAnniversary = MarriageAnniversay;
            try
            {
                //context.Contacts.Add(contact);                
                context.Add<Contact>(contact);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        

        // 4. Update Contact


        //public bool UpdateContact(Contact contacts)
        //{
        //    bool status = false;
        //    try
        //    {
        //        var contact = (from prdct in context.Contacts
        //                       where prdct.ContactId == contacts.ContactId
        //                       select prdct).FirstOrDefault<Contact>();
        //        if (contact != null)
        //        {
        //            contact.ContactId = contacts.ContactId;
        //            contact.Name = contacts.Name;
        //            contact.Birthday = contacts.Birthday;
        //            contact.MarriageAnniversary = contacts.MarriageAnniversary;
        //            contact.Notes = contacts.Notes;
        //            context.SaveChanges();
        //            status = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status = false;
        //    }
        //    return status;
        //}
        public bool UpdateContact(string ContactId, string newName)
        {
            bool status = false;
            Contact contact = context.Contacts.Find(ContactId);
            try
            {
                if (contact != null)
                {
                    contact.Name = newName;                   
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


        // 5. Delete Contact
        public bool DeleteContact(string ContactId)
        {
            Contact contact = null;
            bool status = false;
            try
            {
                contact = context.Contacts.Find(ContactId);
                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

    }
}
