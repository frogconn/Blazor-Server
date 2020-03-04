namespace Blazor.Application.Queries {

    using Blazor.Application.Models;
    using MediatR;

    public class GetSelectionsQuery : IRequest<SelectionsDto> {
    }
}
