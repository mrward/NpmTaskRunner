using Microsoft.VisualStudio.TaskRunnerExplorer;
using MonoDevelop.Core;

namespace NpmTaskRunner.Helpers
{
    public class TaskRunnerConfig : TaskRunnerConfigBase
    {
         public TaskRunnerConfig(ITaskRunnerCommandContext context, ITaskRunnerNode hierarchy)
            : base(context, hierarchy)
        {
        }

        public TaskRunnerConfig(ITaskRunnerCommandContext context, ITaskRunnerNode hierarchy, IconId rootNodeIcon)
            : this(context, hierarchy)
        {
            Icon = rootNodeIcon;
        }
    }
}
