Feature: SourceFormat Business Logic - Update a SourceFormat input validation

  As a Data Owner and Data Curator
  I need to be able to update SourceFormat properties
  During modification I need to be sure the operation doesn't make harm
  So that, I need a functionality validates update input.

  Scenario Outline: when input is invalid exception is thrown
    Given there is a SourceFormat domain object
      | Field    | Value                |
      | Key      | sf-update-validation |
      | Name     | <Name>               |
      | Desc     | <Desc>               |
      | IsActive | <IsActive>           |
    And stored SourceFormat result Id set to
      | Field     | Value                |
      | ResultKey | sf-update-validation |
      | Id        | <Id>                 |
    When given SourceFormat is updated
      | Field     | Value                       |
      | Key       | sf-update-validation        |
      | ResultKey | sf-update-validation-result |
    Then SourceFormat update operation result shows error
      | Field | Value                       |
      | Key   | sf-update-validation-result |

    Examples:
      | Id | Name    | Desc    | IsActive |
      | 0  | asd     | asd     | 1        |
      | 1  | null    | asd     | 1        |
      | 1  | empty   | asd     | 1        |
      | 1  | 3spaces | asd     | 1        |
      | 1  | as      | asd     | 1        |

      | 1  | asd     | null    | 1        |
      | 1  | asd     | empty   | 1        |
      | 1  | asd     | 3spaces | 1        |
      | 1  | asd     | as      | 1        |

      | 1  | asd     | asd     | 2        |
    