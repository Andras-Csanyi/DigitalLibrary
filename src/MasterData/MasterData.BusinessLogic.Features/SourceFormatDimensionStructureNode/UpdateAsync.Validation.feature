Feature: SourceFormatDimensionStructureNode Business Logic - UpdateAsync Input Validation

  As a Data Owner and Data Curator
  I need to be able to manage structures describing a document
  It includes CRUD operations of SourceFormatDimensionStructureNodes

  Scenario Outline: Exception is thrown when input is invalid

    Given there is a saved SourceFormat domain object
      | Field     | Value    |
      | ResultKey | sf-saved |
    And there is a saved SourceFormat domain object
      | Field     | Value      |
      | ResultKey | sf-saved-2 |
    And there is a saved DimensionStructureNode domain object
      | Field     | Value     |
      | ResultKey | dsn-saved |
    And there is a saved DimensionStructureNode domain object
      | Field     | Value       |
      | ResultKey | dsn-saved-2 |
    And there is a saved SourceFormatDimensionStructureNode domain object
      | Field                     | Value       |
      | ResultKey                 | sfdsn-saved |
      | SourceFormatKey           | sf-saved    |
      | DimensionStructureNodeKey | dsn-saved   |
    And already saved SourceFormatDimensionStructureNode is updated
      | Field                    | Value                      |
      | Id                       | <Id>                       |
      | SourceFormatId           | <SourceFormatId>           |
      | DimensionStructureNodeId | <DimensionStructureNodeId> |
      | Key                      | sfdsn-saved                |
      | ResultKey                | sfdsn-updated              |

    When SourceFormatDimensionStructureNode is updated
      | Field     | Value                |
      | Key       | sfdsn-updated        |
      | ResultKey | sfdsn-updated-result |

    Then SourceFormatDimensionStructureNode is saved operation result is an exception
      | Field | Value                |
      | Key   | sfdsn-updated-result |

    Examples:
      | Id   | SourceFormatId | DimensionStructureNodeId |
      | 0    | none           | none                     |
      | none | 0              | none                     |
      | none | none           | 0                        |
      