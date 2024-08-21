# C# Playground

C# Playground (`csp`) is a simple command-line utility to quickly set up, edit, and run C# console projects. This tool automates the process of creating a new C# project, opening it in your preferred text editor, and running it using the .NET CLI.

## Installation

1. Download archive for your platform from [/releases](https://github.com/kd3n1z/csp/releases)
2. Unzip it
3. Move `csp` to your bin directory:<br>
    - typically <code>/usr/local/bin</code> on macOS/Linux<br>
    - typically <code>C:\Windows</code> on Windows

## Usage

After installation, you can use `csp` via the command line. The utility supports the following commands:

-   **Default behavior**: If no command is specified, `csp` will create a new C# console project (if it doesn't already exist), open it in your editor, and then run the project.

    ```bash
    csp
    ```

-   **Run the project**: If the project exists, it will be executed.

    ```bash
    csp run
    ```

    or simply

    ```bash
    csp r
    ```

-   **Edit the project**: Opens the project in your editor.

    ```bash
    csp edit
    ```

    or simply

    ```bash
    csp e
    ```

-   **Clean the project**: Deletes the existing project directory before opening the editor.

    ```bash
    csp clean
    ```

    or simply

    ```bash
    csp c
    ```

-   **Help**: Displays the usage instructions.
    ```bash
    csp help
    ```
    or simply
    ```bash
    csp h
    ```

### Environment Variables

-   **EDITOR**: The `csp` utility uses the **EDITOR** environment variable to determine which text editor to use. Defaults to `vi`.

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for details.

Made with ❤️ and C#.
