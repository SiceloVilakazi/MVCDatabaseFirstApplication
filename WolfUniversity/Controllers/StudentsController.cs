using Microsoft.AspNetCore.Mvc;
using WolfUniversity.Commands;
using WolfUniversity.Domain;
using WolfUniversity.Queries;

namespace WolfUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: studentsController
        public async Task<IActionResult> Index()
        {
            var query = new GetStudentsQuery();
            var result = await _mediator.Send(query);
            return View(result);
        }

        // GET: studentsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var query = new GetStudentByIdQuery(id);
            var result = await _mediator.Send(query);
            return View(result);
        }

        // GET: studentsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: studentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("studentId,studentCode,Name,Nqflevel,Description,studentDuration,IsActive,LastModifiedBy,LastModifiedDate")] Student student)
        {
            var query = new AddStudentCommand(student);
            if (ModelState.IsValid)
            {
                await _mediator.Send(query);
                return RedirectToAction(nameof(Index));
            }
            return View(student);

        }

        // GET: studentsController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var query = new GetStudentByIdQuery((int)id);
            var student = _mediator.Send(query);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: studentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("studentId,studentCode,Name,Nqflevel,Description,studentDuration,IsActive,LastModifiedBy,LastModifiedDate")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var query = new EditStudentCommand(student);
                    await _mediator.Send(query);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    //TODO write an exception
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: studentsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) { return NotFound(); }

            var query = new GetStudentByIdQuery((int)id);
            var student = await _mediator.Send(query);

            if (student == null) { return NotFound(); }

            return View(student);
        }


        // POST: studentsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var getQuery = new GetStudentByIdQuery(id);
            var student = await _mediator.Send(getQuery);

            var DeleteCommand = new RemoveStudentCommand();
            await _mediator.Send(DeleteCommand);

            return RedirectToAction(nameof(Index));
        }
    }
}
