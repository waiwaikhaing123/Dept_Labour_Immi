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
                    if (item.WorkTypeID > 0)
                    {
                        var str = _context.WorkType.Where(x => x.Id == item.WorkTypeID).Select(x => x.Name).FirstOrDefault();
                        item.worktypeName = str;
                    }

                    if (item.ThaiCompanyID > 0)
                    {
                        var Thaistr = _context.thaiCompanies.Where(x => x.ID == item.ThaiCompanyID).Select(x => x.CompanyName).FirstOrDefault();
                        item.ThaiCompanyName = Thaistr;
                    }

                    if (item.AgencyID > 0)
                    {
                        var AgencyStr = _context.agencies.Where(x => x.Id == item.AgencyID).Select(x => x.AgencyName).FirstOrDefault();
                        item.angencyName = AgencyStr;
                    }

                    if (item.DOEID > 0)
                    {
                        var DOEStr = _context.DOEs.Where(x => x.ID == item.DOEID).Select(x => x.DOENo).FirstOrDefault();
                        item.DOEName = DOEStr;
                    }

                    oper.Add(item);
                }
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
                if (model.WorkTypeID > 0)
                {
                    var str = _context.WorkType.Where(x => x.Id == model.WorkTypeID).Select(x => x.Name).FirstOrDefault();
                    model.worktypeName = str;
                }

                if (model.ThaiCompanyID > 0)
                {
                    var thaistr = _context.thaiCompanies.Where(x => x.ID == model.ThaiCompanyID).Select(x => x.CompanyName).FirstOrDefault();
                    model.ThaiCompanyName = thaistr;
                }

                if (model.AgencyID > 0)
                {
                    var AgencyStr = _context.agencies.Where(x => x.Id == model.AgencyID).Select(x => x.AgencyName).FirstOrDefault();
                    model.angencyName = AgencyStr;
                }

                if (model.DOEID > 0)
                {
                    var DOEStr = _context.DOEs.Where(x => x.ID == model.DOEID).Select(x => x.DOENo).FirstOrDefault();
                    model.DOEName = DOEStr;
                }

                oper = model;
                return oper;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<ThaiCompany> ThaiCompanyList()
        {
            try
            {
                var lst = _context.thaiCompanies.ToList();
                return lst;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<Agency> AgencyList()
        {
            try
            {
                var lst = _context.agencies.ToList();
                return lst;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<DOE> DOEList()
        {
            try
            {
                var lst = _context.DOEs.ToList();
                return lst;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public Blacklist IsBlackListAgencyANDCompany(CheckBlackListForOperOne model)
        {
            Blacklist bl = new Blacklist();
            OpearationOne oper = new OpearationOne();
            if (model.id > 0 && model.Type == "Agency")
            {
                var result = _context.blacklists.Where(x => x.AgencyID == model.id && x.IsActive == true).FirstOrDefault();
                return result;
            }
            if (model.id > 0 && model.Type == "ThaiCompany")
            {
                var result = _context.blacklists.Where(x => x.ThaiCompanyID == model.id && x.IsActive == true).FirstOrDefault();
                return result;
            }
            return null;
        }
    }
}
