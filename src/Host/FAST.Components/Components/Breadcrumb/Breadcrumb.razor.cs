namespace DigitalLibrary.WebUi.FAST.Components.Components.Breadcrumb
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components;

    public partial class Breadcrumb
    {
        private Stack<Crumb> _crumbs;

        [Parameter]
        public Stack<Crumb> InitialCrumbs { get; set; }
    }
}
