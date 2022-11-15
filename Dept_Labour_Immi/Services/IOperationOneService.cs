using Dept_Labour_Immi.Models;

namespace Dept_Labour_Immi.Services
{
    public interface IOperationOneService
    {
       List<WorkType> WorkTypeList();
        List<OpearationOne> OpearationOneListwithWorkType(List<OpearationOne> model);
        OpearationOne OpearationOneForDetaile(OpearationOne model);
    }
}
