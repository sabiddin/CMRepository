using CM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Interfaces
{
    public interface IRepresentativeService
    {
        Representative GetRepresentativeByID(int id);
        Representative GetRepresentativeByLastName(string LastName);
        void AddRepresentative(Representative user);
        void UpdateRepresentative(Representative user);
        void DeleteRepresentativeByID(int id);
    }
}
