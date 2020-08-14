# Digital Library project
# https://github.com/SayusiAndo/DigitalLibrary
# Licensed under MIT License

Feature: Digital Library - Masterdata - Country - Country name validation during modification

  In order to being able to keep the data clean
  As a Data Owner
  I need that the endpoint must validate the inbound data and giving back meaningful message when it is not valid

  Scenario Outline: Country Name Validation during modification

    Given masterdata database contains the following country
      | CountryName | <countryName> |
      | IsActive    | <IsActive>    |
    And I want to modify this country to the following
      | CountryName | <modifyedContryName> |
      | IsActive    | <isActive>           |
    When I call <domain>/<endpoint>/<method>
    Then I get <result>

    Examples:
      | countryName | modifyedContryName | IsActive | domain     | endpoint | method        | result           | httpstatuscode |
      | asdasd      | null               | 1        | masterdata | country  | modifyCountry | validation error | 400            |
      | asdasd      | whitescpace        | 1        | masterdata | country  | modifyCountry | validation error | 400            |
      | asdasd      | empty              | 1        | masterdata | country  | modifyCountry | validation error | 400            |
      | asdasd      | as                 | 1        | masterdata | country  | modifyCountry | validation error | 400            |
    