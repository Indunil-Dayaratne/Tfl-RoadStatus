Instructions Updated

To build the coding challenge application 
-----------------------------------------
	- Open the “Tfl.RoadStatus.sln” file via Visual Studio.
	- Restore missing Nuget packages.
	- Build the entire solution to create the relevant binaries.
	- Note: The current target framework has been specified as “.NET Framework 4.7.2” for all projects.

To run the application
-----------------------
	- After doing a debug build of the solution, browse to the “.\Tfl.RoadStatusApp\bin\Debug” folder.
	- Open the “.\Tfl.RoadStatusApp\bin\Debug\Tfl.RoadStatusApp.exe.config” file and update the following app settings.
		<add key=”AppId” value=”c3aaffd1”/>
		<add key=”AppKey” value=”972a6acfeb3599644fc366e79010189e”/>
	- Run the “.\Tfl.RoadStatusApp\bin\Debug\Tfl.RoadStatusApp.exe” application via the command line executable as follows:
		Tfl.RoadStatusApp.exe <Road Id> - e.g Tfl.RoadStatusApp.exe a12

Running tests
--------------
	- I’ve followed a TDD approach when writing tests for this application with NUnit being used as the testing framework.
	- Whilst both unit and integration tests are contained within the “.\Tfl.RoadStatus.Core.Tests\Tfl.RoadStatus.Core.Tests.csproj” project, the main test cases described in the coding challenge have been covered by the “Tfl.RoadStatus.Core.Tests\IntegrationTests\RoadStatusConsoleClientTests” test fixture.
	- Before running tests update the “AppId” and “AppKey” app settings within the “.\Tfl.RoadStatus.Core.Tests\App.config” file.
	- Build the “Tfl.RoadStatus.Core.Tests.csproj” project and run all the test fixtures within this project via the ReSharper’s test runner or via any other NUnit test runner (e.g: http://nunit.org/docs/2.4/nunit-gui.html).

Assumptions
-----------
	- I’ve assumed that the response returned from the query API for a valid road Id will conform to this convention – ‘[{JSON}]’

Further modifications
---------------------
	- This application can be further improved by introducing info and error logging via the use of Log4Net and also by introducing more fine grained exception handling logic.

