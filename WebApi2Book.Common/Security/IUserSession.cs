﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2Book.Common.Security
{
    public interface IUserSession
    {
        string Firstname { get; } 
        string Lastname { get; } 
        string Username { get; } 
        bool IsInRole( string roleName);

 
    }
}
