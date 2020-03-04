namespace Blazor.Application.Commands {

    using System;
    using MediatR;

    public class VerifyAnswerCommand : IRequest<Boolean> {

        public String Name { get; set; } = String.Empty;

        public String Role { get; set; } = String.Empty;

        public VerifyAnswerCommand() {
        }
    }
}
