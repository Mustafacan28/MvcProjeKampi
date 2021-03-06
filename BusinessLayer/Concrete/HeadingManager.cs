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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void HeadingAdd(Heading heading)
        {
             _headingDal.Insert(heading);
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetHeadingList()
        {
            return _headingDal.List();
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.Uptade(heading);
        }

        public void HeadingUptade(Heading heading)
        {
            _headingDal.Uptade(heading);
        }

        public List<Heading> GetWriterParameterList(int id)
        {
            return _headingDal.List(x=>x.WriterID == id);
        }
    }
}
