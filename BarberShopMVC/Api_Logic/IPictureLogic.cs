using BarberShopMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShopMVC.Api_Logic
{
    public interface IPictureLogic
    {
        Task<IList<Picture>> GetPictures();

        Task CreatePicture(Picture model);
        Task<Picture> GetPicture(int id);
        Task DeletePicture(int id);
    }
}
