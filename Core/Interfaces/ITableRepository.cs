using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postal_Management_System.Core.Interfaces
{
    public interface ITableRepository
    {
        Task<DataTable> GetDataTable(string tableName);
    }
}