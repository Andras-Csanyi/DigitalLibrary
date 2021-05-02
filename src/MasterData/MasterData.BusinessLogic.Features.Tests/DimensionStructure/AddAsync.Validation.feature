Feature: DimensionStructure Business Logic - Adding DimensionStructure input validation

  As a Data Owner and Data Curator
  I need to be able to record new data and data structures
  I need to be able to do so the system gets only valid data so
  I need input validation.

  Scenario Outline: When input is invalid it throws exception

    Given there is a parametrized DimensionStructure domain object
      | Field    | Value      |
      | Key      | sf-1       |
      | Name     | <Name>     |
      | Desc     | <Desc>     |
      | IsActive | <IsActive> |

    When DimensionStructure is saved
      | Field     | Value       |
      | Key       | sf-1        |
      | ResultKey | sf-1-result |

    Then DimensionStructure related operation throws exception
      | Field | Value       |
      | Key   | sf-1-result |

    Examples:
      | Name    | Desc    | IsActive |
      | null    | asd     | 1        |
      | empty   | asd     | 1        |
      | 3spaces | asd     | 1        |
      | as      | asd     | 1        |
      | asd     | null    | 1        |
      | asd     | empty   | 1        |
      | asd     | 3spaces | 1        |
      | asd     | asd     | 2        |