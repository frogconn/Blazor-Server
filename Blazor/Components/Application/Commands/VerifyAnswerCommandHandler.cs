namespace Blazor.Application.Commands {

    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class VerifyAnswerCommandHandler : IRequestHandler<VerifyAnswerCommand, Boolean> {

        public VerifyAnswerCommandHandler() {
        }

        public async Task<Boolean> Handle(VerifyAnswerCommand request, CancellationToken cancellationToken) {
            await Task.Delay(500, cancellationToken); // simulate calling a repository or business object, etc.
            switch (request.Role) {
                case "Actor":
                    if (request.Name == "David James Elliott") {
                        return true;
                    }
                    break;

                case "Actress":
                    if (request.Name == "Jessica Chastain") {
                        return true;
                    }
                    break;

                case "General":
                    if (request.Name == "George Patton") {
                        return true;
                    }
                    break;

                case "President":
                    if (request.Name == "Abrahan Lincoln") {
                        return true;
                    }
                    break;

                default:
                    break;
            }
            return false;
        }
    }
}
