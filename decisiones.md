Decisiones de Desarrollo - TP06 DevOps Unit Tests Integration

1. Configuración del Entorno
Ya tenía configurado mi self-hosted agent en mi MacBook (ubicado en ~/myagent)
Pool: Default
Estado: funcionando correctamente
Nombre del agente: MacBook-Pro-de-Santos

Verifiqué el estado del agente:

cd ~/myagent
./run.sh


El agente quedó escuchando jobs y conectado correctamente al servidor de Azure DevOps.

Se creó un nuevo repositorio en Azure DevOps llamado TP06-unit-tests, vinculado con el entorno local mediante git clone.

Instalé el SDK de .NET 8.0 para poder compilar y ejecutar las pruebas unitarias localmente:

brew install --cask dotnet-sdk
dotnet --version


Se generó la aplicación base y el proyecto de pruebas:

dotnet new webapi -n SimpleWebAPI
dotnet new xunit -n SimpleWebAPI.Tests
dotnet add SimpleWebAPI.Tests/SimpleWebAPI.Tests.csproj reference SimpleWebAPI/SimpleWebAPI.csproj


Se creó el archivo WeatherForecastController.cs dentro de /Controllers con una API mínima y su correspondiente test unitario WeatherForecastTests.cs utilizando el framework xUnit.

Finalmente, se verificó la ejecución local con:

dotnet test


Resultado esperado:
Passed! - 2 passed, 0 failed

2. Estructura del Pipeline

Creé un único pipeline YAML con un stage principal:

Stage 1: BuildAndTest
Ejecuta las siguientes tareas:

Restaurar dependencias

Compilar el proyecto

Ejecutar pruebas unitarias con reporte TRX

Archivo: azure-pipelines.yml
El pipeline utiliza el self-hosted agent (pool: Default) y se ejecuta automáticamente ante cada push en la rama main.

trigger:
  - main

pool:
  name: Default

stages:
  - stage: BuildAndTest
    displayName: "Build & Run Unit Tests"
    jobs:
      - job: Build
        steps:
          - checkout: self
          - script: |
              dotnet restore
              dotnet build --no-restore
              dotnet test --no-build --logger "trx;LogFileName=test_results.trx"
            displayName: "Build and Run Tests"

3. Flujo de Trabajo y Validaciones

La rama principal main contiene el archivo YAML versionado.
Se realizaron los commits y push desde la terminal para integrar los cambios con GitHub/Azure DevOps.

El pipeline se ejecutó manualmente desde Azure Pipelines → TP06-unit-tests → Run Pipeline, seleccionando la rama main.

En la terminal del agente local se visualizaron los logs:

Running job: Build
Job Build completed with result: Succeeded
Running job: BuildAndTest
Job BuildAndTest completed with result: Succeeded


En Azure DevOps se validó el resultado:

Build completado ✅

Tests unitarios ejecutados ✅

Job final con estado Succeeded ✅

Se confirmaron los resultados del test desde la línea de comando:

Passed!  - 2 passed, 0 failed
Test Run Successful.

4. Evidencias

Capturas del pipeline ejecutado exitosamente en Azure DevOps.
<img width="960" alt="image" src="https://github.com/user-attachments/assets/08b6b3b8-4a7d-4e2a-96e1-d0b318847b55" />

Logs en la terminal confirmando la ejecución correcta de los tests.
<img width="850" alt="image" src="https://github.com/user-attachments/assets/f814f51a-24e8-4f0f-b5d5-34b5431c773e" />

5. Reflexión

Este trabajo permitió integrar pruebas unitarias automatizadas dentro de un pipeline de integración continua (CI), asegurando la calidad del software antes de cada commit.
El ejercicio consolidó el uso de Azure DevOps, YAML Pipelines y agentes self-hosted, demostrando la importancia de validar el código de manera automatizada.

Aspectos aprendidos:

Configuración completa de un pipeline con etapas de build y test.

Ejecución local controlada desde el agente propio.

Integración entre .NET, xUnit y Azure Pipelines.

Flujo de trabajo continuo: build → test → validación automática.
