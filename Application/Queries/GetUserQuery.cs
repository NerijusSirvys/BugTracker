using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetUserQuery
    {
        public class Query : IRequest<Employee>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Employee>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Employees.FindAsync(request.Id);
            }
        }
    }
}
