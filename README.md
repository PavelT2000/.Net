# 1Task - .NET Console Application

This project is a simple C# console application designed to perform basic arithmetic calculations based on user input. It is built using the .NET Framework 4.7.2.

## Description

The application reads a line of space-separated values from the console and calculates a result based on specific logic. It is structured as a standard C# console project, ideal for learning basic input/output operations and conditional logic in the .NET environment.

### Logic Overview:
The program expects an input string containing multiple values. It parses specific indices to perform a calculation:
- **A**: Initial value.
- **B**: Starting threshold.
- **C**: Multiplier.
- **D**: Target threshold.
- **Calculation**: If `B < D`, the program adds `(D - B) * C` to the initial value `A`.

## Installation

1. **Prerequisites**: Ensure you have [Visual Studio](https://visualstudio.microsoft.com/) installed with the ".NET desktop development" workload.
2. **Clone the repository**:
   ```bash
   git clone <repository-url>
   ```
3. **Open the Project**:
   - Navigate to the `1Task` folder.
   - Open the `1Task.sln` file in Visual Studio.
4. **Build**:
   - Press `Ctrl + Shift + B` or go to **Build > Build Solution** to compile the project.

## Usage

1. Run the application via Visual Studio (press `F5`) or execute the compiled `1Task.exe` located in the `bin/Debug` directory.
2. When prompted, enter the input values separated by spaces.
   - *Example input format*: `10 2 5 4`
   - *Explanation*: 
     - A=10, B=2, C=5, D=4.
     - Since 2 < 4, the calculation is: `10 + (4 - 2) * 5 = 20`.
3. The program will output the final result to the console.

## Project Structure

* `1Task/`: Contains the source code and project files.
* `Program.cs`: The main entry point containing the application logic.
* `1Task.sln`: The Visual Studio Solution file.

## License

This project is for educational purposes. Feel free to use and modify the code as needed.