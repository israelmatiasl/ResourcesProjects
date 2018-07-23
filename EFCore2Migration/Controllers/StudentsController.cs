using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore2Migration.Data;
using EFCore2Migration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCore2Migration.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        [Route("students")]
        public async Task<IActionResult> Get()
        {
            var response = default(IActionResult);
            var context = default(DataContext);

            try
            {
                context = new DataContext();
                var students = await context.Students.Include(x=>x.Region).ToListAsync();
                response = Ok(students);
            }
            catch
            {
                response = StatusCode(500);
            }
            finally
            {
                if (context != default(DataContext)) context.Dispose();
            }

            return response;
        }

        [HttpGet]
        [Route("students/{id}")]
        public async Task<IActionResult> GetById(Int32 id)
        {
            var response = default(IActionResult);
            var context = default(DataContext);

            try
            {
                context = new DataContext();
                var student = await context.Students.FindAsync(id);
                response = Ok(student);
            }
            catch
            {
                response = StatusCode(500);
            }
            finally
            {
                if (context != default(DataContext)) context.Dispose();
            }

            return response;
        }

        [HttpPost]
        [Route("students")]
        public async Task<IActionResult> Post([FromBody] StudentRequest model)
        {
            var response = default(IActionResult);
            var context = default(DataContext);
            var transaction = default(IDbContextTransaction);

            try
            {
                context = new DataContext();
                transaction = await context.Database.BeginTransactionAsync();

                Student student = new Student();
                student.name = model.name;
                student.age = model.age;
                student.email = model.email;
                student.password = model.password;

                Region region = new Region();
                region.name = model.region;

                student.Region = region;

                context.Students.Add(student);
                await context.SaveChangesAsync();
                transaction.Commit();

                response = new CreatedAtActionResult("GetById", "Students", new { student.id }, student);
            }
            catch(Exception e)
            {
                response = StatusCode(500);
                if (transaction != default(IDbContextTransaction)) transaction.Rollback();
            }
            finally
            {
                if (transaction != default(IDbContextTransaction)) transaction.Dispose();
                if (context != default(DataContext)) context.Dispose();
            }

            return response;
        }

        [HttpDelete]
        [Route("students/{id}")]
        public async Task<IActionResult> Delete(Int32 id)
        {
            var response = default(IActionResult);
            var context = default(DataContext);

            try
            {
                context = new DataContext();
                Student student = await context.Students.FindAsync(id);

                if (student is null)
                {
                    response = NotFound();
                }
                else
                {
                    context.Students.Remove(student);
                    await context.SaveChangesAsync();

                    response = Ok();
                }
            }
            catch
            {
                response = StatusCode(500);
            }
            finally
            {
                if (context != default(DataContext)) context.Dispose();
            }

            return response;
        }

        [HttpGet]
        [Route("regions")]
        public async Task<IActionResult> Test()
        {
            var response = default(IActionResult);
            var context = default(DataContext);

            try
            {
                context = new DataContext();
                Region region = new Region();
                region.name = "Huancayo";
                region.studentId = 4;

                context.Regions.Add(region);
                await context.SaveChangesAsync();
                response = Ok();
            }
            catch
            {
                response = StatusCode(500);
            }
            finally
            {
                if (context != default(DataContext)) context.Dispose();
            }

            return response;
        }
    }
}