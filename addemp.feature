Feature: Add new employee to the OrangeHRM

Scenario Outline: Successfully add an employee
	Given the user is on the OrangeHRM dashboard
	When the user click the PIM module
	And the user click the Add Employee module
	And the user enters a firstname <firstname>,middlename <middlename>,lastname <lastname>,employee id <employeeid>
	And the user click the save button
	Then the user should navigate to the personal details profile page

Examples:

	| firstname | middlename | lastname | employeeid |
	|  karthi   | k          | raja    |    9291 |
	| Subbu    |  G         | kumaran    |     7879 |


Scenario Outline: Fail to add an employee when mandatory fields are blank
	Given the user is on the OrangeHRM dashboard
	When the user click the PIM module
	And the user click the Add Employee module
	And the user leaves the firstname <firstname> and lastname <lastname> field blank
	And the user click the save button
	Then the individual field validation tags should display "Required"

Examples:

	| firstname | lastname |
	|           |          |
