namespace Blazor.Components.Application {

    using System;
    using System.Threading.Tasks;
    using Blazor.Application.Commands;
    using Blazor.Application.Models;
    using Blazor.Application.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Class WebApiStyleExampleBase.
    /// Derives from the <see cref="ComponentBase" />
    /// </summary>
    /// <remarks>
    /// This class demonstrates one approach to using MediatR in a Blazor application.
    /// This approach is very similar to using MediatR in a Web API app, where the two below methods would each be controller routes.
    /// Notice the 'Application' folder that contains the commands, models, and queries.
    /// </remarks>
    public class WebApiStyleExampleBase : ComponentBase {

        [Inject]
        public IMediator Mediator { get; set; }

        public WebApiStyleViewModel Model { get; private set; }

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
            this.Model = new WebApiStyleViewModel(selections.Roles, selections.Names);
        }
    }
}
