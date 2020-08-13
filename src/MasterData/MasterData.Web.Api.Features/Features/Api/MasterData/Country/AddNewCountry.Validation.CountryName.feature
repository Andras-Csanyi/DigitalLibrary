# Digital Library project
# https://github.com/SayusiAndo/DigitalLibrary
# Licensed under MIT License

Feature: Digital Library - Masterdata - Country - Country name validation

  In order to being able to keep the data clean
  As a Data Owner
  I need that the endpoint must validate the inbound data and giving back meaningful message when it is not valid

  Scenario Outline: Country Name Validation

    Given I have a country with name <countryName>
    When I call <domain>/<endpoint>/<method>
    Then I get <result>

    Examples:
      | countryName | domain     | endpoint | method        | result           | httpstatuscode |
      | null        | masterdata | country  | addnewcountry | validation error | 400            |
      | empty       | masterdata | country  | addnewcountry | validation error | 400            |
      | whitespace  | masterdata | country  | addnewcountry | validation error | 400            |
      | as          | masterdata | country  | addnewcountry | validation error | 400            |
      | asdasd      | masterdata | country  | addnewcountry | success          | 200            |
    