using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API_.NET_CORE_Notes.data;
using API_.NET_CORE_Notes.Helpers;
using API_.NET_CORE_Notes.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace API_.NET_CORE_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : Controller
    {
        private ApiDBcontext _dBcontext;

        public SongsController(ApiDBcontext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        // GET: SongsController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dBcontext.Songs.ToListAsync());

        }

        // GET: SongsController
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _dBcontext.Songs.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);

        }

        //// GET: SongsController
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Song songObj)
        //{
        //    await _dBcontext.Songs.AddAsync(songObj);
        //    await _dBcontext.SaveChangesAsync();
        //    return StatusCode(StatusCodes.Status201Created);
        //}

        // GET: SongsController
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song songObj)
        {
            //Store in blob storage.
           var imageUrl= await FileHelper.UploadImage(songObj.Image);
           songObj.ImageUrl = imageUrl;
            await _dBcontext.Songs.AddAsync(songObj);
            await _dBcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }



        // GET: SongsController
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Song songObj)
        {
            var song = await _dBcontext.Songs.FindAsync(id);

            song.Title = songObj.Title;
            song.Language = songObj.Language;

            await _dBcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK);
        }

        // GET: SongsController
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _dBcontext.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

             _dBcontext.Songs.Remove(song);
            await _dBcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
