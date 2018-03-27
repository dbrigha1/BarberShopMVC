using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BarberShopMVC.Models;
using BarberShopMVC.Models.Entities;

namespace BarberShopMVC.Api_Repo
{
    public class PictureRepo : IPictureRepo
    {
        private readonly BarberShopContext _context;

        public PictureRepo(BarberShopContext context)
        {
            _context = context;
        }

        public async Task CreatePicture(Picture model)
        {
            _context.Pictures.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Picture>> GetPictures()
        {
            var pictures = await _context.Pictures.Where(x => true).ToListAsync();
            return pictures;            
        }

        public async Task<Picture> GetPicture(int id)
        {
            var picture =  await _context.Pictures.Where(x => x.PictureId == id).SingleOrDefaultAsync();
            return picture;
        }

        public async Task DeletePicture(int id)
        {
            var model = _context.Pictures.Where(x => x.PictureId == id).SingleOrDefault();
            _context.Pictures.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}