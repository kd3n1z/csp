using System.Diagnostics;

namespace csp;

internal static class Program {
    private static string _path = null!;
    private static string _editor = null!;

    private static void Main(string[] args) {
        if (args.Length >= 1 && (args[0] == "help" || args[0] == "h" || args[0] == "--help" || args[0] == "-h")) {
            PrintUsage();
            return;
        }

        _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "csharp-playground");

        Console.WriteLine("Project path: " + _path);

        if (args.Length >= 1 && args[0].StartsWith('r')) {
            RunProject();
            return;
        }

        _editor = Environment.GetEnvironmentVariable("EDITOR") ?? "vi";

        Console.WriteLine("Editor: " + _editor);

        if (args.Length >= 1 && args[0].StartsWith('c')) {
            Clean();
        }

        if (args.Length >= 1 && args[0].StartsWith('e')) {
            EditProject();
            return;
        }

        Create();
        EditProject();
        RunProject();
    }

    private static void PrintUsage() {
        Console.WriteLine("Usage: csp [command]");
        Console.WriteLine("Commands:");
        Console.WriteLine("    help, h, --help, -h  Display this help message.");
        Console.WriteLine("    r, run               Run the project.");
        Console.WriteLine("    c, clean             Clean the project directory before opening the editor.");
        Console.WriteLine("    e, edit              Only open the editor.");
        Console.WriteLine();
        Console.WriteLine("If no command is specified, the project will be created (if it doesn't exist), opened in the editor, and run.");
    }

    private static void Clean() {
        if (!Directory.Exists(_path)) {
            return;
        }

        Directory.Delete(_path, true);
    }

    private static void Create() {
        if (Directory.Exists(_path)) {
            return;
        }

        Console.WriteLine("Running dotnet new console...");
        Directory.CreateDirectory(_path);
        RunDotnet(["new", "console"]);
    }

    private static void RunDotnet(IEnumerable<string> arguments) {
        Process process = new();

        process.StartInfo.FileName = "dotnet";

        foreach (string argument in arguments) {
            process.StartInfo.ArgumentList.Add(argument);
        }

        process.StartInfo.WorkingDirectory = _path;

        process.StartInfo.UseShellExecute = true;
        process.Start();
        process.WaitForExit();
    }

    private static void RunProject() {
        Console.WriteLine("-- Running --");
        RunDotnet(["run"]);
    }

    private static void EditProject() {
        Process process = new();

        process.StartInfo.FileName = _editor;
        process.StartInfo.WorkingDirectory = _path;
        process.StartInfo.Arguments = "Program.cs";
        process.StartInfo.UseShellExecute = true;
        process.Start();

        process.WaitForExit();
    }
}