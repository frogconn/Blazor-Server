namespace Blazor.Application.Models {

    using System;
    using System.Collections.Generic;

    public class WebApiStyleViewModel {

        public IList<string> Names { get; }

        public IList<string> Roles { get; }

        public String SelectedName { get; set; }

        public String SelectedRole { get; set; }

        public WebApiStyleViewModel(IList<String> roles, IList<String> names) {
            this.Roles = roles;
            this.Names = names;
        }
    }
}
