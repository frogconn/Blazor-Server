using Blazor.Application.Queries;
using System;
using Xunit;

namespace Blazor.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var mediatorMock = new GetSelectionsQuery();
            var localCommandHandler = new GetSelectionsQueryHandler();

            var x = await localCommandHandler.Handle(mediatorMock, new System.Threading.CancellationToken());
            Assert.Equal(4, x.Roles.Count);

        }
    }
}
