using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCETNChapter.Startup))]
namespace GCETNChapter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
