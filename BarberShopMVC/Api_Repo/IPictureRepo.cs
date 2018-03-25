using BarberShopMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShopMVC.Api_Repo
{
    public interface IPictureRepo
    {
        Task<IList<Picture>> GetPictures();

        Task CreatePicture(Picture model);
    }
}
