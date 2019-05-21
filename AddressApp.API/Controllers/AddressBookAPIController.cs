using AddressApp.API.Models;
using AddressApp.Models.Models;
using AddressApp.Repository.DBContext;
using AddressApp.Services.Interfaces;
using AddressApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace AddressApp.API.Controllers
{
    [RoutePrefix("api/AddressBookAPI")]
    public class AddressBookAPIController : ApiController
    {
        private readonly IAddressBookService addressBookService;
        private readonly HostingEnvironment _hostingEnvironment;
        public AddressBookAPIController()
        {
            var context = new AddressDBEntities();
            this.addressBookService = new AddressBookService(context);
        }
        public AddressBookAPIController(HostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }
        public IEnumerable<AddressViewModel> Get()
        {
            List<AddressViewModel> model = new List<AddressViewModel>();
            addressBookService.GetAddressBooks().ToList().ForEach(u =>
            {
                AddressViewModel addressModel = new AddressViewModel
                {
                    id = u.id,
                    phoneNumber = u.phoneNumber,
                    name = u.name,
                    surname = u.surname,
                    emailAddress = u.emailAddress
                };
                model.Add(addressModel);
            });
            return model;
        }
        public AddressViewModel Get(int? id)
        {
            AddressViewModel model = new AddressViewModel();
            if(id.HasValue && id !=0)
            {
                AddressBook addressEntity = addressBookService.GetAddressBook(id.Value);
                model.phoneNumber = addressEntity.phoneNumber;
                model.name = addressEntity.name;
                model.surname = addressEntity.surname;
                model.emailAddress = addressEntity.emailAddress;
            }
            return model;
        }
        public void Post(AddressViewModel model)
        {
            AddressBook addressEntity = new AddressBook
            {
                id = model.id,
                phoneNumber = model.phoneNumber,
                name = model.name,
                surname = model.surname,
                emailAddress = model.emailAddress
            };
            addressBookService.InsertAddressBook(addressEntity);
        }
        public void Put(AddressViewModel model)
        {
            AddressBook addressEntity = addressBookService.GetAddressBook(model.id);
            addressEntity.phoneNumber = model.phoneNumber;
            addressEntity.name = model.name;
            addressEntity.surname = model.surname;
            addressEntity.emailAddress = model.emailAddress;

            addressBookService.UpdateAddressBook(addressEntity);
        }
        public void Delete(int id)
        {
            addressBookService.DeleteAddressBook(id);
        }
    }
}
