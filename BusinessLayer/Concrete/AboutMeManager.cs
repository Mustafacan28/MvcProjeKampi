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
    public class AboutMeManager : IAboutMeService
    {
        IMyAboutDal _myAboutDal;

        public AboutMeManager(IMyAboutDal myAboutDal)
        {
            _myAboutDal = myAboutDal;
        }
        public List<AboutMe> GetAboutMelist()
        {
             return _myAboutDal.List();
        }
    }
}
