# golden-ratio-calculator

[![CI](https://github.com/Muhammad-1990/golden-ratio-calculator/actions/workflows/main.yml/badge.svg)](https://github.com/Muhammad-1990/golden-ratio-calculator/actions/workflows/main.yml)

[![VS Code Container](https://img.shields.io/static/v1?label=VS+Code&message=Container&logo=visualstudiocode&color=007ACC&logoColor=007ACC&labelColor=2C2C32)](https://open.vscode.dev/Muhammad-1990/golden-ratio-calculator)

DotNet Azure function that calculates the golden ratio.

## Usage

- working directory
```
cd /src
```

- Restore packages
```
dotnet restore
```

- Build project
```
dotnet build
```

- Run the function app
```
func start
```


### Debug
- Additionally debugging can be started using F5

navigate to the function link to perform the calculation:
```
http://localhost:7071/api/v1/calculate/{input}
```

The function app expects golden ratio parameter 'ab' and returns a json object specifying the calculated values sides 'a' and 'b'.

```
{
    "ab":1080.0,
    "a":667.49072929542645241038318912,
    "b":412.54062379198173820172014161}
```
