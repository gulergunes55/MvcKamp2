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
    public class ImageFileManager : IImagesFileService
    {
        IImagesDal _ImagesDal;

        public ImageFileManager(IImagesDal ımagesDal)
        {
            _ImagesDal = ımagesDal;
        }

        public List<ImageFile> GetList()
        {
            return _ImagesDal.List();
        }
    }
}
