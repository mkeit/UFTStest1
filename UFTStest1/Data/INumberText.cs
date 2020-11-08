using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UFTStest1.Models;

namespace UFTStest1.Data
{
    /// <summary>
    /// Define the contract via interface for decoupling code
    /// </summary>
    public interface INumberText
    {
        NumberText GetTextFromANumber(string aNumber);
    }
}
