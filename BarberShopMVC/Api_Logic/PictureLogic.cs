using BarberShopMVC.Api_Repo;
using BarberShopMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BarberShopMVC.Api_Logic
{
    public class PictureLogic : IPictureLogic
    {
        private readonly IPictureRepo _pictureRepo;
        public PictureLogic(IPictureRepo pictureRepo)
        {
            _pictureRepo = pictureRepo;
        }

        public async Task CreatePicture(Picture model)
        {
            await _pictureRepo.CreatePicture(model);
        }

        public async Task<IList<Picture>> GetPictures()
        {            
            var pictures = await _pictureRepo.GetPictures();
            return pictures;
        }
    }
}