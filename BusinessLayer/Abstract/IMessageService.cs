using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMessageService
    {
        List<Message> GetMessageListInbox(string p);
        List<Message> GetMessageListSendbox(string p);
        Message MessagegetByID(int id);
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUptade(Message message);
    }
}
