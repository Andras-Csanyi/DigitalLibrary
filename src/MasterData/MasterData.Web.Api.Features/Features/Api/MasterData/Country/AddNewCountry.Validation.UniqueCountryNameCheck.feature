# Digital Library project
# https://github.com/SayusiAndo/DigitalLibrary
# Licensed under MIT License

Feature: Digital Library - Masterdata - Country - Country name must be unique

  In order to being able to keep the data clean
  As a Data Owner
  I need the endpoint have the ability to check whether country names are unique and do not let record country with the same name

  Scenario: Country name must be unique

    Given Masterdata database is empty
    And Masterdata database contains the following country
      | CountryName | example |
      | IsActive    | 1       |
    When I want to add the following country
      | CountryName | example |
      | IsActive    | 1       |
    Then I get validation error result
