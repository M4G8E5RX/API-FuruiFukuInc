# API-FuruiFukuInc

# Crear tablas de BD
Ejecutar queries que se encuentran en el archivo BD.sql del proyecto

# Implementar API en servidor IIS
Los archivos compilados(todo lo que este dentro de bin/release/net8.0/publish) deben ponerse en la ruta del disco local C inetpub/wwwroot/(crear carpeta para la api)

Abra el Administrador de servicios de información de Internet (IIS).
En el panel izquierdo, haga clic con el botón derecho en el nodo "Sitios web" y seleccione "Agregar sitio web".
En el asistente para agregar un nuevo sitio web, ingrese el nombre "API-FuruiFukuInc" y haga clic en "Siguiente".
Seleccione la opción "Ruta local" y haga clic en "Examinar".
Seleccione la carpeta que contiene el código de la API y haga clic en "Aceptar".
Haga clic en "Siguiente" y luego en "Finalizar".

Configure la unión SSL.
En el panel izquierdo, expanda el nodo "Sitios web", haga clic con el botón derecho en el sitio web que creó en el paso 1 y seleccione "Enlazar un certificado SSL".
En el asistente para enlace de certificados SSL, seleccione el certificado SSL que desea usar y haga clic en "Aceptar".

Abra un navegador web e ingrese la siguiente URL, reemplazando "your-server-name" con el nombre de su servidor:
https://your-server-name/API-FuruiFukuInc/
