using System;
using Microsoft.VisualStudio.TaskRunnerExplorer;
using MonoDevelop.Core;

namespace NpmTaskRunner.Helpers
{
    public class TaskRunnerOption : ITaskRunnerOption
    {
        public TaskRunnerOption(string optionName, uint commandId, Guid commandGroup, bool isEnabled, string command)
        {
            Command = command;
            Id = commandId;
            Guid = commandGroup;
            Name = optionName;
            Enabled = isEnabled;
            Checked = isEnabled;
            Description = Name;
        }

        public string Command { get; set; }

        public bool Enabled { get; set; }

        public bool Checked { get; set; }

        public Guid Guid { get; }

        public uint Id { get; }

        public string Name { get; }

        public IconId Icon { get; }

        public string Description { get; }
    }
}
