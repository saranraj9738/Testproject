Feature: Search the employee in the OrangeHRM

Scenario Outline: Successfully search the employee with employee name and employee id
    Given the user is on the OrangeHRM dashboard
    When the user click the PIM module
    And the user click the Employee List module
    And the user enters a employee name <empname>,employee id <empid>
    And the user click the search button
    Then the user should see the "Record Found" message


Examples:

    | empname | empid |
    | karthi  | 9291 |

Scenario Outline: Search the employee with the not existent employee name and employee id
    Given the user is on the OrangeHRM dashboard
    When the user click the PIM module
    And the user click the Employee List module
    And the user enters a not exists employee name<empname>,employee id<empid>
    And the user click the search button
    Then the user should see "No Records Found" message

Examples:

    | empname | empid |
    | samson  | 1111  |







