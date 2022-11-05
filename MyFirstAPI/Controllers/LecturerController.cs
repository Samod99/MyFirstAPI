using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using MyFirstAPI.Services;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController : Controller
    {
        [HttpGet]
        [Route("getAll")]
        public Response getAllLecturer()
        {
            LecturerServices lecturerServices = new LecturerServices();
            return lecturerServices.getAllLecturer();
        }

        [HttpPost]
        [Route("insert")]
        public Response insertLecturer([FromBody]Lecturer lecturer)
        {
            LecturerServices lecturerService = new LecturerServices();
            return lecturerService.insertLecturer(lecturer);
        }

        [HttpPut]
        [Route("update")]
        public Response updateLecturer([FromBody] Lecturer lecturer)
        {
            LecturerServices lecturerService  = new LecturerServices();
            return lecturerService.updateLecturer(lecturer);
        }

        [HttpDelete]
        [Route("delete")]
        public Response deleteLecturer([FromQuery] String lecturerNo)
        {
            LecturerServices lecturerService = new LecturerServices();
            return lecturerService.deleteLecturer(lecturerNo);
        }

        [HttpGet]
        [Route("readByDepartment")]
        public Response readByDepartment([FromQuery]String dept_Name)
        {
            LecturerServices lecturerServices = new LecturerServices();
            return lecturerServices.readByDepartment(dept_Name);
        }
    }
}
