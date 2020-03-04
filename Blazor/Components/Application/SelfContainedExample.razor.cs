namespace Blazor.Components.Application {

    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Class SelfContainedExampleBase.
    /// Derives from the <see cref="ComponentBase" />
    /// </summary>
    /// <remarks>
    /// This class demonstrates one approach to using MediatR in a Blazor application.
    /// All the code(except the fictitious repository and possibly domain objects) is contained in this one file.
    /// Nested classes are used to hold the queries, commands, and model objects that 'could' be placed in separate files.
    /// One advantage of structuring the application this way, is all the code required for this feature is here.
    /// If this feature requires a modification, the chance of merge conflicts is near zero when the developer checks in.
    /// This code was presented by Jimmy Bogard at NDC 2018. In the presentation he was showing something similar in a MVC Razor page.
    /// Since Blazor pages are so similar to Razor pages, it made sense to try this.
    /// Dependency Injection handles all the magic of associating the query or command with it's handler.  Send Mediator it's request, and it's handled for you.
    /// </remarks>
    public class SelfContainedExampleBase : ComponentBase {

        [Inject]
        public IMediator Mediator { get; set; }

        public ViewModel Model { get; private set; }

        public String Result { get; set; }

        public async Task VerifySelections() {
            var result = await this.Mediator.Send(new VerifyAnswerCommand { Name = this.Model.SelectedName, Role = this.Model.SelectedRole });
            if (result) {
                this.Result = $"Outstanding, {this.Model.SelectedName}'s role is {this.Model.SelectedRole}";
            } else {
                this.Result = "Sorry give it another try.";
            }
        }

        protected override async Task OnInitializedAsync() {
            var selections = await this.Mediator.Send(new GetSelectionsQuery());
            this.Model = new ViewModel(selections.Roles, selections.Names);
        }

        public class GetSelectionsQuery : IRequest<SelectionsDto> {

            public GetSelectionsQuery() {
            }
        }

        public class GetSelectionsQueryHandler : IRequestHandler<GetSelectionsQuery, SelectionsDto> {

            public GetSelectionsQueryHandler() {
            }

            public async Task<SelectionsDto> Handle(GetSelectionsQuery request, CancellationToken cancellationToken) {
                await Task.Delay(500, cancellationToken);  // simulate call to repository
                return new SelectionsDto {
                    Roles = new List<String> { "Actor", "Actress", "General", "President" },
                    Names = new List<String> { "Abrahan Lincoln", "David James Elliott", "George Patton", "Jessica Chastain" }
                };
            }
        }

        public class SelectionsDto {

            public IList<String> Names { get; set; }

            public IList<String> Roles { get; set; }

            public SelectionsDto() {
            }
        }

        public class VerifyAnswerCommand : IRequest<Boolean> {

            public String Name { get; set; } = String.Empty;

            public String Role { get; set; } = String.Empty;

            public VerifyAnswerCommand() {
            }
        }

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

        public class ViewModel {

            public IList<String> Names { get; }

            public IList<String> Roles { get; }

            public String SelectedName { get; set; }

            public String SelectedRole { get; set; }

            public ViewModel(IList<String> roles, IList<String> names) {
                this.Roles = roles;
                this.Names = names;
            }
        }
    }
}
