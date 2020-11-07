Feature: SourceFormat Business Logic - Adding SourceFormat input validation

  Scenario Outline: Exception is thrown when input is invalid

    Given there is a SourceFormat domain object
      | Field    | Value      |
      | Key      | SF1        |
      | Name     | <Name>     |
      | Desc     | <Desc>     |
      | IsActive | <IsActive> |

    When SourceFormat is saved
      | Field     | Value     |
      | Key       | SF1       |
      | ResultKey | SF1Result |

    Then SourceFormat related operation throws exception
      | Field     | Value     |
      | ResultKey | SF1Result |

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