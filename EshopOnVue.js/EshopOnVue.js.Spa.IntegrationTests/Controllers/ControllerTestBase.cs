using EshopOnVueJs;

namespace EshopOnVue.js.Spa.IntegrationTests.Controllers
{
    public class ControllerTestBase
    {
        protected EshopOnVueJsClient EshopClient { get; private set; }

        public ControllerTestBase()
        {
            var httpClient = StartupTest.TestServer.CreateClient();
            EshopClient = new EshopOnVueJsClient(httpClient);
        }
    }
}
