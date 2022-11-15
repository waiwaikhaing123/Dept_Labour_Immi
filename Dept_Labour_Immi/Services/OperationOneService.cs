using Dept_Labour_Immi.Data;
//using Dept_Labour_Immi.Migrations;
using Dept_Labour_Immi.Models;

namespace Dept_Labour_Immi.Services
{
    public class OperationOneService : IOperationOneService
    {
        private readonly ApplicationDbContext _context;
        public OperationOneService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<WorkType> WorkTypeList()
        {
            try
            {
                var lst = _context.WorkType.ToList();
                return lst;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<OpearationOne> OpearationOneListwithWorkType(List<OpearationOne> model)
        {
            List<OpearationOne> oper = new List<OpearationOne>();
            try
            {
                foreach (var item in model)
                {
                    var str = _context.WorkType.Where(x => x.Id == item.WorkTypeID).Select(x => x.Name).FirstOrDefault();
                    item.worktypeName = str;
                    oper.Add(item);

                }
               // var lst = _context.WorkType.ToList();
                return oper;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public OpearationOne OpearationOneForDetaile(OpearationOne model)
        {
            OpearationOne oper = new OpearationOne();
            try
            {
                   var str = _context.WorkType.Where(x => x.Id == model.WorkTypeID).Select(x => x.Name).FirstOrDefault();
                    model.worktypeName = str;
                    oper = model;

               
                // var lst = _context.WorkType.ToList();
                return oper;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
