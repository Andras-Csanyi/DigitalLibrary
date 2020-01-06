Feature: Digital Library - Masterdata - Country - Add New Country

  In order to being able to extend the system
  And extend the systems
  And aligne the new data already existing data in the system
  As a Data Owner
  I need to be able to record new countries in the system

  Scenario Outline: When new country is added to the system the endpoint returns with the newly added country

    Given Masterdata databasa is empty
    And I have a new country to be recorded
      | CountryName | <CountryName> |
      | IsActive    | <IsActive>    |
    When I push it to the <domain>/<endpoint>/<method> endpoint
    Then I get result where
      | CountryName | <CountryName> |
      | IsActive    | <IsActive>    |

    Examples:
      | CountryName | IsActive | domain     | endpoint | method        |
      | asd         | 1        | masterdata | country  | addnewcountry |
      | adddddd     | 0        | masterdata | country  | addnewcountry |