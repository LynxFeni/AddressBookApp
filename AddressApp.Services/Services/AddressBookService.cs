using AddressApp.Models.Models;
using AddressApp.Repository.DBContext;
using AddressApp.Repository.GenericRepository;
using AddressApp.Repository.Interfaces;
using AddressApp.Services.Interfaces;
using System.Collections.Generic;

namespace AddressApp.Services.Services
{
    public class AddressBookService: IAddressBookService
    {
        private IRepository<AddressBook> addressBookRepository;
        private readonly AddressDBEntities context;

        public AddressBookService(AddressDBEntities context)
        {
            this.context = context;
            this.addressBookRepository = new Repository<AddressBook>(context);
        }

        public IEnumerable<AddressBook> GetAddressBooks()
        {
            return addressBookRepository.GetAll();
        }

        public AddressBook GetAddressBook(int id)
        {
            return addressBookRepository.Get(id);
        }

        public void InsertAddressBook(AddressBook item)
        {
            addressBookRepository.Insert(item);
        }

        public void UpdateAddressBook(AddressBook item)
        {
            addressBookRepository.Update(item);
        }

        public void DeleteAddressBook(int id)
        {
            AddressBook address = addressBookRepository.Get(id);
            addressBookRepository.Remove(address);
            addressBookRepository.SaveChanges();
        }
    }
}
