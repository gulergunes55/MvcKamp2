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
   public  class ContactManager: IContactService
    {
        IContactDal _Contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _Contactdal = contactdal;
        }

        public void ContactAdd(Contact contact)
        {
            _Contactdal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _Contactdal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _Contactdal.Update(contact);
        }

        public Contact GetByID(int id)
        {
            return _Contactdal.Get(x => x.ContactID == id);
        }

        public object GetContactDetails(string session)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetList()
        {
            return _Contactdal.List();
        }
        public Contact GetByIdContact(int id)
        {
            return _Contactdal.Get(x => x.ContactID == id);
        }

        public Contact GetByIdContactAndSetRead(int id, bool read)
        {
            return _Contactdal.Get(x => x.ContactID == id && x.IsRead == true);
        }

      
    }
}
