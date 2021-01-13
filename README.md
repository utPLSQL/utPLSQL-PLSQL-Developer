# utPLSQL Plugin for PLSQL Developer 

The utPLSQL Plugin integrates [utPLSQL](https://utplsql.org) with [Allround Automations PL/SQL Developer](https://www.allroundautomations.com/products/pl-sql-developer/).

## Running Tests

The plugin adds a Button to the Tools ribbon to execute all tests of the current user or run code coverage.

![Tools Ribbon](screenshots/tools_ribbon.png)

In the object browser on Packages, Package Bodys, Procedures or Users there is a context menu entry to run the tests or code coverage of either the package, the procedure or the user. You can also run tests from an program window. 

![Context Menu](screenshots/context_menu1.png)

## Viewing Results

The results are opened in a new window. Each test run will open a separate window. 

### Navigating to the package body 

Double-click on a test result entry will open the package body. 

### Running  tests

There are two buttons to run the tests again either with or without coverage.

### Running single tests

A right-click opens the context menu, and you can run the test function.

### Filtering and Sorting Results

You can filter the results by clicking on checkboxes behind the status field. A click on the header cell sorts the results first ascending and with a second click descending.  

![Result Window](screenshots/result_window.png)

## Code Coverage

If you select Run Code Coverage from the menu or the context menu a dialog is displayed. In this dialog you can configure the schemas to check for coverage and include or exclude specific objects.

![Code Coverage Diaog](screenshots/code_coverage_dialog.png)

### Report

After running the tests the HTML code coverage report will be opened in the default browser.

![Code Coverage Reports](screenshots/code_coverage_report.png)

## Releases

Binary releases for 64bit and 32bit are published in the [releases section](https://github.com/utPLSQL/utPLSQL-PLSQL-Developer/releases).

## Installation

Copy the DLL to the PlugIns directory of your PL/SQL Developer installation.
- 64bit: PlsqlDeveloperUtPlsqlPlugin.dll
- 32bit: PlsqlDeveloperUtPlsqlPlugin_x86.dll

## Issues

Please file your bug reports, enhancement requests, questions and other support requests within [Github's issue tracker](https://help.github.com/articles/about-issues/).

* [Questions](https://github.com/utPLSQL/utPLSQL-PLSQL-Developer/issues?q=is%3Aissue+label%3Aquestion)
* [Open enhancements](https://github.com/utPLSQL/utPLSQL-PLSQL-Developer/issues?q=is%3Aopen+is%3Aissue+label%3Aenhancement)
* [Open bugs](https://github.com/utPLSQL/utPLSQL-PLSQL-Developer/issues?q=is%3Aopen+is%3Aissue+label%3Abug)
* [Submit new issue](https://github.com/utPLSQL/utPLSQL-PLSQL-Developer/issues/new)

## How to Contribute

1. Describe your idea by [submitting an issue](https://github.com/utPLSQL/utPLSQL-PLSQL-Developer/issues/new)
2. [Fork the utPLSQL-PLSQL-Developer respository](https://github.com/utPLSQL/utPLSQL-PLSQL-Developer/fork)
3. [Create a branch](https://help.github.com/articles/creating-and-deleting-branches-within-your-repository/), commit and publish your changes and enhancements
4. [Create a pull request](https://help.github.com/articles/creating-a-pull-request/)

## How to Build

1. Open the PlsqlDeveloperUtPlsqlPlugin.sln solution in Visual Studio
2. Make sure to choose x64 as Platform target
3. Build the solution

## License

utPLSQL for PL/SQL Developer is licensed under the Apache License, Version 2.0. 
You may obtain a copy of the License at <http://www.apache.org/licenses/LICENSE-2.0>.

