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
    public class ImageFileManager : IImageService
    {
        IImageFileDal _ımageFileDal;

        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ımageFileDal = ımageFileDal;
        }

        public About GetByImageId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Imageflile> GetImagefliles()
        {
           return _ımageFileDal.List();
        }

        public void ImageAdd(Imageflile ımageflile)
        {
            throw new NotImplementedException();
        }

        public void ImageDelete(Imageflile ımageflile)
        {
            throw new NotImplementedException();
        }

        public void ImageUpdate(Imageflile ımageflile)
        {
            throw new NotImplementedException();
        }
    }
}
