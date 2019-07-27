# Rodocop

Rodocop es un proyecto que engloba experimentos utilizando Core como framework base y devops de azure para publicarse facilmente en la nube.

### Como correr a rodocop

1. Instalar .Net Core: 
> sudo apt-get install apt-transport-https
> sudo apt-get update
> sudo apt-get install dotnet-sdk-2.2

2. Instalar .Net Code:
Se puede descargar desde:
> https://code.visualstudio.com/download
O directo del repo:
> sudo apt-get install code

4. Clonar localmente el proyecto git
> git clone rodocop.git

3. Run:
> cd rodocop
> dotnet run

### Como publicar a rodocop
Debe realizarse un pull request (y luego ser aceptado) para que el robot compile el nuevo codigo generado en azure