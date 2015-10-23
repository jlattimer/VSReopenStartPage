using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace VSReopenStartPage
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideAutoLoad("f1536ef8-92ec-443c-9ed7-fdadf150da82")]
    [Guid(GuidList.GuidVsReopenPkgString)]
    public sealed class ReopenPackage : Package
    {
        protected override void Initialize()
        {
            base.Initialize();

            DTE dte = GetGlobalService(typeof(DTE)) as DTE;
            if (dte == null)
                return;

            uint solutionEventsCookie;
            IVsSolutionEvents vsSolutionEvents = new VsSolutionEvents();
            IVsSolution vsSolution = (IVsSolution)ServiceProvider.GlobalProvider.GetService(typeof(SVsSolution));
            vsSolution.AdviseSolutionEvents(vsSolutionEvents, out solutionEventsCookie);
        }
    }
}
