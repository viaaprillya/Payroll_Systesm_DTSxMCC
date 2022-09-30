using API.ViewModels;
using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface ICutiRepository
    {
        List<Cuti> Get();
        Cuti Get(int id);
        int Post(InputCuti inputCuti);
        int Put(Cuti cuti);
        int Delete(int id);
    }
}
