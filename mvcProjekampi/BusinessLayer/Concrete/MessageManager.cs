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
   public  class MessageManager: IMessageService
    {
        ImagesFile _messageDal;

        public MessageManager(ImagesFile messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReciverMail == "admin@gmail.com");
        }
        public List<Message> GetListTrash()
        {
            return _messageDal.List(x => x.Trash == true);
        }



        public List<Message> GetListSendbox(string session)
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

       

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }

        public object GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }
        public List<Message> GetReadList(string session)
        {
            return _messageDal.List(x => x.Read == true && x.ReciverMail == session);
        }

        public List<Message> GetUnReadList(string session)
        {
            return _messageDal.List(x => x.ReciverMail == session && x.Read == false);
        }
    }
}
