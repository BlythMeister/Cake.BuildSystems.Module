#load nuget:?package=Cake.Recipe&version=2.2.1

Environment.SetVariableNames();

var standardNotificationMessage = "Version {0} of {1} has just been released, this will be available here https://www.nuget.org/packages/{1}, once package indexing is complete.";

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "Cake.BuildSystems.Module",
  repositoryOwner: "cake-contrib",
  shouldRunDupFinder: false, // leave this out, for now.
  shouldRunDotNetCorePack: true,
  shouldUseDeterministicBuilds: true,
  gitterMessage: "@/all " + standardNotificationMessage,
  twitterMessage: standardNotificationMessage);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

ToolSettings.SetToolPreprocessorDirectives(
    reSharperTools: "#tool nuget:?package=JetBrains.ReSharper.CommandLineTools&version=2021.2.0");

Build.RunDotNetCore();
