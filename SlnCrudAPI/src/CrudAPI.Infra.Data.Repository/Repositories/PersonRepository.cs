using CrudAPI.Domain.Entity;
using CrudAPI.Domain.Interfaces.IRepositories;
using CrudAPI.Infra.Data.Repository.Context;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Infra.Data.Repository.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(SQLServerContext context) : base(context)
        {
        }
    }
}
