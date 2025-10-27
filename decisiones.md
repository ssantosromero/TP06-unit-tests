1. Configuración del Entorno 

1) self-hosted agent --> ubicado en ~/myagent con pool asignado 'Default'.  
 
2) Se creó un nuevo repositorio en Azure DevOps llamado 'TP06-unit-tests'. El proyecto se inicializó localmente y se vinculó con el repositorio remoto mediante git clone. 
 
3) Se instaló el SDK de .NET 8.0 utilizando Homebrew con el comando 'brew install --cask dotnet-sdk', verificando la instalación con 'dotnet --version'. 
 
4) Se generó el proyecto base con 'dotnet new webapi -n SimpleWebAPI' y luego el proyecto de pruebas unitarias con 'dotnet new xunit -n SimpleWebAPI.Tests'. Se agregó la referencia cruzada con 'dotnet add SimpleWebAPI.Tests/SimpleWebAPI.Tests.csproj reference SimpleWebAPI/SimpleWebAPI.csproj'. 

2. Estructura del Pipeline 

El pipeline YAML fue diseñado con un único stage denominado 'BuildAndTest'. Este stage ejecuta tres pasos principales: restauración de dependencias, compilación del proyecto y ejecución de pruebas. El archivo azure-pipelines.yml contiene los comandos 'dotnet restore', 'dotnet build --no-restore' y 'dotnet test --no-build --logger trx'. 
 
El pipeline se ejecuta sobre el pool 'Default' utilizando el self-hosted agent de la MacBook, y se activa automáticamente ante cada push a la rama main mediante la directiva 'trigger: - main'. 

3. Flujo de Trabajo y Validaciones 

1) Se creó la estructura del proyecto con los dos subproyectos (API y Tests). 
2) Se ejecutaron pruebas locales con 'dotnet test' verificando el resultado 'Passed! 2 passed, 0 failed'. 
3) Se documentó y confirmó que el pipeline en Azure DevOps ejecutara correctamente el stage BuildAndTest. 
4) Se analizaron los logs del agente local donde se observó la secuencia de comandos ejecutados, incluyendo la restauración y compilación. 
5) El pipeline completó su ejecución en estado 'Succeeded', validando que la integración con el self-hosted agent y xUnit fuera exitosa. 

4. Evidencias 

- Capturas del pipeline exitoso en Azure DevOps (estado verde). 
- Captura del resultado del comando 'dotnet test' con los tests aprobados. 
- Registro de ejecución en el agente local mostrando los jobs iniciados y finalizados correctamente. 

5. Reflexión 

La integración de pruebas unitarias dentro del pipeline de CI/CD permite automatizar la validación de código antes de su integración definitiva. Este TP reafirmó la importancia de la calidad del software desde etapas tempranas del desarrollo. Además, demostró cómo Azure DevOps puede centralizar la gestión del ciclo de vida del software, reduciendo errores humanos y garantizando entregas más confiables. 