﻿using API.ViewModels;
using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface ILemburRepository
    {
        List<Lembur> Get();
        Lembur Get(int id);
        int Post(InputLembur inputLembur);
        int Put(Lembur lembur);
        int Delete(int id);
    }
}
