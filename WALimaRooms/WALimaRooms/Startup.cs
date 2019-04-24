using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WALimaRooms.Startup))]
namespace WALimaRooms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
