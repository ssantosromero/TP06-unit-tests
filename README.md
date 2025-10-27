
##Objetivo 

Implementar un pipeline en Azure DevOps que compile y ejecute pruebas unitarias automáticamente utilizando un self-hosted agent (MacBook) y .NET 8.0. 

###Descripción del Proyecto 

Se creó una aplicación base mínima en .NET (SimpleWebAPI) con un controlador WeatherForecastController y un proyecto de pruebas unitarias (SimpleWebAPI.Tests) usando xUnit. El pipeline YAML ejecuta la restauración, compilación y ejecución de las pruebas, generando un reporte automático. 

###Tecnologías Utilizadas 

- .NET SDK 8.0 
- xUnit (framework de testing) 
- Azure DevOps (Repos + Pipelines) 
- Self-hosted agent (MacBook) 
- YAML Pipelines 

###Estructura del Proyecto 

TP06-unit-tests/ 
├── SimpleWebAPI/ 
│   └── Controllers/ 
│       └── WeatherForecastController.cs 
├── SimpleWebAPI.Tests/ 
│   └── WeatherForecastTests.cs 
└── azure-pipelines.yml 

###Estructura del Pipeline 

Stage principal: 
1. BuildAndTest → Restaura dependencias, compila y ejecuta las pruebas unitarias. 
 
Archivo: azure-pipelines.yml 
Ejecuta los comandos: 
dotnet restore 
dotnet build --no-restore 
dotnet test --no-build --logger "trx;LogFileName=test_results.trx" 

####Ejecución 

1. Iniciar el agente local: 
   cd ~/myagent 
   ./run.sh 
2. En Azure DevOps → Pipelines → TP06-unit-tests → Run pipeline. 
3. Verificar ejecución exitosa en el agente local. 

Resultados Esperados 

En Azure DevOps: 
✅ Job BuildAndTest → Succeeded 
✅ Tests Passed (2/2) 
✅ Logs con salida 'Test Run Successful' 

Autor 

Santos Romero Reyna, Lopez Marcos 
Ingeniería de Software III - UCC 
Año: 2025 