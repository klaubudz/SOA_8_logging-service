using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogDB;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LoggingService.Controllers
{
    [Produces("application/json")]
    public class LogController : ODataController
    {
        private readonly LogContext _context;

        public LogController(LogContext context)
        {
            _context = context;
        }

        public Log Get([FromODataUri] int key)
        {
            return _context.Find<Log>(key);
        }

        [EnableQuery]
        public IQueryable<Log> Get() => _context.Logs;

        [EnableQuery]
        public Log Post([FromBody] Log log)
        {
            SetCurrentDateIfNull(log);
            _context.Logs.Add(log);
            _context.SaveChanges();
            return log;
        }

        private void SetCurrentDateIfNull(Log log)
        {
            if(log.Date == null)
            {
                log.Date = DateTime.Now;
            }
        }

        public IActionResult Delete([FromODataUri] int key)
        {
            var entity = _context.Logs.Find(key);
            if (entity == null)
            {
                return BadRequest();
            }
            _context.Logs.Remove(entity);
            _context.SaveChanges();
            return Ok();
        }
    }
}