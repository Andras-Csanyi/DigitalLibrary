Feature: SourceFormat REST Api - Update a SourceFormat input validation

  As a Data Owner and Data Curator
  I need to be able to modify data and data structure in the system
  And I need to be able to do so it prevents the data or data structure from corruption
  So that, I need validation at modification

  Scenario Outline: Invalid data input at modification returns with Bad Request

    Given there is a SourceFormat domain object
      | Field    | Value            |
      | Key      | orig             |
      | Name     | name-orig        |
      | Desc     | description-orig |
      | IsActive | 1                |
    And SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value       |
      | Key       | orig        |
      | ResultKey | orig-result |
    And there is a SourceFormat domain object
      | Field    | Value         |
      | Key      | orig-modified |
      | Name     | <Name>        |
      | Desc     | <Description> |
      | IsActive | <IsActive>    |
    When SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value                |
      | Key       | orig-modified        |
      | ResultKey | orig-modified-result |

    Then SourceFormat domain object related 'orig-modified-result' save operation returns with bad request

    Examples:
      | Name      | Description      | IsActive |
      | null      | description-orig | 1        |
      | empty     | description-orig | 1        |
      | as        | description-orig | 1        |
      | 3spaces   | description-orig | 1        |
      | name-orig | null             | 1        |
      | name-orig | empty            | 1        |
      | name-orig | as               | 1        |
      | name-orig | 3spaces          | 1        |
      | name-orig | description-orig | 2        |