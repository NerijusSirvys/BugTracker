using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllUsersQuery
    {
        public class Query : IRequest<IEnumerable<Employee>> { };

        public class Handler : IRequestHandler<Query, IEnumerable<Employee>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Employee>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Employees.ToListAsync();
            }
        }
    }
}
