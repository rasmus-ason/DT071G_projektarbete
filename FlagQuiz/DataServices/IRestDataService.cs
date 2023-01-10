using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagQuiz.Models;

namespace FlagQuiz.DataServices
{
    //Get all info from list
    public interface IRestDataService
    {
        Task<List<Flags>> GetAllFlagsAsync();
    }
}
