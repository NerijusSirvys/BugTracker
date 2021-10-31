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
    public class DeleteUserCommand
    {
        public class Command : IRequest 
        {
            public Guid Id { get; set; }
        };

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.FindAsync(request.Id);

                // TODO: add error checking in case employee is null

                _context.Remove(employee);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
