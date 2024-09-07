using BrestaTest.Core.Loader;
using BrestaTest.WPF.ModelViews;

namespace BrestaTest.WPF.DataAccess
{
    internal static class CfgLoader
    {
        internal static IEnumerable<ScalesModelView> LoadScales(string scalesDir, string boardsDir)
        {
            var models = ScalesLoader.LoadScales(scalesDir, boardsDir);
            return models.Select(x => new ScalesModelView(x.Key, x.Value));
        }
    }
}
