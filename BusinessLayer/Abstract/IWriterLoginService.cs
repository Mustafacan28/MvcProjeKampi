using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
     interface IWriterLoginService
    {
        Writer GetWriterLogin(string x, string y);
    }
}
