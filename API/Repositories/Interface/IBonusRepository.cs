using API.ViewModels;
using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IBonusRepository
    {
        List<Bonus> Get();
        Bonus Get(int id);
        int Post(InputBonus inputBonus);
        int Put(Bonus bonus);
        int Delete(int id);
    }
}
