﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Common.Build.TFBuild;
using Cake.Common.Build.TFBuild.Data;

namespace Cake.TFBuild.Module
{
    public static class Extensions
    {
        public static void UpdateProgress(this ITFBuildProvider provider, Guid parent, int progress)
        {
            provider.Commands.UpdateRecord(parent, new TFBuildRecordData {Progress = progress, Status = TFBuildTaskStatus.InProgress});
        }

        internal static bool IsRunningOnPipelines(this Common.Build.BuildSystem b) => b.IsRunningOnAzurePipelines || b.IsRunningOnAzurePipelinesHosted;
    }
}
