using CrudAPI.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Interfaces.IServices
{
    public interface IPersonService : IBaseService<PersonDTO>
    {
    }
}
