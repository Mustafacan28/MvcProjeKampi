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
    public class MessageMenager : IMessageService
    {
        readonly IMessageDal _messageDal;

        public MessageMenager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetMessageListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetMessageListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public Message MessagegetByID(int id)
        {
            return _messageDal.Get(x => x.MesssageID == id);
        }

        public void MessageUptade(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
