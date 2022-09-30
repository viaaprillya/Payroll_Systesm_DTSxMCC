using API.ViewModels;
using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IPotonganRepository
    {
        List<Potongan> Get();
        Potongan Get(int id);
        int Post(InputPotongan inputPotongan);
        int Put(Potongan potongan);
        int Delete(int id);
    }
}
