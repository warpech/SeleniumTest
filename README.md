# SeleniumTest
Shows Selenium problem in IE11 - Selenium cannot find any element on a page if `webcomponentsjs` polyfill is loaded.

Reported in:

- https://github.com/webcomponents/webcomponentsjs/issues/504
- https://github.com/SeleniumHQ/selenium/issues/1765

## Prepare your environment

Before running the steps, you need to:

- Download and install Visual Studio 2015 to run the tests
- Download and install Java, required by Selenium Standalone Server
- Download Selenium Standalone Server from http://docs.seleniumhq.org/download/
	- It controls browsers to perform the tests. 
	- It is just a single file (`selenium-server-standalone-2.52.0.jar`). 
	- Put this file to `C:\selenium`.
- Download Internet Explorer Driver Server from http://docs.seleniumhq.org/download/
	- This is just a single file (`IEDriverServer.exe`).
	- Put this file to `C:\selenium\drivers`.
- Download Microsoft Edge Driver from http://docs.seleniumhq.org/download/
	- This is just a single file (`MicrosoftWebDriver.exe`).
	- Put this file to `C:\selenium\drivers`.
- Download Google Chrome Driver from http://docs.seleniumhq.org/download/
  - This is just a single file (`chromedriver.exe`).
  - Put this file to `C:\selenium\drivers`.
- **Add `C:\selenium\drivers` to %PATH%. You may need to restart your Command Prompt (cmd) after this**
- Firefox drivers are built-in to Selenium Standalone Server; no need to download these

## Run the test

1. Start Selenium Remote Driver: `java -jar selenium-server-standalone-2.52.0.jar`
2. Open `SeleniumTest.sln` in Visual Studio and enable Test Explorer (Test > Window > Test Explorer)
3. Press "Run all" in Test Explorer
   - If you get an error about some packages not installed, right click on the project in Solution Explorer. Choose "Manage NuGet Packages" and click on "Restore".
4. Don't touch your keyboard or mouse while the tests are being executed :)
