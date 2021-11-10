using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MvcApplication.Models;
using MongoDB.Driver.Builders;

namespace MvcApplication.Controllers.Api
{
    public class TimesheetsController : ApiController
    {
        private readonly MongoDatabase _mongoDb;
        private readonly MongoCollection<Timesheet> _repository;

        public TimesheetsController()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBTimesheets"];
            _mongoDb = MongoDatabase.Create(connectionString);

            _repository = _mongoDb.GetCollection<Timesheet>(typeof (Timesheet).Name);
        }

        // GET /api/timesheets
        public HttpResponseMessage Get()
        {
            var timesheets = _repository.FindAll().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, timesheets);
            string uri = Url.Route(null, null);
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // GET /api/timesheets/4fd63a86f65e0a0e84e510de
        [HttpGet]
        public Timesheet Get(string id)
        {
            var query = Query.EQ("_id", new ObjectId(id));
            return _repository.Find(query).Single();
        }

         // POST /api/timesheets
        [HttpPost]
        public HttpResponseMessage Post(Timesheet timesheet)
        {
            _repository.Insert(timesheet);
            string uri = Url.Route(null, new { id = timesheet.Id }); // Where is the new timesheet?
            var response = Request.CreateResponse(HttpStatusCode.Created, timesheet);
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // PUT /api/timesheets
        [HttpPut]
        public HttpResponseMessage Put(Timesheet timesheet)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, timesheet);
            _repository.Save(timesheet);
            string uri = Url.Route(null, new { id = timesheet.Id }); // Where is the modified timesheet?
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // DELETE /api/timesheets/4fd63a86f65e0a0e84e510de
        public HttpResponseMessage Delete(params string[] ids)
        {
            foreach (var id in ids)
            {
                _repository.Remove(Query.EQ("_id", new ObjectId(id)));
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
