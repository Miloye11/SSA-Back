﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public  interface ILogedUser
    {
        List<LogedUser> GetLogedUser();
        int InsertUser(Owner o);
        int TrancadeLogedUser(); 

    }
}
