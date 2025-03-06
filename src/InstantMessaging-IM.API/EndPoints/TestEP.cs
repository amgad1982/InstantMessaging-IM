using FastEndpoints;
using InstantMessaging_IM.Application.Features;

namespace InstantMessaging_IM.API.EndPoints
{
    public class TestEP : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var response=await new Test().TestMethod();
            await SendAsync(response, 200, cancellationToken);
        }
    }
}
