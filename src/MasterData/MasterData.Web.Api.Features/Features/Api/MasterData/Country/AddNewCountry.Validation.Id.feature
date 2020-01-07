Feature: Digital Library - Masterdata - Country - Id validation

  In order to being able to keep the data clean
  As a Data Owner
  I need that the endpoint must validate the inbound data and giving back meaningful message when it is not valid

  Scenario Outline: Id Validation

    Given I have a country with name <countryId>
    When I call <domain>/<endpoint>/<method>
    Then I get <result>

    Examples:
      | countryId | domain     | endpoint | method        | result           | httpstatuscode |
      | 1         | masterdata | country  | addnewcountry | validation error | 400            |
      | 0         | masterdata | country  | addnewcountry | success          | 200            |
    