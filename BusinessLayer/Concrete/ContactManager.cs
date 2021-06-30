using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal )
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public Contact ContactgetByID(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public void ContactUptade(Contact contact)
        {
            _contactDal.Uptade(contact);
        }

        public List<Contact> GetContactsList()
        {
           return _contactDal.List().ToList();
        }
    }
}
