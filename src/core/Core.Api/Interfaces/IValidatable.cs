﻿using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Interfaces
{
    public interface IValidatable
    {
        ValidationResult Validate();
    }
}
