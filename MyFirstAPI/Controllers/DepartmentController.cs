using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using MyFirstAPI.Services;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        [HttpGet]
        [Route("getall")]
        public Response getAllDepartment()
        {
            DepartmentService departmentService = new DepartmentService();
            return departmentService.getAllDepartment();
        }

        [HttpPost]
        [Route("insert")]
        public Response insertDepartment([FromBody]Department department)
        {
            DepartmentService departmentService = new DepartmentService();
            return departmentService.insertDepartment(department);
        }

        [HttpPut]
        [Route("update")]
        public Response updateDepartment([FromBody]Department department)
        {
            DepartmentService departmentService = new DepartmentService();
            return departmentService.updateDepartment(department);
        }

        [HttpDelete]
        [Route("delete")]
        public Response deleteDepartment([FromQuery]String departmentNo)
        {
            DepartmentService departmentService = new DepartmentService();
            return departmentService.deleteDepartment(departmentNo);
        }
    }
}
