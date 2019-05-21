using AddressApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressApp.Services.Interfaces
{
    public interface IAddressBookService
    {
        IEnumerable<AddressBook> GetAddressBooks();
        AddressBook GetAddressBook(int id);
        void InsertAddressBook(AddressBook item);
        void UpdateAddressBook(AddressBook item);
        void DeleteAddressBook(int id);
    }
}
