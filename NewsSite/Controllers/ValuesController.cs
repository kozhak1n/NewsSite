using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsSite.Data;
using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        AppDbContent db;
        public ValuesController(AppDbContent context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> Get()
        {
            return await db.News.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> Get(Guid id)
        {
            News news = await db.News.FirstOrDefaultAsync(x => x.id == id);
            if (news == null)
                return NotFound();
            return new ObjectResult(news);
        }

        [HttpPost]
        public async Task<ActionResult<News>> Post(News news)
        {
            if (news == null)
            {
                return BadRequest();
            }

            db.News.Add(news);
            await db.SaveChangesAsync();
            return Ok(news);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<News>> Put(Guid id, News news)
        {
            if (news == null)
            {
                return BadRequest();
            }
            if (id !=news.id)
            {
                return NotFound();
            }

            db.Update(news);
            await db.SaveChangesAsync();
            return Ok(news);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> Delete(Guid id)
        {
            News news = db.News.FirstOrDefault(x => x.id == id);
            if (news == null)
            {
                return NotFound();
            }
            db.News.Remove(news);
            await db.SaveChangesAsync();
            return Ok(news);
        }
    }
}

