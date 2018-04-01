using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Contracts
{
    /// <summary>
    /// Represents what will be shown in the UI
    /// </summary>
    public class CompanyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}