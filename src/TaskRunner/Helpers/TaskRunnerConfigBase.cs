using System;
using Microsoft.VisualStudio.TaskRunnerExplorer;
using MonoDevelop.Core;

namespace NpmTaskRunner.Helpers
{
    public abstract class TaskRunnerConfigBase : ITaskRunnerConfig
    {
        private ITaskRunnerCommandContext _context;

        protected TaskRunnerConfigBase(ITaskRunnerCommandContext context, ITaskRunnerNode hierarchy)
        {
            TaskHierarchy = hierarchy;
            _context = context;
        }

        /// <summary>
        /// TaskRunner icon
        /// </summary>
        public IconId Icon { get; protected set; }

        public ITaskRunnerNode TaskHierarchy { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string LoadBindings(string configPath)
        {
            try
            {
                return BindingsPersister.Load(configPath);
            }
            catch
            {
                return "<binding />";
            }
        }

        public bool SaveBindings(string configPath, string bindingsXml)
        {
            try
            {
                return BindingsPersister.Save(configPath, bindingsXml);
            }
            catch
            {
                return false;
            }
        }

        protected virtual void Dispose(bool isDisposing)
        {
        }
    }
}
