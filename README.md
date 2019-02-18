# AgentApi Installation

To install the api on a windows machine using IIS, first install the .net core 2.2 runtime (https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-2.2.2-windows-hosting-bundle-installer)

Right click on AgentApi and Publish output files needed to run the application to desired IIS website location (ex: c:\agentApi\)
  *the solution was created using Visual Studio 2019

Browse to Swagger endpoint (ex: http://localhost/api-docs/) to begin using the api!

# Assumptions

the application will move away from a file based approach to a db at some point prior to production

some performance tweaks, like caching, and refactoring are down the pipe

api functionality will expand

will run on windows, for now

will use JSON for data

# Specification questions

Who are the consumers of the api?  If third party, we will need user stories for security/authentication/authorization

How many users are expected for this application?

What are the performance expectations?

Will we containerize the application at some point?

