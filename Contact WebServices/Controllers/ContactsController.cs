using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactsDAL;
using ContactsDAL.Models;
using System.ComponentModel.DataAnnotations;


namespace Contact_WebServices.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class ContactsController : Controller
    {
        ContactsRepository repository;
        public ContactsController()
        {
            repository = new ContactsRepository();
        }
        

        [HttpGet]

        // 1. Get All Contacts
        public JsonResult GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                contacts = repository.GetAllContacts();
            }
            catch (Exception ex)
            {
                contacts = null;
            }
            return Json(contacts);
        }

        // 2. Search for contacts
        public JsonResult GetContactById(string contactId)
        {
            Contact contact = null;
            try
            {
                contact = repository.GetContactById(contactId);
            }
            catch (Exception ex)
            {
                contact = null;
            }
            return Json(contact);
        }

        [HttpPost]
        public JsonResult AddContacts(string ContactId, string Name, DateTime Birthday, DateTime MarriageAnniversay, string Notes)
        {
            bool status = false;           
            string message;
            try
            {
                //status = repository.AddContacts(contactId, Name, Notes/*Birthday, MarriageAnniversay*/);
                status = repository.AddContacts(ContactId, Name, Birthday, MarriageAnniversay, Notes);
                if (status)
                {
                    message = "Successful addition operation, ProductId = " + ContactId;
                }
                else
                {
                    message = "Unsuccessful addition operation!";
                }
            }
            catch (Exception ex)
            {
                message = "Some error occured, please try again!";
            }
            return Json(message);
        }

        //[HttpPost]
        //public JsonResult AddProductByModels(Contact contact)
        //{
        //    bool status = false;
        //    string message;

        //    try
        //    {
        //        status = repository.AddContactsUsingAddRange(contact);
        //        if (status)
        //        {
        //            message = "Successful addition operation, ProductId = " + contact.ContactId;
        //        }
        //        else
        //        {
        //            message = "Unsuccessful addition operation!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        message = "Some error occured, please try again!";
        //    }
        //    return Json(message);
        //}

        [HttpPut]
        public bool UpdateContact(string id, string name)
        {
            bool status = false;

            try
            {
                status = repository.UpdateContact(id,name);
               
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        [HttpDelete]
        public JsonResult DeleteContact(string ContactId)
        {
            bool status = false;

            try
            {
                status = repository.DeleteContact(ContactId);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
    }
}
