Feature: Search Employee

Scenario Outline: Successfully search the employee with employee name and employee id
    Given the user login to the OrangeHRM portal
    And the user click the PIM module
    And the user click the Employee List module
    When the user enters a employee name<empname>,employee id<empid>
    And the user click the search button
    Then the user should see the "Record Found" message


Examples:

    | empname | empid |
    | sanjay  | 97778 |

Scenario Outline: Search the employee with the not existent employee name and employee id
    Given the user login to the OrangeHRM portal
    And the user click the PIM module
    And the user click the Employee List module
    When the user enters a not exists employee name<empname>,employee id<empid>
    And the user click the search button
    Then the user should see "No Records Found" message

Examples:

    | empname | empid |
    | samson  | 1111  |
