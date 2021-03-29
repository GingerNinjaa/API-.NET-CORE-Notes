using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_.NET_CORE_Notes.data;
using API_.NET_CORE_Notes.Helpers;
using API_.NET_CORE_Notes.Models;
using Microsoft.AspNetCore.Http;

namespace API_.NET_CORE_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : Controller
    {
        private ApiDBcontext _dBcontext;

        public ArtistsController(ApiDBcontext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Artist artistObj)
        {
            //Store in blob storage.
            var imageUrl = await FileHelper.UploadImage(artistObj.Image);
            artistObj.ImageUrl = imageUrl;
            await _dBcontext.Artists.AddAsync(artistObj);
            await _dBcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
