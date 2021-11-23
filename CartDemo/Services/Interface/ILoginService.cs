using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Services.Interface
{
    public interface ILoginService
    {
        int GetUserId(string Account);
    }
}
