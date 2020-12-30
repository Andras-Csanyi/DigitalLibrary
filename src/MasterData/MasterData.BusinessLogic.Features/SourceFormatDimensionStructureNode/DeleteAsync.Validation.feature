Feature: SourceFormatDimensionStructureNode Business Logic - DeleteAsync input validation

  As a Data Owner and Data Curator
  I need to be able to manage structures describing a document
  It includes CRUD operations of SourceFormatDimensionStructureNodes

  Scenario Outline: Exception is thrown when input is invalid

    Given there is a SourceFormatDimensionStructureNode domain object
      | Field     | Value |
      | ResultKey | sfdsn |

    And SourceFormatDimensionStructureNode is saved
      | Field     | Value        |
      | Key       | sfdsn        |
      | ResultKey | sfdsn-result |

    When SourceFormatDimensionStructureNode is deleted by Id
      | Field     | Value               |
      | Id        | <Id>                |
      | ResultKey | sfdsn-delete-result |

    Then SourceFormatDimensionStructureNode delete operation result is an exception
      | Field | Value               |
      | Key   | sfdsn-delete-result |

    Examples:
      | Id |
      | 0  |
