using EshopOnVueJs;

namespace EshopOnVue.js.Spa.IntegrationTests.Controllers
{
    public class EndpointTestBase
    {
        protected EshopOnVueJsClient EshopClient { get; private set; }

        public EndpointTestBase()
        {          
            EshopClient = new EshopOnVueJsClient(ProgramTest.Client);
        }
    }
}
