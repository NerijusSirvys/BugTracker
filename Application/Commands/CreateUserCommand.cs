using Application.Requests;
using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateUserCommand
    {
        public class Command : IRequest
        {
            public CreateUserRequest User { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.User.Firstname,
                    LastName = request.User.LastName,
                };

                _context.Employees.Add(employee);   
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
