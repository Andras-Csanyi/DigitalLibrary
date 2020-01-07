Feature: Digital Library - Masterdata - Country - IsActive validation

  In order to being able to keep the data clean
  As a Data Owner
  I need that the endpoint must validate the inbound data and giving back meaningful message when it is not valid

  Scenario Outline: IsActive Validation

    Given I have a country with name <IsActive>
    When I call <domain>/<endpoint>/<method>
    Then I get <result>

    Examples:
      | IsActive | domain     | endpoint | method        | result           | httpstatuscode |
      | 1        | masterdata | country  | addnewcountry | success          | 200            |
      | 0        | masterdata | country  | addnewcountry | success          | 200            |
      | 2        | masterdata | country  | addnewcountry | validation error | 400            |
    