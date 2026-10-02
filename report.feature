Feature:Search the employee reports in the OrangeHRM

Scenario Outline: Fail to search the employee report with non existent report name
Given the user is on the OrangeHRM dashboard
When the user click the PIM module
And the user click the Reports module
And the user enters the non existent report name<report_name>
And the user click the search button
Then the validation tag should display "Invalid"

Examples: 
| report_name     |
| Employee report |
