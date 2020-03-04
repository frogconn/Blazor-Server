namespace Blazor.Application.Queries {

    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Blazor.Application.Models;
    using MediatR;

    public class GetSelectionsQueryHandler : IRequestHandler<GetSelectionsQuery, SelectionsDto> {

        public async Task<SelectionsDto> Handle(GetSelectionsQuery request, CancellationToken cancellationToken) {
            await Task.Delay(500, cancellationToken);  // simulate call to repository
            return new SelectionsDto {
                Roles = new List<String> { "Actor", "Actress", "General", "President" },
                Names = new List<String> { "Abrahan Lincoln", "David James Elliott", "George Patton", "Jessica Chastain" }
            };
        }
    }
}
