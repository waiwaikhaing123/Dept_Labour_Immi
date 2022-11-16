using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Migrations;
using Dept_Labour_Immi.Models;
using Dept_Labour_Immi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using static Humanizer.On;

namespace Dept_Labour_Immi.Controllers
{
    public class OpearationOneController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOperationOneService _operSer;
        public OpearationOneController(ApplicationDbContext context, IOperationOneService op)
        {
            _context = context;
            _operSer = op;
        }

        // GET: OpearationOne
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.opearationOne.OrderByDescending(x => x.ID).ToList();
            var ite = _operSer.OpearationOneListwithWorkType(applicationDbContext);
;            return View(ite);
        }

        // GET: OpearationOne/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //OperationOne model = new OperationOne();
            if (id == null || _context.opearationOne == null)
            {
                return NotFound();
            }

            var oper = await _context.opearationOne
                .FirstOrDefaultAsync(m => m.ID == id);
            if(oper is not null)
            {
                var model = _operSer.OpearationOneForDetaile(oper);
                return View(model);
            }
            else
            {
                return NotFound();
            }
            return View();
        }
       
        // GET: OpearationOne/Create
        public IActionResult Create()
        {
            OpearationOne oper = new OpearationOne();
            oper.WorkTypeList = _operSer.WorkTypeList();
            oper.ThaiCompanyList = _operSer.ThaiCompanyList();
            oper.AgencyList = _operSer.AgencyList();
            oper.DOEList = _operSer.DOEList();
            oper.ApplyDate = DateTime.Now;
            oper.DocumentCompleteDate = DateTime.Now;
            return View(oper);
        }

        // POST: OpearationOne/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ApplyDate,DocumentCompleteDate,AgencyID,ThaiCompanyID,DOEID,WorkTypeID,NoOfMaleWorker,NoOfFemaleWorker,TotalNoOfWorker,Remark")] OpearationOne opearationOne)
        {
            //  if (ModelState.IsValid)
           // {
                _context.Add(opearationOne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
          // return View(opearationOne);
        }

        // GET: OpearationOne/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.opearationOne == null)
            {
                return NotFound();
            }
           
            var operation = await _context.opearationOne.FindAsync(id);
            operation.WorkTypeList = _operSer.WorkTypeList();
            operation.ThaiCompanyList = _operSer.ThaiCompanyList();
            operation.AgencyList = _operSer.AgencyList();
            operation.DOEList = _operSer.DOEList();
            if (operation == null)
            {
                return NotFound();
            }
            return View(operation);
        }

        // POST: OpearationOne/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ApplyDate,DocumentCompleteDate,AgencyID,ThaiCompanyID,DOEID,WorkTypeID,NoOfMaleWorker,NoOfFemaleWorker,TotalNoOfWorker,Remark")] OpearationOne oper)
        {
            if (id != oper.ID)
            {
                return NotFound();
            }
            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(oper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperationOneExists(oper.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
           // }
           // return View(oper);
        }

        // GET: OpearationOne/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.opearationOne == null)
            {
                return NotFound();
            }

            var operOne = await _context.opearationOne
                .FirstOrDefaultAsync(m => m.ID == id);

            if (operOne is not null)
            {
                var model = _operSer.OpearationOneForDetaile(operOne);
                return View(model);
            }
            else
            {
                return NotFound();
            }
            return View();
        }

        // POST: OpearationOne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.opearationOne == null)
            {
                return Problem("Entity set 'ApplicationDbContext.opearationOne'  is null.");
            }
            var operOne = await _context.opearationOne.FindAsync(id);
            if (operOne != null)
            {
                _context.opearationOne.Remove(operOne);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperationOneExists(int id)
        {
            return _context.opearationOne.Any(e => e.ID == id);
        }

        [HttpPost]
        public async Task<JsonResult> GetBlackListAgencyANDCompany(CheckBlackListForOperOne reqModel)
        {
            string str = "";
            if (reqModel.Type == "Agency")
            {
                Blacklist model = _operSer.IsBlackListAgencyANDCompany(reqModel);
                if (model is not null)
                {
                    str = "Pls choose another Agency.It was blacklisted.";
                    return Json(str);
                }
            }
            if (reqModel.Type == "ThaiCompany")
            {
                Blacklist model = _operSer.IsBlackListAgencyANDCompany(reqModel);
                if (model is not null)
                {
                    str = "Pls choose another Thai Company.It was blacklisted.";
                    return Json(str);
                }
            }
            if (reqModel.Type == "DOENo")
            {
                OpearationOne model = _context.opearationOne.Where(x => x.DOEID == reqModel.id).FirstOrDefault();
                if (model is not null)
                {
                    str = "Pls choose another DOE No.It is already existed.";
                    return Json(str);
                }
            }
            return Json(str);
        }
    }
}
