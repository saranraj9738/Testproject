Feature:Add the reporting method in the OrangeHRM

Scenario Outline: Sucessfully add the reporting method to OrangeHRM
Given the user is on the OrangeHRM dashboard
When the user click the PIM module
And the user click the configuration module
And the user click the Reporting Methods
And the user click the Add button
And the user enters reporting method name <method_name>
And the user click the save button
Then the reporting method <method_name> should be visible in the records list


Examples: 
|method_name|
|Online|
