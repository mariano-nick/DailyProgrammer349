using System.Collections.Generic;

namespace DailyProgrammer349
{
    public interface IInputHandler
    {
        List<int> GetBoxList();
        int GetStackSize();
    }
}
